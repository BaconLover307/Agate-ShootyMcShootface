using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBonus : PowerUp
{
    int startDamage;
    public float damageMultiplier = 2f;

    public GameObject GunBarrelEnd;
    PlayerShooting playerShooting;
    public override void GrantPowerUp()
    {
        playerShooting = GunBarrelEnd.GetComponent<PlayerShooting>();
        startDamage = playerShooting.damagePerShot;
        playerShooting.setDamage(Mathf.RoundToInt(startDamage * damageMultiplier));
    }

    public override void Reset()
    {
        playerShooting.setDamage(startDamage);
    }

}
