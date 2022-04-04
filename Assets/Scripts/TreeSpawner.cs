using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    [SerializeField] TreeScript[] treePrefabs;

    [Header("Row Settings")]
    [SerializeField] int rows;
    [SerializeField] float minTreesPerRow;
    [SerializeField] float maxTreesPerRow;
    [SerializeField] int rowDistance;

    [Header ("Tree Settings")]
    [SerializeField] float minTreeDistance;
    [SerializeField] float maxTreeDistance;

    [SerializeField] GameObject treeParent;

    [SerializeField] Vector2 min;
    [SerializeField] Vector2 max;

    void Awake()
    {
        SpawnTrees();
    }

    private void Update()
    {
        float treeCount;
        treeCount = treeParent.GetComponentsInChildren<Transform>().Length - 1; // -1 because GetComponentsInChildren includes the parent

        if (treeCount <= 0) SpawnTrees();
    }

    void SpawnTrees()
    {
        for (int i = rows * rowDistance; i > min.y; i -= rowDistance)
        {
            float x = min.x;
            for (int j = 0; j < Random.Range(minTreesPerRow, maxTreesPerRow); j++)
            {
                x += Random.Range(minTreeDistance, maxTreeDistance);
                Vector2 spawnPos = new Vector2(x, Random.Range(i - 0.5f, i + 0.5f));
                TreeScript randomTree = treePrefabs[Random.Range(0, treePrefabs.Length)];

                TreeScript theTree = Instantiate(randomTree, spawnPos, randomTree.transform.rotation);
                theTree.transform.SetParent(treeParent.transform);
            }
        }
    }
}
