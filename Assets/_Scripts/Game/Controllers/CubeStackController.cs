using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeStackController : MonoBehaviour
{
    [SerializeField] private List<GameObject> blockList = new List<GameObject>();
    [SerializeField] private Transform cubeHolder;
    private GameObject _lastBlock;
    private GameObject _firstBlock;
    private float _cubeOffset = 1f;

    public void Start()
    {
        // _cubeHolder = PlayerController.Instance.transform.GetChild(1);
        _firstBlock = cubeHolder.GetChild(0).gameObject;
        InitialzieBlockList();
        GameEvents.Instance.OnCubePicked += IncreaseBlockStack;
        GameEvents.Instance.OnWallCollision += DecreaseBlockStack;
    }

    private void OnDestroy()
    {
        GameEvents.Instance.OnCubePicked -= IncreaseBlockStack;
        GameEvents.Instance.OnWallCollision -= DecreaseBlockStack;
    }

    private void InitialzieBlockList()
    {
        blockList.Add(_firstBlock);
        if (_firstBlock.transform.parent == null) _firstBlock.transform.SetParent(cubeHolder);
        UpdateLastBlock();
    }

    private void IncreaseBlockStack(GameObject cubePrefab)
    {
        cubePrefab.transform.position = new Vector3(_lastBlock.transform.position.x,
        _lastBlock.transform.position.y - _cubeOffset, _lastBlock.transform.position.z);
        cubePrefab.transform.SetParent(cubeHolder);
        blockList.Add(cubePrefab);
        UpdateLastBlock();
    }

    private void DecreaseBlockStack(GameObject cubePrefab)
    {

        if (cubePrefab != blockList[0])
        {
            cubePrefab.transform.parent = null;
            blockList.Remove(cubePrefab);
            UpdateLastBlock();
            Destroy(cubePrefab, 1f);
        }
        else
        {
            GameEvents.Instance.StickmanTouchWall();
        }
    }

    private void UpdateLastBlock()
    {
        if (blockList.Count == 0) return;
        else _lastBlock = blockList[blockList.Count - 1];
    }
}
