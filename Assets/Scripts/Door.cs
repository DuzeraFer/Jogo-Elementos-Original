using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    int Personagens = 0;
    int actualScene;

    // Start is called before the first frame update
    void Start()
    {
        actualScene = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (Personagens > 1)
        {
            SceneManager.LoadScene(actualScene + 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameObject.Find ("Tranca") == null)
        {
            if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2")
            {
                Destroy(collision.gameObject);
                Personagens += 1;
            }
        }            
    }
}
