using UnityEngine;
using TMPro;

public class Puntaje : MonoBehaviour
{
    public Transform transformPuntuaciónMáxima;
    public Transform transformPuntuación;
    public TMP_Text textoPuntajeAlto;
    public TMP_Text textoActual;
    public PuntajeAlto puntajeAltoSO;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transformPuntuación = GameObject.Find("Puntuación").transform;
        transformPuntuaciónMáxima = GameObject.Find("Puntuación máxima").transform;
        textoActual = transformPuntuación.GetComponent<TMP_Text>();
        textoPuntajeAlto = transformPuntuaciónMáxima.GetComponent<TMP_Text>();

        puntajeAltoSO.Cargar();
        textoPuntajeAlto.text = $"Puntuación máxima: {puntajeAltoSO.puntuaciónmáxima}";
        puntajeAltoSO.puntuación = 0;
    }

    private void FixedUpdate()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        textoActual.text = $"Puntuación: {puntajeAltoSO.puntuación}";

        if (puntajeAltoSO.puntuación > puntajeAltoSO.puntuaciónmáxima)
        {
            puntajeAltoSO.puntuaciónmáxima = puntajeAltoSO.puntuación;
            textoPuntajeAlto.text = $"Puntuación máxima: {puntajeAltoSO.puntuaciónmáxima}";
            puntajeAltoSO.Guardar();

            //PlayerPrefs.SetInt("Puntuación máxima", puntajeAltoSO.puntuación);
        }
    }

    public void AumentarPuntaje (int puntos)
    {
        puntajeAltoSO.puntuación += puntos;
        Debug.Log($"El puntaje aumento {puntos} puntos");
    }
}
