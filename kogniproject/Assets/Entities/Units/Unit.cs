using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    //TODO get player object instead of bool
    public bool owner;
    private Vector2 direction;
    public float speed;
    private bool engaged = false;

    // Use this for initialization
    void Start()
    {
        int x = owner ? 1 : -1;
        direction = new Vector2(x, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!engaged)
        {
            Move();
        }
        
    }

    private void Move()
    {
        Vector2 distance = direction * speed * Time.deltaTime;
        gameObject.transform.Translate(distance);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Check if collider is an entity (could be ground for example)
        Entity colliderEntity = collision.gameObject.GetComponent<Entity>();
        if ( colliderEntity == null)
        {
            return;
        }

        //Check if collider is a unit (could be a castle for example)
        Unit colliderUnit = colliderEntity.GetComponent<Unit>();

        //Engage with an enemy unit that is not yet engaged
        if ( colliderUnit != null && colliderUnit.owner != owner && !colliderUnit.engaged)
        {
            colliderUnit.engaged = true;
            engaged = true;
            //Move engaged units to another layer for avoiding collisions with other units
            gameObject.layer = 8;
            colliderUnit.gameObject.layer = 8;
        }
        
    }


}
