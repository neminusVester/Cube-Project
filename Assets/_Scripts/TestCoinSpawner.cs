using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestCoinSpawner : MonoBehaviour
{
    [SerializeField] private SimpleCollectibleScript coin;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        PoolManager.Instance.ReuseObject<SimpleCollectibleScript>(coin, Vector3.one * Random.Range(-10,10), Quaternion.identity);
    }
}
