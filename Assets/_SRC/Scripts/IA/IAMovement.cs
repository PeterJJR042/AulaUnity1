using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAMovement : MonoBehaviour
{
    private NavMeshAgent nav;

    [Header("Enemy Info")]
    public float AttackRange;
    public float AttackSpeed;
    public float currentAttackCooldown;
    public int[] AttackDamage;
    public bool canAttack;

    [Header("Player Info")]
    public Transform player;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.stoppingDistance = AttackRange;
    }

    void Update()
    {
        if (player == null)
        {
            return;
        }

        Chase();

        if(canAttack)
        {
            Attack();
        }
        else
        {
            currentAttackCooldown -= Time.deltaTime;

            if (currentAttackCooldown <= 0)
            {
                canAttack = true;
                currentAttackCooldown = AttackSpeed;
            }
        }
    }
    
    void Attack()
    {
        canAttack = false;

        player.GetComponent<IDamageable>().TakeDamage(Random.Range(AttackDamage[0], AttackDamage[1]));
    }

    void Chase()
    {
        nav.SetDestination(player.position);
    }

}
