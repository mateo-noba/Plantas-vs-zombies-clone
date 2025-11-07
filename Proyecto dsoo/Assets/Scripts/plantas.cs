using UnityEngine;

public class plantas : MonoBehaviour
{
    public Sprite semillaPlanta;
    public int precio;
    public int vida;

    public float tiempoRecarga = 0f;


    void morderPlanta()
    {
        vida--;
        if(vida <= 0)
        {
            Destroy(gameObject);
        }
    }
}