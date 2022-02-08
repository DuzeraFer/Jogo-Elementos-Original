using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textCoinP1;
    [SerializeField]
    TextMeshProUGUI textCoinP2;

    [SerializeField]
    GameObject panelMenu;

    [SerializeField]
    public GameObject ChangeElementMenuP1;
    [SerializeField]
    public GameObject ChangeElementMenuP2;
    public Image ElementoP1;
    public Image ElementoP2;
    public Sprite NormalSprite, AguaSprite, TerraSprite, FogoSprite, ArSprite;

    // Start is called before the first frame update
    void Start()
    {
        panelMenu.SetActive(false);

        ChangeElementMenuP1.SetActive(false);
        ChangeElementMenuP2.SetActive(false);
    }

    public void ActiveP1Element()
    {
        ChangeElementMenuP1.SetActive(!ChangeElementMenuP1.activeSelf);
        
        if (ChangeElementMenuP1.activeSelf == true)
        {
            Time.timeScale = 0.5f;          
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void ChangeElementP1(int elementoSelect)
    {
        GameObject NormalPanel = ChangeElementMenuP1.transform.GetChild(0).gameObject;
        GameObject WaterPanel = ChangeElementMenuP1.transform.GetChild(1).gameObject; 
        GameObject EarthPanel = ChangeElementMenuP1.transform.GetChild(2).gameObject; 
        GameObject FirePanel = ChangeElementMenuP1.transform.GetChild(3).gameObject; 
        GameObject AirPanel = ChangeElementMenuP1.transform.GetChild(4).gameObject;

        Image Normal = NormalPanel.GetComponent<Image>();
        Image Water = WaterPanel.GetComponent<Image>();
        Image Earth = EarthPanel.GetComponent<Image>();
        Image Fire = FirePanel.GetComponent<Image>();
        Image Air = AirPanel.GetComponent<Image>();

        switch (elementoSelect)
        {
            case 0:
                Normal.color = new Color32(255, 0, 0, 100);
                Water.color = new Color32(255, 255, 255, 100);                
                Earth.color = new Color32(255, 255, 255, 100);
                Fire.color = new Color32(255, 255, 255, 100);
                Air.color = new Color32(255, 255, 255, 100);
                break;
            case 1:
                Normal.color = new Color32(255, 255, 255, 100);
                Water.color = new Color32(255, 0, 0, 100);
                Earth.color = new Color32(255, 255, 255, 100);
                Fire.color = new Color32(255, 255, 255, 100);
                Air.color = new Color32(255, 255, 255, 100);
                break;
            case 2:
                Normal.color = new Color32(255, 255, 255, 100);
                Water.color = new Color32(255, 255, 255, 100);
                Earth.color = new Color32(255, 0, 0, 100);
                Fire.color = new Color32(255, 255, 255, 100);
                Air.color = new Color32(255, 255, 255, 100);
                break;
            case 3:
                Normal.color = new Color32(255, 255, 255, 100);
                Water.color = new Color32(255, 255, 255, 100);
                Earth.color = new Color32(255, 255, 255, 100);
                Fire.color = new Color32(255, 0, 0, 100);
                Air.color = new Color32(255, 255, 255, 100);
                break;
            case 4:
                Normal.color = new Color32(255, 255, 255, 100);
                Water.color = new Color32(255, 255, 255, 100);
                Fire.color = new Color32(255, 255, 255, 100);
                Earth.color = new Color32(255, 255, 255, 100);
                Air.color = new Color32(255, 0, 0, 100);
                break;
            default:
                break;
        }
    }

    public void ActiveP2Element()
    {
        ChangeElementMenuP2.SetActive(!ChangeElementMenuP2.activeSelf);

        if (ChangeElementMenuP2.activeSelf == true)
        {
            Time.timeScale = 0.5f;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void ChangeElementP2(int elementoSelect)
    {
        GameObject NormalPanel = ChangeElementMenuP2.transform.GetChild(0).gameObject;
        GameObject WaterPanel = ChangeElementMenuP2.transform.GetChild(1).gameObject;
        GameObject EarthPanel = ChangeElementMenuP2.transform.GetChild(2).gameObject;
        GameObject FirePanel = ChangeElementMenuP2.transform.GetChild(3).gameObject;
        GameObject AirPanel = ChangeElementMenuP2.transform.GetChild(4).gameObject;

        Image Normal = NormalPanel.GetComponent<Image>();
        Image Water = WaterPanel.GetComponent<Image>();
        Image Earth = EarthPanel.GetComponent<Image>();
        Image Fire = FirePanel.GetComponent<Image>();
        Image Air = AirPanel.GetComponent<Image>();

        switch (elementoSelect)
        {
            case 0:
                Normal.color = new Color32(255, 0, 0, 100);
                Water.color = new Color32(255, 255, 255, 100);
                Earth.color = new Color32(255, 255, 255, 100);
                Fire.color = new Color32(255, 255, 255, 100);
                Air.color = new Color32(255, 255, 255, 100);
                break;
            case 1:
                Normal.color = new Color32(255, 255, 255, 100);
                Water.color = new Color32(255, 0, 0, 100);
                Earth.color = new Color32(255, 255, 255, 100);
                Fire.color = new Color32(255, 255, 255, 100);
                Air.color = new Color32(255, 255, 255, 100);
                break;
            case 2:
                Normal.color = new Color32(255, 255, 255, 100);
                Water.color = new Color32(255, 255, 255, 100);
                Earth.color = new Color32(255, 0, 0, 100);
                Fire.color = new Color32(255, 255, 255, 100);
                Air.color = new Color32(255, 255, 255, 100);
                break;
            case 3:
                Normal.color = new Color32(255, 255, 255, 100);
                Water.color = new Color32(255, 255, 255, 100);
                Earth.color = new Color32(255, 255, 255, 100);
                Fire.color = new Color32(255, 0, 0, 100);
                Air.color = new Color32(255, 255, 255, 100);
                break;
            case 4:
                Normal.color = new Color32(255, 255, 255, 100);
                Water.color = new Color32(255, 255, 255, 100);
                Fire.color = new Color32(255, 255, 255, 100);
                Earth.color = new Color32(255, 255, 255, 100);
                Air.color = new Color32(255, 0, 0, 100);
                break;
            default:
                break;
        }
    }

    public void ActivePanelMenu()
    {
        panelMenu.SetActive(!panelMenu.activeSelf);

        if (panelMenu.activeSelf == true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void MenuPrincipal()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        textCoinP1.text = "= " + Player1Controller.Moedas.ToString();

        textCoinP2.text = "= " + Player2Controller.Moedas.ToString();
    }
}
