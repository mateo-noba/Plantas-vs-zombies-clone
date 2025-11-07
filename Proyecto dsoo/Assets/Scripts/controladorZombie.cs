using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class controladorZombie : MonoBehaviour
{
    public generadorZombie[] generadoresFilas;
    public float tiempoEntreSpawnMin = 8f;
    public float tiempoEntreSpawnMax = 15f;
    public float tiempoReduccion = 0.05f;

    void Start()
    {
        StartCoroutine(ControlarSpawnZombies());
    }

    IEnumerator ControlarSpawnZombies()
    {
        // Espera inicial aleatoria
        yield return new WaitForSeconds(Random.Range(5f, 10f));

        while (true)
        {
            // Espera variable entre spawns
            float tiempoEspera = Random.Range(tiempoEntreSpawnMin, tiempoEntreSpawnMax);
            yield return new WaitForSeconds(tiempoEspera);

            // Elegir fila aleatoria para spawn
            int filaAleatoria = Random.Range(0, generadoresFilas.Length);
            
            // Probabilidad de spawn (no siempre spawnear)
            if (Random.Range(0f, 100f) < 80f) // 80% de probabilidad
            {
                generadoresFilas[filaAleatoria].SpawnZombieEnEstaFila();
            }

            // Aumentar dificultad gradualmente
            if (tiempoEntreSpawnMax > 4f)
            {
                tiempoEntreSpawnMax -= tiempoReduccion;
            }

            if (tiempoEntreSpawnMin > 2f)
            {
                tiempoEntreSpawnMin -= tiempoReduccion / 2f;
            }
        }
    }
}
