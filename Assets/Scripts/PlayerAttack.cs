using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack; // prvent player from spam attack
    public bool combat; // trigger for combat anim
    public Animator animator; // anim to combat
    public float startTimeBtwAttack; //default value
    public Transform attackPos; //circle position
    public LayerMask whatIsEnemies; //the only enemies are attacked instead of things like envi
    public float attackRange; //circle range
    public int damage;
    void Update() 
    {
        Attack();
        if (timeBtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.Tab))
            {
                timeBtwAttack = startTimeBtwAttack;
               
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position,
                attackRange, whatIsEnemies);

                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);   
                }
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }
    void FixedUpdate()
    {
        HandleAttacks();
        ResetValues();
    }
    public void HandleAttacks()
    {
        if (combat)
        {
            animator.SetTrigger("combat");
        }

    }
     void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            animator.SetTrigger("Combat");
        }
    }
    private void ResetValues()
    {
        combat = false;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

}
