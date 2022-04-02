using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    [SerializeField] float treeAmount;
    [SerializeField] TreeScript treePrefab;
    [SerializeField] GameObject treeParent;

    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;
    
    void Start()
    {
        for (int i = 0; i < treeAmount; i++)
        {
            Vector2 spawnPos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

            TreeScript theTree = Instantiate(treePrefab, spawnPos, treePrefab.transform.rotation);
            theTree.transform.SetParent(treeParent.transform);
        }
    }
}
