using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : Entity
{
    public float speed;
    protected Entity target = null;

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
            Debug.Log("Moving");
            gameObject.layer = owner.layerIndex;
            Move();
        } else if (target.GetComponent<Unit>())
        {
            gameObject.layer = 8;
        }
        
    }

    private void Move()
    {
        Vector2 distance = owner.directionVector * speed * Time.deltaTime;
        gameObject.transform.Translate(distance);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided with " + collision.gameObject);
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
        Debug.Log("Target: " + target.gameObject);
       
    }
}
