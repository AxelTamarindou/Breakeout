using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUpVelocidad : MonoBehaviour
{
    public GameObject PowerUp;
    public Jugador jugador;
    public Bola bola;
    public GameObject PrefabParticula;
    public List<GameObject> listaDeParticulas;
    public float FactorDeEscalamiento;
    public int numParticulas;
    public void PowerUpVelocidadBola()
    {
        GameObject powerup = Instantiate<GameObject>(PowerUp);
        Vector3 Posicionpowerup = GameObject.FindGameObjectWithTag("BloqueCristal").transform.position;
        powerup.transform.position = Posicionpowerup;
    }

    // Update is called once per frame
    void Update()
    {
        if (jugador.ObtenerPowerUp)
        {
            GameObject tempGameObject = Instantiate<GameObject>(PrefabParticula);
            tempGameObject.name = "ParticulaNumero" + numParticulas;
            Vector3 posicionBola = GameObject.FindGameObjectWithTag("Bola").transform.position;
            tempGameObject.transform.position = posicionBola;
            listaDeParticulas.Add(tempGameObject);
            Debug.Log($"Se borraran {listaDeParticulas.Count} partículas");
            bola.velocidadBola = 25;
        }

        if (listaDeParticulas.Count >= 100)
        {
            jugador.ObtenerPowerUp = false;
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
    }
    
}
