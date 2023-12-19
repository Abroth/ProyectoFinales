using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject enemy;

    public Transform spawnerTransform;

    public bool canSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!canSpawn) 
        {
            Instantiate(enemy, spawnerTransform);
            StartCoroutine(SpawnEnemy());
        }
    }

    IEnumerator SpawnEnemy()
    {
        canSpawn = true;
        yield return new WaitForSeconds(Random.Range(1, 4));
        canSpawn= false;
        
    }
}
