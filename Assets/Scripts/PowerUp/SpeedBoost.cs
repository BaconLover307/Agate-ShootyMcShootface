using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : PowerUp
{
    float startSpeed;
    public float speedMultiplier = 2f;

    PlayerMovement playerMovement;
    public override void GrantPowerUp()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        startSpeed = playerMovement.speed;
        playerMovement.setSpeed(startSpeed * speedMultiplier);
    }

    public override void Reset()
    {
        playerMovement.setSpeed(startSpeed);
    }

}
