using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceUnit : Unit {

    [SerializeField]
    private Projectile projectile;

    protected override void Update()
    {
        base.Update();
        switch (state)
        {
            case "target in range":
                Debug.Log("Target in range");
                Shoot();
                break;
            default:
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D _collider)
    {
        if (!_collider.isTrigger)
        {
            Entity colliderEntity = _collider.gameObject.GetComponent<Entity>();
            if (colliderEntity != null)
            {
                state = "target in range";
                target = colliderEntity;
            }

        }

    }

    private void Shoot()
    {
        if (target == null)
        {
            state = "idle";
            return;
        }
        if (timeSinceLastAttack >= cooldown)
        {
            Projectile _projectile = Instantiate(projectile, transform.position, Quaternion.identity);
            _projectile.owner = owner;
            _projectile.target = target;
            _projectile.attackPoints = attackPoints;
            _projectile.gameObject.layer = owner.layerIndex;
            timeSinceLastAttack = 0;
        }
        else
        {
            timeSinceLastAttack += Time.deltaTime;
        }


    }



}
