using UnityEngine;

public class Bloque_Metal: Bloque
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resistencia = 7;
    }

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
