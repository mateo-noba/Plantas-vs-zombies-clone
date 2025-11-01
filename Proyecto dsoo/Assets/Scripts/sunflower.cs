using System.Collections;
using UnityEngine;

public class sunflower : MonoBehaviour
{

    public float frecuenciaSol = 1;
    public GameObject Sol;

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(frecuenciaSol);
            Instantiate(Sol, transform.position + Vector3.up * Random.Range(0f, 1f) + Vector3.left * Random.Range(-1f, 1f), Sol.transform.rotation);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
