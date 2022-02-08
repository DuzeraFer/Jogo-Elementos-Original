using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootControllerP1 : MonoBehaviour
{
    GameObject mato;
    float forca = 25f;
    Rigidbody2D rig;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

        rig.AddForce(transform.right * forca, ForceMode2D.Impulse);

        InvokeRepeating("DestruirTiro", 5f, 5f);

        mato = GameObject.Find("Mato");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestruirTiro()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            DestruirTiro();
        }

        if (collision.gameObject.tag == "Balde" && Player1Controller.PowerUpAgua && Player1Controller.elemento == 1)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            Player1Controller.PowerUpAgua = false;
            DestruirTiro();
            Destroy(mato);
        }
        else if (collision.gameObject.tag == "Balde")
            DestruirTiro();

        if (collision.gameObject.tag == "Pa" && Player1Controller.PowerUpTerra && Player1Controller.elemento == 2)
        {
            collision.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            Destroy(collision.transform.GetChild(0).gameObject);
            Player1Controller.PowerUpTerra = false;
            Player1Controller.PowUPAgua.SetActive(true);
            DestruirTiro();
        }
        else if (collision.gameObject.tag == "Pa")
            DestruirTiro();

        if (collision.gameObject.tag == "Vela" && Player1Controller.PowerUpFogo && Player1Controller.elemento == 3)
        {
            collision.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(collision.transform.GetChild(1).gameObject);
            Player1Controller.PowerUpFogo = false;
            Player1Controller.PowUPTerra.SetActive(true);
            Player1Controller.PowerTerra.SetActive(true);
            DestruirTiro();
        }
        else if (collision.gameObject.tag == "Vela")
            DestruirTiro();

        if (collision.gameObject.tag == "Balao" && Player1Controller.PowerUpAr && Player1Controller.elemento == 4)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = -2;
            Player1Controller.PowerUpAr = false;
            DestruirTiro();
        }
        else if (collision.gameObject.tag == "Balao")
            DestruirTiro();
    }
}
