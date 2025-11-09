using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class generadorZombie : MonoBehaviour
{
    public GameObject zombie;

    public float probabilidadSpawn = 0.3f; // Probabilidad base para esta fila
    public float variacionProbabilidad = 0.2f; // Variación aleatoria

    public controladorZombie controladorCentral;

    void Start()
    {
        controladorCentral = FindAnyObjectByType<controladorZombie>();
        
        // Si no hay controlador central, funciona independientemente
        if (controladorCentral == null)
        {
            StartCoroutine(GenerarZombieIndependiente());
        }
    }

    // Método para ser llamado por el controlador central
    public void SpawnZombieEnEstaFila()
    {
        Instantiate(zombie, transform.position, zombie.transform.rotation);
    }

    // Corrutina para funcionamiento independiente (backup)
    IEnumerator GenerarZombieIndependiente()
    {
        yield return new WaitForSeconds(Random.Range(10f, 20f));

        while (true)
        {
            float tiempoEspera = Random.Range(15f, 25f);
            yield return new WaitForSeconds(tiempoEspera);

            // Probabilidad variable para esta fila
            float probActual = probabilidadSpawn + Random.Range(-variacionProbabilidad, variacionProbabilidad);
            probActual = Mathf.Clamp(probActual, 0.1f, 0.8f); // Limitar entre 10% y 80%

            if (Random.Range(0f, 1f) < probActual)
            {
                SpawnZombieEnEstaFila();
            }
        }
    }
}
