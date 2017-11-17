using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : Entity
{
    private Vector2 direction;
    public float speed;
    protected Entity target = null;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        int x = owner ? 1 : -1;
        direction = new Vector2(x, 0);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (!target)
        {
            gameObject.layer = 0;
            Move();
        } else
        {
            gameObject.layer = 8;
        }
        
    }

    private void Move()
    {
        Vector2 distance = direction * speed * Time.deltaTime;
        gameObject.transform.Translate(distance);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided");
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
