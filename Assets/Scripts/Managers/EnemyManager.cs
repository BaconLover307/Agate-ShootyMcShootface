using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    [SerializeField]
    MonoBehaviour factory;
    IFactory Factory { get { return factory as IFactory; } }

    void Start ()
    {
        //Mengeksekusi fungs Spawn setiap beberapa detik sesui dengan nilai spawnTime
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn ()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range (0, spawnPoints.Length);
        int spawnEnemy = Random.Range(0, 3);



        // Menduplikasi enemy
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        Factory.FactoryMethod(spawnEnemy);

    }
}
