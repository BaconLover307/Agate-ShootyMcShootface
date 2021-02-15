using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFactory : MonoBehaviour, IFactory
{

    [SerializeField]
    public GameObject[] powerUpPrefab;

    public GameObject FactoryMethod(int tag)
    {
        GameObject powerUp = powerUpPrefab[tag];
        return powerUp;
    }
}