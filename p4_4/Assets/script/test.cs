using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //int number = 10000;
        //object obj1 = 10;
        //object obj2 = "人类";
        ////小范围可以转换为大范围，英式转换
        //int number1 =(int)obj1;//强制转换

        //int numbe1 = 10;
        //long number2 = 100;
        ////number2 = numbe1;
        ////numbe1 = (int)number2; 
        ////numbe1 = number2;

        //int hp = 300;
        //string str = hp.ToString();
        //print(str);
        //print(str.GetType());

        //int hp1 = int.Parse(str);
        //hp1 += 300;
        //print(hp1);
        //print(hp1.GetType());

        ////运算符的优先级
        //int number3 = 1 + 1;
        //print(number3);
        ////number3++;
        //++number3;
        //print(number3);

        //print(number2 == number3);
        //if(number2 == number3)
        //{
        //    print("相等");
        //}
        //else
        //{
        //    print("不相等");
        //}

        //switch case
        int day = 4;

        switch (day)
        {
            case 1:
                print("周一");
                break;
            case 2:
                print("周一");
                break;
            case 3:
                print("周一");
                break;
            case 4:
                print("周si");
                break;
            default:
                print("没有匹配选项");
                break;
        }

        //for循环
        for (int i = 0; i < 100; i++)
        {
            i += 3;
            print(i);
            if (i > 30)
            {
                break;
            }
        }

        int number = 1;
        while (number < 10)
        {
            number += 1;
            print("number" + number);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
