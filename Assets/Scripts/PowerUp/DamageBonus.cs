using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBonus : PowerUp
{
    int startDamage;
    public float damageMultiplier = 2f;

    GameObject GunBarrelEnd;
    PlayerShooting playerShooting;
    public override void GrantPowerUp()
    {
        GunBarrelEnd = GameObject.FindGameObjectWithTag("GunBarrelEnd");
        playerShooting = GunBarrelEnd.GetComponent<PlayerShooting>();
        startDamage = playerShooting.damagePerShot;
        playerShooting.setDamage(Mathf.RoundToInt(startDamage * damageMultiplier));
    }

    public override void Reset()
    {
        playerShooting.setDamage(startDamage);
        isGranted = false;
        Destroy(gameObject, 2f);
    }

}
