using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public enum PowerUpState { Start, Waiting, OnField }

    private PowerUpState _state;

    float timer;
    float powerUpDuration;

    GameObject powerUp;
    public PlayerHealth playerHealth;
    public float spawnTime = 30f;
    public float intervalTime = 20f;
    public float fieldTime = 10f;
    public Transform[] spawnPoints;

    [SerializeField]
    public MonoBehaviour factory;
    IFactory Factory { get { return factory as IFactory; } }

    void Start ()
    {
        //Mengeksekusi fungsi Spawn setiap beberapa detik sesui dengan nilai spawnTime
        //InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Update() {
        timer += Time.deltaTime;

        if (_state == PowerUpState.OnField && timer >= fieldTime) {
            _state = PowerUpState.Waiting;
            Destroy(powerUp);
            timer = 0f;
        }
        if ((_state == PowerUpState.Start && timer >= spawnTime) ||
            (_state == PowerUpState.Waiting && timer >= intervalTime)) {
            Spawn();
            _state = PowerUpState.OnField;
            timer = 0f;
        }

    }

    void Spawn()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        int spawnPowerUp = Random.Range(0, 3);

        // Mengenerate power up
        powerUp = Instantiate(Factory.FactoryMethod(spawnPowerUp), spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        _state = PowerUpState.Waiting;
        timer = 0f;

    }
}
