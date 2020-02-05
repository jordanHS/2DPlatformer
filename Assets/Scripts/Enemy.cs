using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health;
   
   
    private Animator anim;
    public GameObject bloodEffect;

    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    void Update()
    {

        if (health <= 0)

        {
            Instantiate(bloodEffect,transform.position, Quaternion.identity);
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