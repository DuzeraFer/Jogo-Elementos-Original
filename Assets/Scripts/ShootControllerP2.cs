using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootControllerP2 : MonoBehaviour
{
    GameObject Balde1;
    GameObject Balde2;
    GameObject mato;
    GameObject fogo;
    float forca = 25f;
    Rigidbody2D rig;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

        rig.AddForce(transform.right * forca, ForceMode2D.Impulse);

        InvokeRepeating("DestruirTiro", 5f, 5f);

        mato = GameObject.Find("Mato");
        fogo = GameObject.Find("Fogo");
        Balde1 = GameObject.Find("Balde");
        Balde2 = GameObject.Find("Balde (1)");
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

        if (collision.gameObject.tag == "Balde" && Player2Controller.PowerUpAgua && Player2Controller.elemento == 1)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            Player2Controller.PowerUpAgua = false;
            DestruirTiro();
            if (collision.gameObject == Balde1)
                Destroy(mato);
            else
                Destroy(fogo);
        }
        else if (collision.gameObject.tag == "Balde")
            DestruirTiro();

        if (collision.gameObject.tag == "Pa" && Player2Controller.PowerUpTerra && Player2Controller.elemento == 2)
        {
            collision.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            Destroy(collision.transform.GetChild(0).gameObject);
            Player1Controller.PowerUpTerra = false;
            Player1Controller.PowUPAgua.SetActive(true);
            DestruirTiro();
        }
        else if (collision.gameObject.tag == "Pa")
            DestruirTiro();

        if (collision.gameObject.tag == "Vela" && Player2Controller.PowerUpFogo && Player2Controller.elemento == 3)
        {
            collision.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(collision.transform.GetChild(1).gameObject);
            Player2Controller.PowerUpFogo = false;
            Player1Controller.PowUPTerra.SetActive(true);
            Player1Controller.PowerTerra.SetActive(true);
            DestruirTiro();
        }
        else if (collision.gameObject.tag == "Vela")
            DestruirTiro();

        if (collision.gameObject.tag == "Balao" && Player2Controller.PowerUpAr && Player2Controller.elemento == 4)
        {            
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = -2;
            Player2Controller.PowerUpAr = false;
            DestruirTiro();
            Destroy(mato);
        }
        else if (collision.gameObject.tag == "Balao")
            DestruirTiro();
    }
}
