using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public Player owner;
    public Entity target;
    public int attackPoints;

    // Use this for initialization
    void Start () {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        float distanceToTarget = Mathf.Abs(target.transform.position.x - transform.position.x);
        if (target.GetComponent<Unit>() != null) distanceToTarget -= Mathf.Abs(target.GetComponent<Unit>().speed * speed / Physics2D.gravity.y);
        float angle = Mathf.Asin(distanceToTarget * -Physics2D.gravity.y / speed / speed) / 2;
        angle = angle * Mathf.Rad2Deg > 45 ? (90 - angle * Mathf.Rad2Deg) * Mathf.Deg2Rad : angle;
        float velocityX = Mathf.Cos(angle) * speed;
        float velocityY = Mathf.Sqrt(speed * speed - velocityX * velocityX);
        rb.velocity = new Vector2(owner.directionVector.x * velocityX, velocityY);
        gameObject.layer = owner.layerIndex + 2;
    }
	
	// Update is called once per frame
	void Update () {

        Rotate();
    }

    protected virtual void Rotate()
    {
        Vector3 dir = GetComponent<Rigidbody2D>().velocity;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Entity colliderEntity = collision.gameObject.GetComponent<Entity>();
        if (colliderEntity && colliderEntity == target)
        {
            target.TakeDamage(attackPoints);
            
        }
        Destroy(gameObject);
    }
}
