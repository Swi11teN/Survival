using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    public GameObject[] resources;
    public float minX;
    public float maxX;
    public float staticY;
    public float minZ;
    public float maxZ;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawner", Random.Range(10, 20), Random.Range(10, 20));
    }
    
    private void Spawner()
    {
        int randResourceIndex = Random.Range(0, resources.Length);

        Instantiate(resources[randResourceIndex], transform.position + new Vector3(Random.Range(minX, maxX), staticY, Random.Range(minZ, maxZ)), Quaternion.identity);
    }
}
