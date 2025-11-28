using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public int soles;

    public TextMeshProUGUI textoSoles;

    public TextMeshProUGUI textoTiempo;

    public float tiempoJugado = 0f;

    public TextMeshProUGUI textoPuntaje;

    public TextMeshProUGUI textoPuntajeFinal;

    public int puntajeActual = 0;

    public semillero semilleroScript;

    public GameObject solPrefab;

    public bool perder;

    public GameObject panelPerder;

    public float minX = -3f;

    public float maxX = 7f;

    public float minY = -3f;

    public float maxY = 3f;

    public botonesMenu botonesScript;

    public GameObject botonIniciarSesion;
    public GameObject botonCuenta;

    bool modoPala = false;

    void Start()
    {
        agregarSoles(0);
        StartCoroutine(generarSolAleatorio());
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
        textoPuntajeFinal.text = $"Puntaje final: {puntajeActual}";
    }


    void Update()
    {
        if(botonesScript.juegoPausado != true && perder != true)
        {
            if (Input.GetMouseButtonDown(0))
            {

                Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(r.origin, r.direction);
                if (hit.collider != null)
                {
                    Debug.Log("Hice click sobre: " + hit.collider.name + " (Tag: " + hit.collider.tag + ")");

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
                    else if (hit.collider.CompareTag("Planta"))
                    {
                        if (modoPala)
                        {
                            Destroy(hit.collider.gameObject);
                            modoPala = false;
                            return;
                        }
                    }
                }
            }
        }

        tiempoJugado += Time.deltaTime;
        int minutos = Mathf.FloorToInt(tiempoJugado / 60);
        int segundos = Mathf.FloorToInt(tiempoJugado % 60);
        textoTiempo.text = $"Tiempo: {minutos:00}:{segundos:00}";

        if(perder == true)
        {
            panelPerder.SetActive(true);
            Time.timeScale = 0f;
            if(APIManager.instancia.logeado == true)
            {
                StartCoroutine(APIManager.instancia.EnviarPuntaje(puntajeActual));
            }
        }
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

        GameObject planta = Instantiate(semilleroScript.plantasUsar[numero].gameObject, t.position + Vector3.forward * -2f, gameObject.transform.rotation);
        planta.transform.SetParent(t);
        gastarSoles(semilleroScript.plantasUsar[numero].precio);
        semilleroScript.numeroPlanta = -1;
        semilleroScript.ActivarRecargaManual(numero);
    }

    IEnumerator generarSolAleatorio()
    {
        while (true)
        {
            float x = Random.Range(minX, maxX);

            float inicioY = maxY + 4f;

            Vector3 inicio = new Vector3(x, inicioY, -3);

            float finalY = Random.Range(minY, maxY);
            yield return new WaitForSeconds(Random.Range(6f, 12f));
            GameObject sol = Instantiate(solPrefab, inicio, Quaternion.identity);
            while (sol != null && sol.transform.position.y > finalY)
            {
                sol.transform.position += Vector3.down * 2f * Time.deltaTime;
                yield return null;
            }
        }
    }

    public void activarPala()
    {
        modoPala = true;
    }
}