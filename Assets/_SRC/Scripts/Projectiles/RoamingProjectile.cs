using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamingProjectile : Projectile
{

    public Transform target;

    public override void Awake()
    {
        base.Awake();
    }

    public override void Init(Transform pTarget)
    {
        base.Init();

        target = pTarget;

        isReady = true;

        Destroy(this.gameObject, 10f);
    }

    public override void Update()
    {
        if (isReady == false) return;

        base.Update();


        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * brain.projectileSpeed);
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("ON COLLISSION ENTER CALLED");

        if (other.gameObject.tag != "Enemy") return;

        // dar dano

        other.gameObject.GetComponent<IDamageable>().TakeDamage(brain.Damage);

        Destroy(this.gameObject);

    }
}
