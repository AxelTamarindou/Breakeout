using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;

public class Jugador : MonoBehaviour
{
    [SerializeField] public int limiteX = 23;
    [SerializeField] public float velocidadpaddle = 15f;
    public bool ChoqueConEscombros = false;
    public bool ObtenerPowerUp = false;
    

    Transform transform;
    Vector3 MousePos3D;
    Vector3 MousePos2D;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform = this.gameObject.transform;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bola")
        {
            Vector3 direccion = collision.contacts[0].point - transform.position;
            direccion = direccion.normalized;
            collision.rigidbody.linearVelocity = collision.gameObject.GetComponent<Bola>().velocidadBola * direccion;
        }

        if (collision.gameObject.tag == "Escombros")
        {
            ChoqueConEscombros = true;
        }
    }
    public void OnTriggerEnter(Collider PowerUp)
    {
        if (PowerUp.gameObject.tag == "PowerUp")
        {
            Debug.Log("La colision se dió correctamente con el powerup");
            ObtenerPowerUp = true;
        }
    }


    void Update()
    {
        MousePos2D = Input.mousePosition;
        MousePos2D.z = -Camera.main.transform.position.z;
        MousePos3D = Camera.main.ScreenToWorldPoint(MousePos2D);
        


        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.Translate(Vector3.down * velocidadpaddle * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.Translate(Vector3.up * velocidadpaddle * Time.deltaTime);
        //}
        

        transform.Translate(Input.GetAxis("Horizontal") * Vector3.down * velocidadpaddle * Time.deltaTime);

        Vector3 pos = transform.position;
        

        pos.x = MousePos3D.x;


        if (pos.x < -limiteX)
        {
            pos.x = -limiteX;
        }
        else if (pos.x > limiteX)
        {
            pos.x = limiteX;
        }
        transform.position = pos;
    }

    
    
}
