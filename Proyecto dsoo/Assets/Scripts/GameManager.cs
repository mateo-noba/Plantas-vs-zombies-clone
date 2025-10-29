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

    public semillero semilleroScript;

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

        agregarSoles(0);
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
        if (Input.GetMouseButtonDown(0))
        {
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(r.origin, r.direction);
            if(hit.collider != null)
            {
                if(Casilla.transform.childCount < 1)
                {
                    Transform t = hit.collider.transform;
                    if(t.childCount == 0)
                    {
                        GameObject planta = Instantiate(semilleroScript.plantasUsar[1].gameObject, t.position, gameObject.transform.rotation);
                        planta.transform.SetParent(t);
                    }
                }
            }
        }
    }
}
