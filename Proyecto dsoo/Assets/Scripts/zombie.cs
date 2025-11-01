using UnityEngine;

public class zombie : MonoBehaviour
{

    public int vida;
    public int velocidad;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Gisante"))
        {
            vida--;
            Destroy(col.gameObject);
            if(vida <= 0)
            {
                Destroy(gameObject);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
