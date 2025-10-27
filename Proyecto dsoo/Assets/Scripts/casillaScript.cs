using Unity.Mathematics;
using UnityEngine;

public class casillaScript : MonoBehaviour
{

    public bool ocupado = false;

    public GameObject plantaActual;

    public void plantar(GameObject plantaPrefab)
    {
        if (!ocupado)
        {
            plantaActual = Instantiate(plantaPrefab, transform.position, quaternion.identity);
            ocupado = true;
        }
    }
}
