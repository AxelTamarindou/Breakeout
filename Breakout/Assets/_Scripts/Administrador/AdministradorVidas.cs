using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class AdministradorVidas : MonoBehaviour
{
    [SerializeField] public List<GameObject> vidas;
    public GameObject bolaPrefab;
    private Bola bolaScript;
    public GameObject MenuFinJuego;
    void Start()
    {
        Transform[] hijos = GetComponentsInChildren<Transform>();
        foreach (Transform hijo in hijos)
        {
            vidas.Add(hijo.gameObject);
        }

       
    }


    public void EliminarVida()
    {
        var objetoAEliminar = vidas[vidas.Count - 1];
        Destroy(objetoAEliminar);
        vidas.RemoveAt(vidas.Count - 1);
        Debug.Log($"Se removió {vidas.Count} vidas del contador de vidas");
        var bola = Instantiate(bolaPrefab) as GameObject;
        bolaScript = bola.GetComponent<Bola>();
        bolaScript.BolaDestruida.AddListener(this.EliminarVida);
        Debug.Log($"Vidas restantes:{vidas.Count}");
        if (vidas.Count <= 0)
        {
            MenuFinJuego.SetActive(true);
            return;
        }
    }
}
