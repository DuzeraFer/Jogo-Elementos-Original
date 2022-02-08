using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player1Controller : MonoBehaviour
{
    [SerializeField]
    int velocidade;
    [SerializeField]
    int velocidadePulo;

    [SerializeField]
    int Agua = 0;
    [SerializeField]
    int Terra = 0;
    [SerializeField]
    int Fogo = 0;
    [SerializeField]
    int Ar = 0;

    [SerializeField]
    public static int Moedas = 0;
    //[SerializeField]
    //int Vida = 3;
    [SerializeField]
    GameObject spawnTiro;

    [SerializeField]
    GameObject prefabTiroAgua;
    [SerializeField]
    GameObject prefabTiroTerra;
    [SerializeField]
    GameObject prefabTiroFogo;
    [SerializeField]
    GameObject prefabTiroAr;
    [SerializeField]
    Animator animator;

    public Image Water, Earth, Fire, Air;

    public static int elementoSelect = 0;
    public static int elemento;

    public GameObject canvas;
    public static GameObject PowUPTerra;
    public static GameObject PowerTerra;
    public static GameObject PowUPAgua;

    public static bool PowerUpAgua = false;
    public static bool PowerUpTerra = false;
    public static bool PowerUpFogo = false;
    public static bool PowerUpAr = false;

    public bool chave = false;

    bool isGrounded = false;
    float groundCheckRadius = 0.2f;

    public Transform groundCheck;
    public LayerMask GroundType;

    Rigidbody2D Rigidbody2;

    // Start is called before the first frame update
    void Start()
    {
        PowUPTerra = GameObject.Find("PowerUpTerra");
        PowerTerra = GameObject.Find("Terra");
        PowUPAgua = GameObject.Find("PowerUpAgua (1)");
        Rigidbody2 = GetComponent<Rigidbody2D>();
        PowUPTerra.SetActive(false);
        PowerTerra.SetActive(false);
        PowUPAgua.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
            Jump();

        if (Input.GetKeyDown(KeyCode.V))
            Action();

        if (Input.GetAxis("HorizontalP1") < 0)
            transform.eulerAngles = new Vector3(0, 180, 0);
        if (Input.GetAxis("HorizontalP1") > 0)
            transform.eulerAngles = new Vector3(0, 0, 0);

        if (Input.GetKeyDown(KeyCode.C))
            canvas.GetComponent<HUD>().ActiveP1Element();

        if (GameObject.Find("ChangeElementMenuP1"))
        {
            canvas.GetComponent<HUD>().ChangeElementP1(elementoSelect);
            if (Input.GetKeyDown(KeyCode.B))
            {
                elementoSelect++;

                if (elementoSelect == 1 && Agua == 0)
                    elementoSelect++;
                if (elementoSelect == 2 && Terra == 0)
                    elementoSelect++;
                if (elementoSelect == 3 && Fogo == 0)
                    elementoSelect++;
                if (elementoSelect == 4 && Ar == 0)
                    elementoSelect++;

                if (elementoSelect == 5)
                {
                    elementoSelect = 0;
                }
            }
        }

        if (!GameObject.Find("ChangeElementMenuP1"))
        {
            if (elementoSelect == 0 && elemento != 0)
            {
                ChangeElement(0);
            }
            if (elementoSelect == 1 && Agua > 0 && elemento != 1)
            {
                ChangeElement(1);
            }
            if (elementoSelect == 2 && Terra > 0 && elemento != 2)
            {
                ChangeElement(2);
            }
            if (elementoSelect == 3 && Fogo > 0 && elemento != 3)
            {
                ChangeElement(3);
            }
            if (elementoSelect == 4 && Ar > 0 && elemento != 4)
            {
                ChangeElement(4);
            }
        }
      
        if (Input.GetButtonDown("Cancel"))
        {
            canvas.GetComponent<HUD>().ActivePanelMenu();
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, GroundType);

    }

    private void ChangeElement(int elementoChange)
    {
        if (elementoChange == 0)
        {
            elemento = 0;
            canvas.GetComponent<HUD>().ElementoP1.sprite = canvas.GetComponent<HUD>().NormalSprite;
            Debug.Log("P1 Trocou para elemento normal");
        }
        if (elementoChange == 1)
        {
            elemento = 1;
            Agua -= 1;
            canvas.GetComponent<HUD>().ElementoP1.sprite = canvas.GetComponent<HUD>().AguaSprite;
            if (Agua == 0)
                Water.color = new Color32(94, 94, 94, 255);
            Debug.Log("P1 Trocou para elemento agua");
        }
        if (elementoChange == 2)
        {
            elemento = 2;
            Terra -= 1;
            canvas.GetComponent<HUD>().ElementoP1.sprite = canvas.GetComponent<HUD>().TerraSprite;
            if (Terra == 0)
                Earth.color = new Color32(94, 94, 94, 255);
            Debug.Log("P1 Trocou para elemento terra");
        }
        if (elementoChange == 3)
        {
            elemento = 3;
            Fogo -= 1;
            canvas.GetComponent<HUD>().ElementoP1.sprite = canvas.GetComponent<HUD>().FogoSprite;
            if (Fogo == 0)
                Fire.color = new Color32(94, 94, 94, 255);
            Debug.Log("P1 Trocou para elemento fogo");
        }
        if (elementoChange == 4)
        {
            elemento = 4;
            Ar -= 1;
            canvas.GetComponent<HUD>().ElementoP1.sprite = canvas.GetComponent<HUD>().ArSprite;
            if (Ar == 0)
                Air.color = new Color32(94, 94, 94, 255);
            Debug.Log("P1 Trocou para elemento ar");
        }
    }

    private void Jump()
    {
        Rigidbody2.AddForce(Vector2.up * velocidadePulo, ForceMode2D.Impulse);
        animator.SetBool("isJumping", true);
    }

    public void NoChao()
    {
        animator.SetBool("isJumping", false);
    }

    private void MovePlayer()
    {
        Rigidbody2.velocity = new Vector2(Input.GetAxis("HorizontalP1") * velocidade, Rigidbody2.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(Input.GetAxis("HorizontalP1")));
    }

    private void Action()
    {
        if (elemento == 1)
        {
            Instantiate(prefabTiroAgua, spawnTiro.transform.position, transform.rotation);
        }
        else if (elemento == 2)
        {
            Instantiate(prefabTiroTerra, spawnTiro.transform.position, transform.rotation);
        }
        else if (elemento == 3)
        {
            Instantiate(prefabTiroFogo, spawnTiro.transform.position, transform.rotation);
        }
        else if (elemento == 4)
        {
            Instantiate(prefabTiroAr, spawnTiro.transform.position, transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Chave")
        {
            chave = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Tranca" && chave)
        {
            chave = false;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Tranca" && chave == false)
        {
            Debug.Log("Consiga a chave para conseguir passar de fase.");
        }

        if (collision.gameObject.tag == "PowerUpAgua" && PowerUpAgua != true && Agua != 0)
        {
            PowerUpAgua = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "PowerUpTerra" && PowerUpTerra != true && Terra != 0)
        {
            PowerUpTerra = true;
            Destroy(collision.gameObject);
        }
        
        if (collision.gameObject.tag == "PowerUpFogo" && PowerUpFogo != true && Fogo != 0)
        {
            PowerUpFogo = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "PowerUpAr" && PowerUpAr != true && Ar != 0)
        {
            PowerUpAr = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Moeda")
        {
            Moedas++;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "EsferaAgua" && Agua <= 4)
        {
            Agua += 2;
            Water.color = new Color32(255, 255, 255, 255);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "EsferaTerra" && Terra <= 4)
        {
            Terra += 2;
            Earth.color = new Color32(255, 255, 255, 255);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "EsferaFogo" && Fogo <= 4)
        {
            Fogo += 2;
            Fire.color = new Color32(255, 255, 255, 255);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "EsferaAr" && Ar <= 4)
        {
            Ar += 2;
            Air.color = new Color32(255, 255, 255, 255);
            Destroy(collision.gameObject);
        }
    }
}