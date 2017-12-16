using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeUnit : Unit {

    protected override void Attack (Entity _target)
    {
        if (_target)
        {
            if (timeSinceLastAttack >= cooldown)
            {
                Debug.Log(gameObject + " deals " + attackPoints + " damage to " + _target);
                _target.TakeDamage(attackPoints);
                timeSinceLastAttack = 0;
            } else
            {
                timeSinceLastAttack += Time.deltaTime;
            }
        }
    }
}
