using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceUnit : Unit {

    [SerializeField]
    private Projectile projectile;

    void OnTriggerEnter2D(Collider2D _collider)
    {
        Debug.Log("Trigger entered: " + _collider);
        Projectile _projectile = Instantiate(projectile, transform.position, Quaternion.identity);
        _projectile.owner = owner;
    }

}
