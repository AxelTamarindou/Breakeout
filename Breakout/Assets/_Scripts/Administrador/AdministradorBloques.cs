using Unity.VisualScripting;
using UnityEngine;

public class AdministradorBloques : MonoBehaviour
{
    public GameObject MenuFinNivel;

    private void Update()
    {
        if (transform.childCount == 0)
        {
            MenuFinNivel.SetActive(true);
        }
    }

}
