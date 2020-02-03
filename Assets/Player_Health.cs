using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player_Health : MonoBehaviour
{
    public static float health;
   

    void Update()
    {
        if (gameObject.transform.position.y < -10)
        {
            health = 1;
            if (health <= 0)
                Destroy(gameObject);
        }
       
    }
   
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Enemy"))
            health -= 0.1f;
    }
}
