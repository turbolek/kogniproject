using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed = 2;
    public Player owner;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    protected virtual void Move()
    {
        Vector2 distance = owner.directionVector * speed * Time.deltaTime;
        gameObject.transform.Translate(distance);
    }
}
