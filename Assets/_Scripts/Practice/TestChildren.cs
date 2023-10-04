using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestChildren : TestAbstract, ITest
{
    private  int Virtual(int a, float b, string s)
    {
        return  base.Virtual(a, b);
        var result = base.Virtual(a, b);
        print(result + s);
    }

    void ITest.Move()
    {
        print(base.GetSpeed(45,3));
    }
}
