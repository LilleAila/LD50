using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrees : MonoBehaviour
{
    [SerializeField] GameObject[] TreePrefabs;

    [Header("Spawner Options")]
    [SerializeField, Range(1, 10)] int MinTreesPerRow = 1;
    [SerializeField, Range(1, 10)] int MaxTreesPerRow = 5;
    [SerializeField, Range(1, 25)] int Rows = 5;
    [SerializeField, Range(1, 50)] int RowDistance = 10;

    [SerializeField, Range(1, 100)] int MinDistance = 10;
    [SerializeField, Range(1, 100)] int MaxDistance = 50;

    [SerializeField] Vector2 Min;
    [SerializeField] Vector2 Max;

    [HideInInspector] public int treeCount = 0;

    private void Awake()
    {
        Spawn();
    }

    private void Update()
    {
        if (treeCount == 0) Spawn();
    }

    void Spawn()
    {
        for (int i = Rows * RowDistance; i > Min.y; i -= RowDistance)
        {
            float x = Min.x;
            for (int j = 0; j < Random.Range(MinTreesPerRow, MaxTreesPerRow); j++)
            {
                x += Random.Range(MinDistance, MaxDistance);
                Vector2 SpawnPos = new Vector2(x, Random.Range(i - 1, i + 1));

                GameObject TreePrefab = TreePrefabs[Random.Range(0, TreePrefabs.Length)];

                GameObject theTree = Instantiate(TreePrefab, SpawnPos, TreePrefab.transform.rotation);
                theTree.transform.SetParent(transform);

                treeCount++;
            }
        }
    }
}
