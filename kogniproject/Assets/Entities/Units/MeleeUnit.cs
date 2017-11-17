using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeUnit : Unit {

    [SerializeField]
    private int attackPoints;
    private Unit thisUnit;
    [SerializeField]
    private float cooldown;
    private float timeSinceLastAttack = 0;


	// Use this for initialization
	protected override void Start () {
        base.Start();
        thisUnit = GetComponent<Unit>();
	}
	
	// Update is called once per frame
	protected override void Update () {
        base.Update();
		if (target)
        {
            Attack(target);
        }
	}

    private void Attack (Entity _target)
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
