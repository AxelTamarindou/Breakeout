using UnityEngine;
using UnityEngine.Events;

public class Bloque_Madera : Bloque
{

    // Update is called once per frame
    void Update()
    {
        if (resistencia <= 0)
        {
            Destroy(this.gameObject);
            AumentarPuntaje.Invoke();
        }
    }
    public override void RebotarBola(Collision collision)
    {
            base.RebotarBola(collision);
    }
}
