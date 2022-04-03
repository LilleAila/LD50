using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    [SerializeField] int rows;
    [SerializeField] float minTreesPerRow;
    [SerializeField] float maxTreesPerRow;
    [SerializeField] int rowDistance;

    [SerializeField] float minTreeDistance;
    [SerializeField] float maxTreeDistance;

    [SerializeField] TreeScript treePrefab;
    [SerializeField] GameObject treeParent;

    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;
    
    void Start()
    {

        for (int i = rows * rowDistance; i > minY; i -= rowDistance)
        {
            float x = minX;
            for (int j = 0; j < Random.Range(minTreesPerRow, maxTreesPerRow); j++)
            {
                x += Random.Range(minTreeDistance, maxTreeDistance);
                Vector2 spawnPos = new Vector2(x, Random.Range(i-1,i+1));

                TreeScript theTree = Instantiate(treePrefab, spawnPos, treePrefab.transform.rotation);
                theTree.transform.SetParent(treeParent.transform);
            }
        }
    }
}
