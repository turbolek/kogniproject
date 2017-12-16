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
                Shoot();
                break;
            default:
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D _collider)
    {
        Entity colliderEntity = _collider.gameObject.GetComponent<Entity>();
        state = "target in range";
        target = colliderEntity;
    }

    private void Shoot()
    {
        if (!target)
        {
            state = "idle";
            return;
        }
        if (timeSinceLastAttack >= cooldown)
        {
            Projectile _projectile = Instantiate(projectile, transform.position, Quaternion.identity);
            _projectile.owner = owner;
            timeSinceLastAttack = 0;
        }
        else
        {
            timeSinceLastAttack += Time.deltaTime;
        }


    }



}
