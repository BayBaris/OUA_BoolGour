using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    private bool isMeleeAttack;
    [Header("Stats")]
    public Transform attackPoint;
    public float baseDamage = 2f;
    public float attackRange = 0.5f;

    [Header("AttackRate")]
    //Karakteri vuruþ sýklýðýný belirlemek için kullanýlacak.
    public float attackRate = 2f;
    private float nextAttackTime = 0f;


    //public Animator _anim;
    public LayerMask enemyLayers;

    private void Update()
    {
        if(Time.time > nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                MeleeAttack();
                nextAttackTime = Time.time * 1f / attackRate;
            }

        }
    }
    private void MeleeAttack()
    {
        //_anim.SetTrigger("Attack");

        Collider2D[] hitEnemies =  Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {

            enemy.GetComponent<Enemy>().TakeDamage(baseDamage);
            Debug.Log("Health: " + enemy.GetComponent<Enemy>()._health);
        }
    }



    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
