using UnityEngine;

public class pea : MonoBehaviour
{

    public int velocidad = 5;
    public int daño = 1;

    void Update()
    {
        transform.position += Vector3.right * velocidad * Time.deltaTime;
    }
}
