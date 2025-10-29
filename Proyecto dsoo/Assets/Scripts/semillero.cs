using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class semillero : MonoBehaviour
{
    public List<plantas> plantasUsar;

    public GameObject semilleroPlantas;
    public GameObject cartaPlantaPrefab;
    void Start()
    {
        for(int i = 0; i < plantasUsar.Count; i++)
        {
            GameObject crearCarta = Instantiate(cartaPlantaPrefab) as GameObject;
            crearCarta.transform.SetParent(semilleroPlantas.transform);
            crearCarta.transform.position = Vector3.zero;
            crearCarta.transform.localScale = Vector3.one;

            Image cartaImagen = crearCarta.GetComponent<Image>();
            cartaImagen.sprite = plantasUsar[i].semillaPlanta;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
