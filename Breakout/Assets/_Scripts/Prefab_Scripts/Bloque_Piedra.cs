using UnityEngine;
using UnityEngine.Events;

public class Bloque_Piedra : Bloque
{
    public UnityEvent Escombros;
    void Start()
    {
        resistencia = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (resistencia <= 0)
        {
            Destroy(this.gameObject);
            AumentarPuntaje.Invoke();
            Escombros.Invoke();
        }
    }
    public override void RebotarBola(Collision collision)
    {
        base.RebotarBola(collision);
    }
}
