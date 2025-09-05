using UnityEngine;
using UnityEngine.Events;

public class Bloque_Vidrio : Bloque
{
    public UnityEvent PowerUp;
    void Start()
    {
        resistencia = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (resistencia <= 0)
        {
            Destroy(this.gameObject);
            AumentarPuntaje.Invoke();
            PowerUp.Invoke();
        }
    }
    public override void RebotarBola(Collision collision)
    {
        base.RebotarBola(collision);
    }
}
