using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    public WeaponsScriptable[] Weapons;
    public LayerMask EnemiesLayer;

    public void AddWeapon(WeaponsScriptable weapon)
    {

    }

    public void UpdateWeapon(WeaponsScriptable weapon)
    {
        
    }

    public void UseWeapon(WeaponsScriptable weapon)
    {

    }

    private void Start()
    {
        InvokeRepeating("UseTargetWeapons", 0f, 1f);
    }

    private void UseTargetWeapons()
    {
        if (Weapons.Length <= 0) return;

        foreach (WeaponsScriptable weapon in Weapons)
        {
            if (weapon.type != WeaponType.NEEDTARGET) continue;

            var neabyEnemies = Physics.OverlapSphere(transform.position, weapon.Range, EnemiesLayer);

            if(neabyEnemies.Length <= 0) continue;

            var closestTarget = neabyEnemies[0];
            var closestDistance = 99999f;

            foreach (Collider enemy in neabyEnemies)
            {
                var distance = Vector3.Distance(transform.position, enemy.transform.position);

                if (distance < closestDistance)
                {
                    closestTarget = enemy;
                    closestDistance = distance;
                }
            }

            var projectile = Instantiate(weapon.proj, transform.position, Quaternion.identity);

            projectile.GetComponent<TargetProjectile>().Init(closestTarget.transform);
        }
    }
}
