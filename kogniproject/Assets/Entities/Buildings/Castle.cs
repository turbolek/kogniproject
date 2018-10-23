using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : Entity {

    public delegate void Action(Player player);
    public static event Action Destroyed; 

    protected override void Die()
    {
        base.Die();
        Destroy(gameObject);
        if (Destroyed != null) Destroyed(owner);
    }
}
