using UnityEngine;

public class Jugador : MonoBehaviour
{
    [SerializeField] public int limiteX = 23;
    [SerializeField] public float velocidadpaddle = 15f;

    Transform transform;
    Vector3 MousePos3D;
    Vector3 MousePos2D;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform = this.gameObject.transform;
    }

    // Update is called once per frame
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
