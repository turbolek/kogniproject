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
        if (collision.gameObject.GetComponent<Entity>() != null)
        {
            engaged = true;
        }
        
    }


}
