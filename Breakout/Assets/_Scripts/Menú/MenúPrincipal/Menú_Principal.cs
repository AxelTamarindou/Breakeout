using UnityEngine;
using UnityEngine.SceneManagement;

public class Menú_Principal : MonoBehaviour
{
    public GameObject MenuOpciones;
    public GameObject MenuInicial;
    public void IniciarJuego()
    {
        SceneManager.LoadScene(1);
    }

    public void FinalizarJuego()
    {
        Application.Quit();
    }
   
    public void MostrarOpciones()
    {
        MenuInicial.SetActive(false);
        MenuOpciones.SetActive(true);
    }

    public void MostrarMenuInicial()
    {
        MenuOpciones.SetActive(false);
        MenuInicial.SetActive(true);    
    }
}
