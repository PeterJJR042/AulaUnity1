using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObject/WeaponData", order = 1)]
public class WeaponsScriptable : ScriptableObject
{
    public float Damage;
    public float Range;
    public float AttackSpeed;
    public float CurrentCooldown;
    public float projectileSpeed;
    public WeaponType type;

    public GameObject proj;
}
