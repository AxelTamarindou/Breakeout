using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bola : MonoBehaviour
{
    public bool isGameStarted;
    public Opciones opciones;
    [SerializeField] public float velocidadBola;
    [SerializeField] public int vidasBola = 3;
    Vector3 ultimaPosicion = Vector3.zero;
    Vector3 direccion = Vector3.zero;
    Rigidbody rigidbody;
    private Control_Bordes control;
    public UnityEvent BolaDestruida;
    public Jugador jugador;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        control = GetComponent<Control_Bordes>();
    }


    void Start()
    {
        isGameStarted = false;
        Vector3 posicionInicial = GameObject.FindGameObjectWithTag("Jugador").transform.position;
        posicionInicial.y += 3;
        this.transform.position = posicionInicial;
        this.transform.SetParent(GameObject.FindGameObjectWithTag("Jugador").transform);
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        velocidadBola = opciones.velocidadBola;
        if (control.salioAbajo || jugador.ChoqueConEscombros)
        {
            BolaDestruida.Invoke();
            Destroy(this.gameObject);
            Debug.Log("El jugador perdió una vida");
            jugador.ChoqueConEscombros = false;
        }


        if (control.salioArriba)
        {
            direccion = transform.position - ultimaPosicion;
            Debug.Log("La bola tocó el borde superior");
            direccion.y *= -1;
            direccion = direccion.normalized;
            rigidbody.linearVelocity = velocidadBola * direccion;
            control.salioArriba = false;
            control.enabled = false;
            Invoke("HabilitarControl", 0.5f);
        }

        if (control.salioDerecha)
        {
            direccion = transform.position - ultimaPosicion;
            Debug.Log("La bola tocó el borde derecho");
            direccion.x *= -1;
            direccion = direccion.normalized;
            rigidbody.linearVelocity = velocidadBola * direccion;
            control.salioDerecha = false;
            control.enabled = false;
            Invoke("HabilitarControl", 0.5f);
        }

        if (control.salioIzquierda)
        {
            direccion = transform.position - ultimaPosicion;
            Debug.Log("La bola tocó el borde izquierdo");
            direccion.x *= -1;
            direccion = direccion.normalized;
            rigidbody.linearVelocity = velocidadBola * direccion;
            control.salioIzquierda = false;
            control.enabled = false;
            Invoke("HabilitarControl", 0.5f);

        }

        if (Input.GetKey(KeyCode.Space) || Input.GetButton("Submit"))
        {
            if (!isGameStarted)
            {
                isGameStarted = true;
                this.transform.SetParent(null);
                GetComponent<Rigidbody>().linearVelocity = velocidadBola * Vector3.up;
            }
        }
    }

    private void HabilitarControl()
    {
        control.enabled = true;
    }

    private void FixedUpdate()
    {
        ultimaPosicion = transform.position;
    }

    public void LateUpdate()
    {
        if (direccion != Vector3.zero) direccion = Vector3.zero;
    }
}
