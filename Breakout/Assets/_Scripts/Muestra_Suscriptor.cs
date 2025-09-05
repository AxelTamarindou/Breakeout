using System.ComponentModel.Design;
using UnityEngine;
using System;

public class Muestra_Suscriptor : MonoBehaviour
{
    Muestra_Eventos subscriptor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        subscriptor = GetComponent<Muestra_Eventos>();
        subscriptor.EnCasoDeEspacioPresionado += MensajeEscuchadoPorElSubscriptor;
    }

    // Update is called once per frame
    private void MensajeEscuchadoPorElSubscriptor(object sender, EventArgs e)
    {
        Debug.Log("El evento ha sido escuchado desde otra clase");
    }
}
