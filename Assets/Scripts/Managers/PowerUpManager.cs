using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public enum PowerUpState { Start, Waiting, OnField, Granted }

    private PowerUpState _state;

    float timer;
    float powerUpDuration;

    GameObject powerUp;
    public PlayerHealth playerHealth;
    public float spawnTime;
    public float intervalTime;
    public float fieldTime;
    public Transform[] spawnPoints;

    [SerializeField]
    public MonoBehaviour factory;
    IFactory Factory { get { return factory as IFactory; } }


    void Update() {
        timer += Time.deltaTime;

        if (_state == PowerUpState.OnField && timer >= fieldTime) {
            Destroy(powerUp, 0.5f);
            powerUp = null;
            _state = PowerUpState.Waiting;
            timer = 0f;
        }
        if ((_state == PowerUpState.Start && timer >= spawnTime) ||
            (_state == PowerUpState.Waiting && timer >= intervalTime)) {
            Spawn();
            _state = PowerUpState.OnField;
            timer = 0f;
        }
        if (_state == PowerUpState.Granted && timer >= powerUpDuration) {
            _state = PowerUpState.Waiting;
            powerUpDuration = 0f;
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

    }

    public void GrantPowerUp(float duration) {
        _state = PowerUpState.Granted;
        powerUpDuration = duration;
        timer = 0f;
    }
}
