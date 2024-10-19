using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObject/EnemyData", order = 0)]

public class EnemyScriptable : ScriptableObject
{
    [Header("Data")]
    public Status Status;
    public float speed;

    [Header("Combat Data")]
    public float AttackRange;
    public float AttackSpeed;
    public int[] AttackDamage;

    [Header("GFX")]
    public GameObject GFX;
}
