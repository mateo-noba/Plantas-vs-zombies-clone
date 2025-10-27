using UnityEngine;

public class sun : MonoBehaviour
{

    public int valor = 25;
    public float duracion = 10f;

    private void Start()
    {
        //Destroy(gameObject, duracion);
    }

    public void OnMouseDown()
    {
        Debug.Log("Click");
        GameManager gameManager = FindAnyObjectByType<GameManager>();

        if (gameManager != null)
        {
            gameManager.agregarSoles(valor);
            Destroy(gameObject);

        }
    }

    public void OnMouseOver()
    {
        Debug.Log("Arriba");
    }

    void Update()
    {
        
    }
}
