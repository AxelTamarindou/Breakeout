using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.Events;

public class Bloque : MonoBehaviour
{
    public int resistencia = 2;
    public UnityEvent AumentarPuntaje;
    public UnityEvent Particulas;
    public UnityEvent Mensaje;
    
    public void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.tag == "Bola")
        {
            RebotarBola(collision);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (resistencia <= 0)
        {
            Destroy(this.gameObject);
            AumentarPuntaje.Invoke();
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
