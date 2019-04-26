using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    private Transform playerTransfrom;
    private float spawnZ = 45.6f;
    private float tileLength = 7.6f;
    private int amnTilesOnScreen = 5;

    // Start is called before the first frame update
    void Start()
    {
        playerTransfrom = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < amnTilesOnScreen; i++)
        {
            SpawnTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        print("value: "+ (spawnZ - amnTilesOnScreen * tileLength));
        if (playerTransfrom.position.z > (spawnZ - amnTilesOnScreen * tileLength))
        {
            SpawnTile();
        }
    }

    void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(tilePrefabs[Random.Range(0,4)]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        print("spawn z: "+ spawnZ);
    }
}
