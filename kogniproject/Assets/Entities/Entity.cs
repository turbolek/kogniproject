using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Entity : MonoBehaviour {

    [SerializeField]
    protected int healthPoints;
    private int currentHealtPoints;
    public Image healthBar;
    //TODO get player object instead of bool
    public Player owner;

    protected virtual void Start()
    {
        gameObject.layer = owner.layerIndex;
        currentHealtPoints = healthPoints;
        Debug.Log(gameObject + " current health: " + currentHealtPoints);
    }

    public void TakeDamage(int damage)
    {
        Debug.Log(gameObject + " takes damage ");
        currentHealtPoints -= damage;
        Debug.Log(gameObject + " current health: " + currentHealtPoints);
        UpdateHealthBar();
        if (currentHealtPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log(gameObject + " dies ");
        Destroy(gameObject);
    }

    private void UpdateHealthBar()
    {
        healthBar.fillAmount = Mathf.Clamp(((float)currentHealtPoints / (float)healthPoints), 0f, 1f);       
    }
}
