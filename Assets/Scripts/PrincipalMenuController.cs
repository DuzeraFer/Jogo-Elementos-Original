using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PrincipalMenuController : MonoBehaviour
{
    [SerializeField]
    GameObject PrincipalPanel;
    [SerializeField]
    GameObject OpcoesPanel;
    [SerializeField]
    GameObject ComoJogarPanel;

    // Start is called before the first frame update
    void Start()
    {
        PrincipalPanel.SetActive(true);
        OpcoesPanel.SetActive(false);
        ComoJogarPanel.SetActive(false);
    }

    public void AbrirOpcoes()
    {
        PrincipalPanel.SetActive(false);
        OpcoesPanel.SetActive(true);
        ComoJogarPanel.SetActive(false);
    }

    public void AbrirPrincipal()
    {
        PrincipalPanel.SetActive(true);
        OpcoesPanel.SetActive(false);
        ComoJogarPanel.SetActive(false);
    }

    public void AbrirComoJogar()
    {
        PrincipalPanel.SetActive(false);
        OpcoesPanel.SetActive(false);
        ComoJogarPanel.SetActive(true);
    }

    public void SairMenu()
    {
        Application.Quit();
    }

    public void Jogar()
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
