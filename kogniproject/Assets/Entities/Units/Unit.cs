using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : Entity
{
    public float speed;
    protected Entity target = null;
    [SerializeField]
    protected int attackPoints;
    [SerializeField]
    protected float cooldown;
    protected float timeSinceLastAttack = 0;
    protected string state = "idle";

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (!target)
        {
            gameObject.layer = owner.layerIndex;
            Move();
        } else 
        {
            if (target.GetComponent<Unit>()) gameObject.layer = 8;
            Attack(target);
        }
        
    }

    protected virtual void Move()
    {
        Vector2 distance = owner.directionVector * speed * Time.deltaTime;
        gameObject.transform.Translate(distance);
    }

    protected virtual void Attack(Entity target)
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Check if collider is an entity (could be ground for example)
        Entity colliderEntity = collision.gameObject.GetComponent<Entity>();
        if (colliderEntity == null)
        {
            return;
        }

        if (colliderEntity.owner != owner)
        {
            target = colliderEntity;
        }
    }
}
