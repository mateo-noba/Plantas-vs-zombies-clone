using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class sun : MonoBehaviour
{

    public int valor = 25;
    public float duracion = 20f;

    public GameManager gameManager;

    public GameObject solPrefab;

    private void Start()
    {

        Destroy(gameObject, duracion);
    }
}
