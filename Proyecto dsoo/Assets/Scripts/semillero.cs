using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class semillero : MonoBehaviour
{
    public List<plantas> plantasUsar;

    public GameObject semilleroPlantas;
    public GameObject cartaPlantaPrefab;
    public int numeroPlanta = -1;

    public Button btn;

    GameObject crearCarta;

    private Dictionary<int, float> tiempoRestante = new Dictionary<int, float>();
    private List<Button> botones = new List<Button>();
    private List<Image> overlays = new List<Image>();
    
    
    void Start()
    {
        for (int i = 0; i < plantasUsar.Count; i++)
        {
            // Crear la carta
            GameObject crearCarta = Instantiate(cartaPlantaPrefab, semilleroPlantas.transform);
            crearCarta.transform.localScale = Vector3.one;

            // Asignar imagen
            Image cartaImagen = crearCarta.GetComponent<Image>();
            cartaImagen.sprite = plantasUsar[i].semillaPlanta;


            // Asignar botón
            Button btn = crearCarta.GetComponent<Button>();
            botones.Add(btn);

            // Crear overlay de recarga (visual opcional)
            GameObject overlayGO = new GameObject("Overlay");
            overlayGO.transform.SetParent(crearCarta.transform, false);
            Image overlay = overlayGO.AddComponent<Image>();
            overlay.color = new Color(0, 0, 0, 0.5f); // semi-transparente
            overlay.rectTransform.anchorMin = Vector2.zero;
            overlay.rectTransform.anchorMax = Vector2.one;
            overlay.rectTransform.offsetMin = Vector2.zero;
            overlay.rectTransform.offsetMax = Vector2.zero;
            overlay.fillMethod = Image.FillMethod.Vertical;
            overlay.type = Image.Type.Filled;
            overlay.enabled = false;
            overlays.Add(overlay);

            // Configurar clic
            int j = i;
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(() =>
            {
                SeleccionarPlanta(j);
                
                foreach(Button b in botones)
                {
                    b.GetComponent<Image>().color = Color.white;
                };

                btn.GetComponent<Image>().color = Color.softYellow;

            });

            // Inicializar tiempos
            tiempoRestante[i] = 0f;
        }
    }

    void Update()
    {
        // Actualizar tiempos de recarga
        for (int i = 0; i < plantasUsar.Count; i++)
        {
            if (tiempoRestante[i] > 0)
            {
                tiempoRestante[i] -= Time.deltaTime;
                overlays[i].fillAmount = tiempoRestante[i] / plantasUsar[i].tiempoRecarga;

                if (tiempoRestante[i] <= 0)
                {
                    tiempoRestante[i] = 0;
                    botones[i].interactable = true;
                    overlays[i].enabled = false;
                }
            }
        }
    }

    void SeleccionarPlanta(int index)
    {
        // Si está en recarga, no permite seleccionar
        if (tiempoRestante[index] > 0)
            return;

        numeroPlanta = index;
        botones[index].interactable = false;
        tiempoRestante[index] = plantasUsar[index].tiempoRecarga;
        overlays[index].enabled = false;
    }

    // Método para usar desde GameManager cuando se planta una planta
    public void ActivarRecargaManual(int index)
    {
        botones[index].interactable = false;
        tiempoRestante[index] = plantasUsar[index].tiempoRecarga;
        overlays[index].enabled = true;
    }
}
