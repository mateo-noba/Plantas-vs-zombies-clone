using System.Collections;
using UnityEngine;

public class peashooter : MonoBehaviour
{
    public float frecuenciaDisparo = 1.5f;
    public GameObject Guisante;
    public Transform cañon;
    public float xMaxJardin = 5f;
    public LayerMask layerZombie;
    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(frecuenciaDisparo);

    
            float distanciaFinal = xMaxJardin - cañon.position.x;

            if(distanciaFinal <= 0)
            {
                distanciaFinal = 1f;
            }

            RaycastHit2D hit = Physics2D.Raycast(cañon.position, Vector3.right, distanciaFinal, layerZombie);

            if(hit.collider != null)
            {
                GameObject go = Instantiate(Guisante, cañon.position, Guisante.transform.rotation) as GameObject;
                Destroy(go, 5);
            }
        }
    }
}
