using System.Collections;
using UnityEngine;

public class sunflower : MonoBehaviour
{
    public GameObject Sol;

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(6f, 12f));
            Instantiate(Sol, transform.position + Vector3.up * Random.Range(0f, 1f) + Vector3.left * Random.Range(-1f, 1f) + Vector3.forward * -3f, Sol.transform.rotation);
        }

    }
}
