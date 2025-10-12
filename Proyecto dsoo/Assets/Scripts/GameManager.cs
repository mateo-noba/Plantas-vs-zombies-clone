using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Casilla;
    public int filas = 5;
    public int columnas = 9;
    float separacionX = 1.4f;
    float separacionY = 1.6f;
    public Vector3 posicionInicial = new Vector3(0,0,0);


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int y = 0; y < filas; y++)
        {
            for(int x = 0; x < columnas; x++)
            {
                Vector3 posicion = posicionInicial + new Vector3(x * separacionX, y * separacionY, 0);
                Instantiate(Casilla, posicion, quaternion.identity, transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
