using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class semillero : MonoBehaviour
{
    public List<plantas> plantasUsar;

    public GameObject semilleroPlantas;
    public GameObject cartaPlantaPrefab;
    public int numeroPlanta = -1;
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

            Button btn = crearCarta.GetComponent<Button>();
            int j = i;
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(() => { numeroPlanta = j; });
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
