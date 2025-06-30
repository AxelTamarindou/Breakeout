using UnityEngine;

public class Bloque : MonoBehaviour
{
    public int resistencia = 2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (resistencia <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public virtual void RebotarBola()
    {

    }
}
