using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.Events;

public class Muestra_Eventos : MonoBehaviour
{
    public event EventHandler EnCasoDeEspacioPresionado;
    public UnityEvent MiEventoUnity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EnCasoDeEspacioPresionado += EventoEscuchado;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EnCasoDeEspacioPresionado?.Invoke(this, EventArgs.Empty);
            MiEventoUnity.Invoke();
        }
    }
    
    public void EventoUnityDisparado()
    {
        Debug.Log("El evento Unity se disparó correctamente");
    }
    public void EventoEscuchado(object sender, EventArgs e)
    {
        Debug.Log("El evento se escuchó correctamente");
    }
}
