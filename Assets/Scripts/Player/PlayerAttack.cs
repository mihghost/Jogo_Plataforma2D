using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startBtwAttack;

    public Transform attackPos;

    public float attackRange;

    public LayerMask whatIsEnemies;

    public int damage;

    void Update()
    {

        if (timeBtwAttack <= 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {

                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<GoblinEnemy>().TakeDamageEnemy(damage);
                }
            }
            timeBtwAttack = startBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    /*

          void OnDrawGizmosSelected()

    {

             Gizmos.color = Color.red;
             Gizmos.DrawWireSphere(attackPos.position, attackRange); 
    }
    */
}
