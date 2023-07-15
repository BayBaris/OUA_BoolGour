using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float _health;
    public float _maxHealth = 100f;

    //Equal health to maxHealth on beginning

    private void Start()
    {
        _health = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Enemy Died");
    }
}
