using UnityEngine;

public class pea : MonoBehaviour
{

    public int velocidad = 5;
    public int daño = 1;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * velocidad * Time.deltaTime;
    }
}
