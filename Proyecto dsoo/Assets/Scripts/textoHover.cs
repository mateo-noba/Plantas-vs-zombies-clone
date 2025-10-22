using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
public class textoHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public TextMeshProUGUI texto;
    public Color colorNormal = Color.coral;//E1C013;
    public Color colorHover = Color.white;

    public void OnPointerEnter(PointerEventData eventData)
    {
        texto.color = colorHover;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        texto.color = colorNormal;
    } 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
