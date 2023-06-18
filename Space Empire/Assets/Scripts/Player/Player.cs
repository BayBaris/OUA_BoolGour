using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Base")]
    private float _health;
    public float _maxHealth = 10;

    //private bool isAlive = true;

    //Equal health to maxHealth on beginning

    private void Start()
    {
        _health = _maxHealth;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")){

            _health -= 10;
            if(_health <= 0) 
            {
                Destroy(gameObject);
                SceneManager.LoadScene(0);
            }
        }
    }
}
