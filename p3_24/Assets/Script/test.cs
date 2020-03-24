using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    //常量的定义 
    //test的类常量
    const string oldName = "cccc";
    // Start is called before the first frame update
    void Start()
    {
        //print("输出语句");
        //Debug.Log("debug输出");
        
        //局部变量
        string name = "name";
        int age = 3;
        bool flag = true;
        char str = 'a';
        //char str1  = "a" ;
        /*
         字符类型只能是单引号
         */
        //if (flag)
        //{
        //    oldName = name;
            print(oldName);
        //}
        print(age);
        //string newName = (string)age;
        string newName = age.ToString();
        //bool newAge = name.ToBoolean();
        print(newName);
        //print(newAge);
        print( flag);
    }

    // Update is called once per frame
    void Update()
    {
        //print(flag);
        //Debug.Log("debug输出");
    }
}
