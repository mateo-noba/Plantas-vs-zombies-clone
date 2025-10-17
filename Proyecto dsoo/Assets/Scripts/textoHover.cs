using UnityEngine;
using TMPro;
public class textoHover : MonoBehaviour
{

    public TextMeshProUGUI texto;
    public Color colorNormal = Color.coral;//E1C013;
    public Color colorHover = Color.white;

    public void OnMouseEnter()
    {
        texto.color = colorHover;
    }

    public void OnMouseExit()
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
