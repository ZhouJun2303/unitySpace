using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using Newtonsoft.Json;
public class DrawBesizerLine : MonoBehaviour
{
    [Header("关卡编号")]
    public String level;
    [Header("跑道列表")]
    public Transform[] pathRoot = null;
    [Header("跑道路径取点密度(数值越大越平滑)")]
    public int samplingCount = 5;  //两个基础点之间的取点数量   值越大曲线就越平滑  但同时计算量也也越大
    [Header("复活点判定范围")]
    public float revivePointRange = 0.2f;
    [Header("是否显示路径点")]
    public bool showPathPoints;
    [Header("是否显示路径线")]
    public bool showPathLine = true;
    public List<Dot> pathCopy;

    [ContextMenu("导出关卡配置")]
    void DoSomething()
    {

        var levelStr = "level" + level;
        string _txtPath = Application.dataPath + "/levelInfo/" + levelStr + ".txt";
        List<List<Dot>> obj = new List<List<Dot>>();
        List<string> objStr = new List<string>();

        for (int i = 0; i < pathRoot.Length; i++)
        {
            var dots = GetPathDots(pathRoot[i]);
            string[] sa = new string[dots.Count];
            for (int j = 0; j < dots.Count; j++)
            {
                var dot = dots[j];
                var x = dot.v3.x;
                var y = dot.v3.y;
                var z = dot.v3.z;
                var revive = dot.isRevice ? 1 : 0;
                var str = x + "_" + y + "_" + z + "_" + revive;
                sa[j] = str;
            }
            objStr.Add(string.Join(",", sa));
            obj.Add(dots);
        }
        var setting = new JsonSerializerSettings();
        setting.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        var msgs = JsonConvert.SerializeObject(obj, setting);
        var msgstr = JsonConvert.SerializeObject(objStr, setting);
        FileInfo file = new FileInfo(_txtPath);
        if (file.Exists)
        {
            file.Delete();
            file.Refresh();
        }

        StreamWriter writer = file.CreateText();
        writer.WriteLine(msgstr);
        writer.Flush();
        writer.Dispose();
        writer.Close();
        AssetDatabase.Refresh();
        Debug.Log("关卡导出成功"+ levelStr);
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < pathRoot.Length; i++)
        {
            DrawPath(pathRoot[i]);
        }
    }

    private List<Dot> DrawPath(Transform mtransform)
    {
        var linerender = mtransform.gameObject.GetComponent<LineRenderer>();
        if (!linerender)
        {
            linerender = mtransform.gameObject.AddComponent<LineRenderer>();
        }
        linerender.startWidth = 2;
        linerender.endWidth = 2;


        var paths = GetPathDots(mtransform);
        pathCopy = paths;
        linerender.positionCount = paths.Count;
        Vector3 prevPt = paths[0].Position;
        for (int i = 1; i < paths.Count; i++)
        {
            var color = paths[i].isRevice ? Color.black : Color.white;
            color.a = 0.7f;
            Gizmos.color = color;
            Vector3 currPt = paths[i].Position;
            if (showPathPoints) Gizmos.DrawSphere(currPt, 0.8f);
            if (showPathLine)
            {
                linerender.SetPosition(i, currPt);
                linerender.SetPosition(i - 1, prevPt);
            }
            else
            {
                linerender.positionCount = 0;
            }
            prevPt = currPt;
        }
        return paths;
    }

    List<Dot> GetPathDots(Transform pathRootTransform)
    {
        var dots = new List<Dot>();
        //获取控制点列表   
        var controlPointComps = new List<ContrlPoint>();
        var controlPositions = new List<Vector3>();

        for (int i = 0; i < pathRootTransform.childCount; i++)
        {
            var controlTransform = pathRootTransform.GetChild(i);
            if (!controlTransform.gameObject.activeSelf)
            {
                //排除隐藏的控制点
                continue;
            }
            var contrlComp = controlTransform.GetComponent<ContrlPoint>();
            if (!contrlComp)
            {
                contrlComp = controlTransform.gameObject.AddComponent<ContrlPoint>();
            }
            //设置外观方便可视化
            var mt = contrlComp.GetComponent<MeshRenderer>().sharedMaterial;
            var ls = controlTransform.localScale;
            if (!mt)
            {
                mt = AssetDatabase.LoadAssetAtPath<Material>("Assets/Material/pathpoint.mat");
            }
            if (contrlComp.revive)
            {
                mt.color = Color.green;
                ls.x = ls.y = ls.z = 1.0f;
            }
            else
            {
                mt.color = Color.blue;
                ls.x = ls.y = ls.z = 1.0f;
            }
            contrlComp.GetComponent<MeshRenderer>().sharedMaterial = mt;
            controlTransform.localScale = ls;
            controlPointComps.Add(contrlComp);
            controlPositions.Add(contrlComp.transform.position);
        }
        //贝塞尔曲线节点
        var pathNodes = PathControlPointGenerator(controlPositions.ToArray());
        int SmoothAmount = controlPositions.Count * samplingCount;
        for (int i = 0; i <= SmoothAmount; i++)
        {
            float pm = (float)i / SmoothAmount;
            Vector3 dotPos = Interp(pathNodes, pm);
            Dot dot = new Dot
            {
                Position = dotPos
            };
            var closeRevive = false;
            //判断是否为复活点
            for (int j = 0; j < controlPointComps.Count; j++)
            {
                var controlPos = controlPointComps[j].transform.position;
                var comp = controlPointComps[j];
                if (!comp.revive)
                {
                    continue;
                }
                var dis = Vector3.Distance(dotPos, controlPos);
                if (dis <= revivePointRange)
                {
                    closeRevive = true;
                }
            }
            dot.isRevice = closeRevive;
            dots.Add(dot);
        }

        return dots;
    }

    bool IsCloseRevive(Vector3 point, List<Transform> controlPoints)
    {
        for (int i = 0; i < controlPoints.Count; i++)
        {
            var controlPos = controlPoints[i].position;
            var contrlComp = controlPoints[i].GetComponent<ContrlPoint>();
            if (!contrlComp.revive)
            {
                continue;
            }
            var dis = Vector3.Distance(point, controlPos);
            if (dis <= 3)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// 计算所有节点以及控制点坐标
    /// </summary>
    /// <param name="path">所有节点的存储数组</param>
    /// <returns></returns>
    public Vector3[] PathControlPointGenerator(Vector3[] path)
    {
        Vector3[] suppliedPath;
        Vector3[] vector3s;

        suppliedPath = path;
        int offset = 2;
        vector3s = new Vector3[suppliedPath.Length + offset];
        Array.Copy(suppliedPath, 0, vector3s, 1, suppliedPath.Length);
        vector3s[0] = vector3s[1] + (vector3s[1] - vector3s[2]);
        vector3s[vector3s.Length - 1] = vector3s[vector3s.Length - 2] + (vector3s[vector3s.Length - 2] - vector3s[vector3s.Length - 3]);
        if (vector3s[1] == vector3s[vector3s.Length - 2])
        {
            Vector3[] tmpLoopSpline = new Vector3[vector3s.Length];
            Array.Copy(vector3s, tmpLoopSpline, vector3s.Length);
            tmpLoopSpline[0] = tmpLoopSpline[tmpLoopSpline.Length - 3];
            tmpLoopSpline[tmpLoopSpline.Length - 1] = tmpLoopSpline[2];
            vector3s = new Vector3[tmpLoopSpline.Length];
            Array.Copy(tmpLoopSpline, vector3s, tmpLoopSpline.Length);
        }
        return (vector3s);
    }


    /// <summary>
    /// 计算曲线的任意点的位置
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public Vector3 Interp(Vector3[] pos, float t)
    {
        int length = pos.Length - 3;
        int currPt = Mathf.Min(Mathf.FloorToInt(t * length), length - 1);
        float u = t * (float)length - (float)currPt;
        Vector3 a = pos[currPt];
        Vector3 b = pos[currPt + 1];
        Vector3 c = pos[currPt + 2];
        Vector3 d = pos[currPt + 3];
        Vector3 v3 = .5f * (
           (-a + 3f * b - 3f * c + d) * (u * u * u)
           + (2f * a - 5f * b + 4f * c - d) * (u * u)
           + (-a + c) * u
           + 2f * b
       );
        return v3;
    }

    float RetainFloat(float f)
    {
        int i = (int)(f * 100);
        var ff = (float)(i * 1.0) / 100;
        return ff;
    }

    Vector3 RetainVector(Vector3 v)
    {
        var x = RetainFloat(v.x);
        var y = RetainFloat(v.y);
        var z = RetainFloat(v.z);
        return new Vector3(x, y, z);
    }
}


[Serializable]
public class Dot
{
    public bool isRevice;
    public V3 v3 = new V3();
    [Newtonsoft.Json.JsonIgnore]
    private Vector3 position;
    [Newtonsoft.Json.JsonIgnore]
    public Vector3 Position
    {
        set
        {
            v3.x = RetainFloat(value.x);
            v3.y = RetainFloat(value.y);
            v3.z = RetainFloat(value.z);
            position = value;
        }
        get
        {
            return position;
        }
    }

    float RetainFloat(float f)
    {
        int i = (int)(f * 100);
        var ff = (float)(i * 1.0) / 100;
        return ff;
    }
}
[Serializable]
public class V3
{
    public float x = 0;
    public float y = 0;
    public float z = 0;
}
