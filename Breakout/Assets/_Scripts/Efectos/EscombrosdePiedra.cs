using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EscombrosdePiedra : MonoBehaviour
{
    public GameObject Escombro;
    public Bola bola;
    private bool PiedraRota = false;
    private bool TemporizadorParaEliminar;
    private int Temporizador = 0;
    public List<GameObject> ListaDeEscombros;
    public Jugador jugador;
    void Start()
    {
        
    }

    public void PiedraEscombros()
    {
        PiedraRota = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (PiedraRota)
        {
            for (int i = 0; i < 6; i++)
            {
                GameObject tempGameObject = Instantiate<GameObject>(Escombro);
                Vector3 posicionBola= GameObject.FindGameObjectWithTag("Bola").transform.position;
                tempGameObject.transform.position = posicionBola;
                ListaDeEscombros.Add(tempGameObject);
                Temporizador = i * 90;
                if (i == 5)
                {
                    TemporizadorParaEliminar = true;
                    PiedraRota = false;
                }
            }
        }
        if (TemporizadorParaEliminar)
        {
            Temporizador--;
                if (Temporizador == 0 || jugador.ChoqueConEscombros)
                {
                    TemporizadorParaEliminar = false;          
                    foreach (GameObject escombro in ListaDeEscombros)
                    {
                        Destroy(escombro);
                    }
            }
            
        }

    }


}
