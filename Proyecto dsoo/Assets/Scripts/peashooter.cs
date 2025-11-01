using System.Collections;
using UnityEngine;

public class peashooter : MonoBehaviour
{
    public float frecuenciaDisparo = 3;
    public GameObject Guisante;
    public Transform cañon;
    public LayerMask layerZombie;

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(frecuenciaDisparo);

            RaycastHit2D hit = Physics2D.Raycast(cañon.position, Vector3.right, 13, layerZombie);
            Debug.DrawRay(cañon.position, Vector3.right * 13);

            if(hit.collider != null)
            {
                print(hit.collider.name);
                GameObject go = Instantiate(Guisante, cañon.position, Guisante.transform.rotation) as GameObject;
                Destroy(go, 5);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
