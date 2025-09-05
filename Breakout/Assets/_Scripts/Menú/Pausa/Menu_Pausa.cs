using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Pausa : MonoBehaviour
{
    public GameObject menuPausa;
    public GameObject menuOpciones;
    public void MostrarMenuPausa()
    {
        menuPausa.SetActive(true);
        if (menuOpciones.activeInHierarchy) menuOpciones.SetActive(false);
    }

    public void OcultarMenuPausa()
    {
        menuPausa.SetActive(false);
    }

    public void RegresarAPantallaPrincipal()
    {
        SceneManager.LoadScene(0);
    }

    public void MostrarMenuOpciones()
    {
        menuPausa.SetActive(false);
        menuOpciones.SetActive(true);
    }    
}
