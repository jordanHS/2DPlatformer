using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinFlag : MonoBehaviour
{
    public GameObject youWinText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            slowTime(.07f);
            youWinText.SetActive(true);
        }
    }

    void slowTime(float speed)      
    { 
        Time.timeScale = speed;
        StartCoroutine(Reset(.2f));
    }

    private IEnumerator Reset(float reset)
    {
        yield return new WaitForSeconds (reset);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Prototype_1");
    }

}
