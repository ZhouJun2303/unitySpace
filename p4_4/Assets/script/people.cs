using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class people : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //int num = add(1, 4);
        //print("people" + num);
        people p1 = new people();
        p1.add(4, 6);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int add(int i,int j)
    {
        int num1 = i + j;
        print("people" + num1);
        return num1;
    }
}
