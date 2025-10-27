using System;
using Unity.Mathematics;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject Casilla;
    public int filas = 5;
    public int columnas = 9;
    float separacionX = 1.4f;
    float separacionY = 1.6f;
    public Vector3 posicionInicial = new Vector3(0, 0, 0);

    public int soles = 50;

    public TextMeshProUGUI textoSoles;


    void Start()
    {
        for (int y = 0; y < filas; y++)
        {
            for (int x = 0; x < columnas; x++)
            {
                Vector3 posicion = posicionInicial + new Vector3(x * separacionX, y * separacionY, 0);
                Instantiate(Casilla, posicion, quaternion.identity, transform);
            }
        }

        actualizarSol();
    }

    public void agregarSoles(int cantidad)
    {
        soles += cantidad;
        Debug.Log(soles);
        actualizarSol();

    }

    public Boolean gastarSoles(int cantidad)
    {
        if (soles >= cantidad)
        {
            soles -= cantidad;
            actualizarSol();
            return true;
        }
        return false;
    }

    private void actualizarSol()
    {
        if(textoSoles != null)
        {
            textoSoles.text = soles.ToString();
        }
    }

    void Update()
    {
        
    }
}
