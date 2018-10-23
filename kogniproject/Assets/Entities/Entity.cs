using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Entity : MonoBehaviour {

    [SerializeField]
    protected int healthPoints;
    private int currentHealtPoints;
    public Image healthBar;
    public Player owner;
    [SerializeField]
    public string type = "default";

    protected virtual void Start()
    {
        gameObject.layer = owner.layerIndex;
        currentHealtPoints = healthPoints;
    }

    public void TakeDamage(int damage)
    {
        currentHealtPoints -= damage;
        UpdateHealthBar();
        if (currentHealtPoints <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
       if (gameObject != null) Destroy(gameObject);
    }

    private void UpdateHealthBar()
    {
        healthBar.fillAmount = Mathf.Clamp(((float)currentHealtPoints / (float)healthPoints), 0f, 1f);       
    }
}
