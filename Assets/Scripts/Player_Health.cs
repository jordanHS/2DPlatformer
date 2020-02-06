using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player_Health : MonoBehaviour
{
    public static double health;
   

    void Update()
    {
        if (gameObject.transform.position.y < -0.01)
        {
            health = 0.2f;
            if (health <= 0)
            {

                Destroy(gameObject);
                SceneManager.LoadScene("Prototype_1");
            }
                
        }
        if (gameObject.transform.position.y < -10)
        {
            Die();
        }

    }
    void Die()
    {
        SceneManager.LoadScene("Prototype_1");

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Enemy"))
            health -= 0.03f;
    }
}
