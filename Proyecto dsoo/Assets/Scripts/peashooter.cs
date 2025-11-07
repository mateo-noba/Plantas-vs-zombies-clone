using System.Collections;
using UnityEngine;

public class peashooter : MonoBehaviour
{
    public float frecuenciaDisparo = 1.5f;
    public GameObject Guisante;
    public Transform cañon;
    public LayerMask layerZombie;

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(frecuenciaDisparo);

            RaycastHit2D hit = Physics2D.Raycast(cañon.position, Vector3.right, 13, layerZombie);

            if(hit.collider != null)
            {
                GameObject go = Instantiate(Guisante, cañon.position, Guisante.transform.rotation) as GameObject;
                Destroy(go, 5);
            }
        }
    }
}
