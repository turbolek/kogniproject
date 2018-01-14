using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : Entity
{
    public float speed;
    protected Entity target = null;
    protected int attackPoints;
    [SerializeField]
    protected int basicAttackPoints; 
    [SerializeField]
    protected float cooldown;
    protected float timeSinceLastAttack = 0;
    protected string state = "idle";

    public Sprite portrait;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        switch (state)
        {
            case "idle":
                Debug.Log("Idle");
                Idle();
                break;
            case "engaged":
                Debug.Log("Engaged");
                Engaged();
                break;
            default:
                break;
        }     
    }

    protected virtual void Idle()
    {
        gameObject.layer = owner.layerIndex;
        Move();
    }

    protected virtual void Engaged()
    {   if (target == null)
        {
            state = "idle";
            return;
        }
        if (target.GetComponent<Unit>()) gameObject.layer = 8;
        Attack(target);
    }

    protected virtual void Move()
    {
        Vector2 distance = owner.directionVector * speed * Time.deltaTime;
        gameObject.transform.Translate(distance);
    }

    protected virtual void Attack(Entity target)
    {
        GettAttackPointsMultiplier(type, target.type);
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
            state = "engaged";
        }

        GettAttackPointsMultiplier(type, target.type);
    }

    protected void GettAttackPointsMultiplier (string attackerType, string targetType)
    {
        float buffMultiplier = 3f;
        float debuffMultiplier = .33f;
        switch (attackerType)
        {
            case "distance":
                if (targetType == "polearms") attackPoints = Mathf.RoundToInt(basicAttackPoints * buffMultiplier);
                else if (targetType == "infantry") attackPoints = Mathf.RoundToInt((basicAttackPoints + 1) * debuffMultiplier);
                else attackPoints = basicAttackPoints;
                break;
            case "infantry":
                if (targetType == "distance") attackPoints = Mathf.RoundToInt(basicAttackPoints * buffMultiplier);
                else if (targetType == "cavalry") attackPoints = Mathf.RoundToInt((basicAttackPoints + 1) * debuffMultiplier);
                else attackPoints = basicAttackPoints;
                break;
            case "cavalry":
                if (targetType == "infantry") attackPoints = Mathf.RoundToInt(basicAttackPoints * buffMultiplier);
                else if (targetType == "polearms") attackPoints = Mathf.RoundToInt((basicAttackPoints + 1) * debuffMultiplier);
                else attackPoints = basicAttackPoints;
                break;
            case "polearms":
                if (targetType == "cavalry") attackPoints = Mathf.RoundToInt(basicAttackPoints * buffMultiplier);
                else if (targetType == "distance") attackPoints = Mathf.RoundToInt((basicAttackPoints + 1) * debuffMultiplier);
                else attackPoints = basicAttackPoints;
                break;
            default:
                attackPoints = basicAttackPoints;
                break;
        } 
    }
}
