using System;
using Unity.Mathematics;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public int soles;

    public TextMeshProUGUI textoSoles;

    public TextMeshProUGUI textoTiempo;

    public float tiempoJugado = 0f;

    public TextMeshProUGUI textoPuntaje;

    public int puntajeActual = 0;

    public semillero semilleroScript;

    void Start()
    {
        agregarSoles(0);
    }

    public void agregarSoles(int cantidad)
    {
        soles += cantidad;
        actualizarSol();

    }

    public void gastarSoles(int cantidad)
    {
        if (soles >= cantidad)
        {
            soles -= cantidad;
            actualizarSol();
            return;
        }
        return;
    }

    private void actualizarSol()
    {
        if (textoSoles != null)
        {
            textoSoles.text = soles.ToString();
        }
    }

    public void actualizarPuntaje(int cantidad)
    {
        puntajeActual += cantidad;
        textoPuntaje.text = $"Puntaje: {puntajeActual}";
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(r.origin, r.direction);
            if (hit.collider != null)
            {
                //Debug.Log("Hice click sobre: " + hit.collider.name + " (Tag: " + hit.collider.tag + ")");

                if (hit.collider.CompareTag("Casilla"))
                {
                    Transform t = hit.collider.transform;
                    if (t.childCount == 0)
                    {
                        if (semilleroScript.numeroPlanta < 0 || semilleroScript.numeroPlanta > semilleroScript.plantasUsar.Count)
                        {
                            return;
                        }
                        CrearPlanta(semilleroScript.numeroPlanta, t);
                    }

                }
                else if (hit.collider.CompareTag("Sol"))
                {
                    agregarSoles(25);
                    Destroy(hit.collider.gameObject);
                }


            }
        }

        tiempoJugado += Time.deltaTime;
        int minutos = Mathf.FloorToInt(tiempoJugado / 60);
        int segundos = Mathf.FloorToInt(tiempoJugado % 60);
        textoTiempo.text = $"Tiempo: {minutos:00}:{segundos:00}";
    }
    void CrearPlanta(int numero, Transform t)
    {
        if (semilleroScript.plantasUsar[numero].precio > soles)
        {
            return;
        }
        if (numero < 0 || numero >= semilleroScript.plantasUsar.Count)
        {
            return; // si no hay planta válida seleccionada, no hagas nada
        }
        

        GameObject planta = Instantiate(semilleroScript.plantasUsar[numero].gameObject, t.position, gameObject.transform.rotation);
        planta.transform.SetParent(t);
        gastarSoles(semilleroScript.plantasUsar[numero].precio);
        semilleroScript.numeroPlanta = -1;

    }
}