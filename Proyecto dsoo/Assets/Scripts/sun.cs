using UnityEngine;
using UnityEngine.UI;

public class sun : MonoBehaviour
{

    public int valor = 25;
    public float duracion = 20f;

    GameManager gameManager;

    private void Start()
    {
        
        Destroy(gameObject, duracion);
    }



    void Update()
    {
        
    }
}
