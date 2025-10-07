using JetBrains.Annotations;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Bloque : MonoBehaviour
{
    public int resistencia = 2;
    public UnityEvent AumentarPuntaje;
    public UnityEvent Particulas;
    public UnityEvent Mensaje;
    public Opciones dificultad;
    
    public void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.tag == "Bola")
        {
            RebotarBola(collision);
        }
    }
    void Start()
    {
        switch (dificultad.NivelDificultad)
        {
            case Opciones.dificultad.facil:
                Debug.Log("La dificultad es fácil, por lo que la resistencia de los bloques es estándar");
                break;

            case Opciones.dificultad.normal:
                resistencia = resistencia + 1;
                Debug.Log("La dificultad es normal, por lo que la resistencia de los bloques aumento en 1");
                break;

            case Opciones.dificultad.dificil:
                resistencia = resistencia + 3;
                Debug.Log("La dificultad es difícil, por lo que la resistencia de los bloques aumento en 3");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (resistencia <= 0)
        {
            Destroy(this.gameObject);
            AumentarPuntaje.Invoke();
            GameObject.FindGameObjectWithTag("AdminEfectos").GetComponent<Explosion_Bloque>().ExplosionBloque = this.gameObject.transform;
            Particulas.Invoke();
        }
    }
    public virtual void RebotarBola(Collision collision)
    {
        Vector3 direccion = collision.contacts[0].point - transform.position;
        direccion = direccion.normalized;
        collision.rigidbody.linearVelocity = collision.gameObject.GetComponent<Bola>().velocidadBola * direccion;
        resistencia--;
    }
}
