using NUnit.Framework;
using System.Collections.Generic;
using System.Timers;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class Explosión_Bloque : MonoBehaviour
{
    public GameObject PrefabParticula;
    public List<GameObject> listaDeParticulas;
    public float FactorDeEscalamiento;
    public int numParticulas;
    public Bola bola;
    public bool CreaPartículas = false;
    public bool ExplosionBloque = false;
    
    void Start()
    {
        listaDeParticulas = new List<GameObject>();

    }

    public void Particulas()
    {
        CreaPartículas = true;
    }

    private void Update()
    {
        if (CreaPartículas)
        {
            Vector3 posicionBola = GameObject.FindGameObjectWithTag("Bloque").transform.position;
            GameObject tempGameObject = Instantiate<GameObject>(PrefabParticula);
            tempGameObject.name = "ParticulaNumero" + numParticulas;
            //Vector3 posicionBola = GameObject.FindGameObjectWithTag("Bloque").transform.position;
            posicionBola.z += 5;
            //tempGameObject.transform.position = posicionBola;
            listaDeParticulas.Add(tempGameObject);
            //Debug.Log($"Se borraran {listaDeParticulas.Count} partículas");
        }

        if (listaDeParticulas.Count >= 50)
        {
            CreaPartículas = false;
            List<GameObject> particulasParaBorrar = new List<GameObject>();
            Debug.Log("Se alcanzó el limite de particulas, por lo que se comenzaran a borrar");
            foreach (GameObject particl in listaDeParticulas)
            {
                float scale = particl.transform.localScale.x;
                scale *= FactorDeEscalamiento;
                Debug.Log(scale);
                particl.transform.localScale = Vector3.one * scale;

                if (scale <= 0.1)
                {
                    particulasParaBorrar.Add(particl);
                }
            }
            Debug.Log($"Las particulas en lista que se van a borrar son {particulasParaBorrar.Count}");
            foreach (GameObject ParticulaDestruida in particulasParaBorrar)
            {
                listaDeParticulas.Remove(ParticulaDestruida);
                Destroy(ParticulaDestruida);
            }
        }

        //if (ExplosionBloque)
        //{
        //    GameObject tempGameObject = Instantiate<GameObject>(PrefabParticula);
        //    Vector3 posicionBola = GameObject.FindGameObjectWithTag("Bloque").transform.position;
        //    listaDeParticulas.Add(tempGameObject);
        //    List<GameObject> particulasParaBorrar = new List<GameObject>();

        //    foreach (GameObject part in listaDeParticulas)
        //    {
        //        float scale = part.transform.localScale.x;
        //        scale *= FactorDeEscalamiento;
        //        Debug.Log(scale);
        //        part.transform.localScale = Vector3.one * scale;

        //        if (scale <= 0.1)
        //        {
        //            particulasParaBorrar.Add(part);
        //        }
        //    }

        //    foreach (GameObject part in particulasParaBorrar)
        //    {
        //        listaDeParticulas.Remove(part);
        //        Destroy(part);
        //    }
        //}
    }

}

