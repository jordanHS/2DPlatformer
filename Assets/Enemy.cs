using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health;
   
   
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isRunning", true);
    }

    void Update()
    {

        if (health <= 0)

        {
            Debug.Log("hp loss!");
            Destroy(gameObject);
        }

    }

    public void TakeDamage(int damage)

    {
        health -= damage;
        Debug.Log("damage taken!");
    }

}