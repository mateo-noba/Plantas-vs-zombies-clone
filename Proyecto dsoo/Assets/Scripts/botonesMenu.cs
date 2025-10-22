using UnityEngine;
using UnityEngine.SceneManagement;

public class botonesMenu : MonoBehaviour
{
    public void jugar(string nombreScena)
    {
        SceneManager.LoadScene(nombreScena);
    }
    public void Salir()
    {
        Application.Quit();
        Debug.Log("Salió del juego");
    }
   
}
