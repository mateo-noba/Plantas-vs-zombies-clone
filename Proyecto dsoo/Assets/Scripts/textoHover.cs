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
}
