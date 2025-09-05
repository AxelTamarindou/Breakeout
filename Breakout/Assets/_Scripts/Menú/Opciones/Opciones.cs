using UnityEngine;

public class Opciones : PuntajePersistente
{
    public float velocidadBola = 30;
    public dificultad NivelDificultad = dificultad.facil;
    
    public enum dificultad
    {
        facil,
        normal,
        dificil
    }

    public void CambiarVelocidad(float nuevaVelocidad)
    {
        velocidadBola = nuevaVelocidad;
    }

    public void CambiarDificultad(int nuevaDificultad)
    {
        NivelDificultad = (dificultad)nuevaDificultad;
    }


}
