using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillHealth : PowerUp
{
    PlayerHealth playerHealth;

    public override void GrantPowerUp()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
        playerHealth.setHealth(playerHealth.startingHealth);
    }

    public override void Reset()
    {
        Destroy(gameObject, 10f);
    }

}
