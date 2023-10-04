using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TestAbstract : MonoBehaviour
{
    protected virtual int Virtual(int a, float b)
    {
        var c = (float)a + b;
        return (int)c;
    }
    
    protected float GetSpeed(float weight, float height)
    {
        return weight * (float)9.81 * height;
    }
}
