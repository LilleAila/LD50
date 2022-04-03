using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrees : MonoBehaviour
{
    [SerializeField] TreeScript[] TreePrefabs;

    [Header("Spawner Options")]
    [SerializeField, Range(1, 10)] int MaxTreesPerRow = 5;
    [SerializeField, Range(1, 25)] int Rows = 5;
    [SerializeField, Range(1, 50)] int RowDistance = 10;

    [SerializeField, Range(1, 100)] int MinDistance = 10;
    [SerializeField, Range(1, 100)] int MaxDistance = 50;

    [SerializeField] Vector2 Min;
    [SerializeField] Vector2 Max;

    private void Start()
    {
        for (int i = Rows * RowDistance; i > Min.y; i-= RowDistance)
        {
            float x = Min.x;
            for(int j = 0; j < Random.Range(0, MaxTreesPerRow); j++)
            {
                x += Random.Range(MinDistance, MaxDistance);
                Vector2 SpawnPos = new Vector2(x, Random.Range(i - RowDistance / 2, i + RowDistance / 2));

                TreeScript TreePrefab = TreePrefabs[Random.Range(0, TreePrefabs.Length)];

                TreeScript theTree = Instantiate(TreePrefab, SpawnPos, TreePrefab.transform.rotation);
                theTree.transform.SetParent(transform);
            }
        }
    }
}
