using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerPoints : MonoBehaviour
{
    public Enemy[] enemies;
    int randomIndex;

    private void Update()
    {
        if(enemies == null) return;

        enemies = FindObjectsOfType<Enemy>();

        enemies[randomIndex].OnReset += GetRandomPosition;
    }

    void GetRandomPosition()
    {
        randomIndex = Random.Range(0, enemies.Length);
        Transform randomTransform = enemies[randomIndex].transform;

        enemies[randomIndex].transform.position = randomTransform.position;
    }


}
