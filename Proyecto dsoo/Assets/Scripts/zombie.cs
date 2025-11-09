using UnityEngine;

public class zombie : MonoBehaviour
{

    public int vida;
    public float velocidad;
    public int puntos = 10;
    public LayerMask layerPlanta;
    public float cadencia = 1f;
    GameManager gameManagerScript;
    float cadAux = 0;

    void Awake()
    {
        if (gameManagerScript == null)
        {
            gameManagerScript = FindAnyObjectByType<GameManager>();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Guisante"))
        {
            vida--;
            Destroy(col.gameObject);
            if (vida <= 0)
            {
                Destroy(gameObject);
                gameManagerScript.actualizarPuntaje(puntos);
            }
        }
        
        if(col.CompareTag("Perder"))
        {
            Destroy(gameObject);
            gameManagerScript.perder = true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.left, 0.5f, layerPlanta);
        if(hit.collider != null)
        {
            cadAux += Time.deltaTime;
            if(cadAux >= cadencia)
            {
                cadAux = 0;
                hit.collider.SendMessage("morderPlanta");
            }
        }
        else
        {
            cadAux = 0;
            transform.position += Vector3.left * velocidad * Time.deltaTime;
        }
    }
}
