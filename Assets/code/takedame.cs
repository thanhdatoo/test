using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class takedame : MonoBehaviour
{
    public Animator animamtor;
    public Transform attackPoint;
    public float attackRange=0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 20;
    public float attackRate = 2f;
   // public float NextAttacktime = 0f;
    // Update is called once per frame
    void Update()
    {
       // if(Time.time >= NextAttacktime)
        //{
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                //NextAttacktime  =  Time.time + 1f /attackRate;   
            }
        if (Input.GetMouseButtonDown(1))
        {
            Attack();
        }
        // }

    }
    void Attack()
    {
        animamtor.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<enemyHealth>().TakeDamage(attackDamage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
