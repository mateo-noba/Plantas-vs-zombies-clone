using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class botonesMenu : MonoBehaviour
{

    public GameObject panelPausa;

    public bool juegoPausado = false;

    public GameManager gameManagerScript;

    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TMP_Text mensaje;
    public GameObject botonIniciarSesion;
    public GameObject botonCuenta;

    public TMP_Text nombreUsuario;
    public TMP_Text mejorPuntaje;
    public TMP_Text ultimoPuntaje;

    void Start()
    {
        if(botonCuenta != null && botonIniciarSesion != null)
        {
            AutoLogeo(); 
        }
    }
    public void jugar(string nombreScena)
    {
        SceneManager.LoadScene(nombreScena);
    }
    public void Salir()
    {
        Application.Quit();
        Debug.Log("Salió del juego");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameManagerScript.perder != true)
            {
                if (juegoPausado)
                {
                    Reanudar();
                }
                else
                {
                    Pausar();
                }
            }
        }
    }


    public void Pausar()
    {
        panelPausa.SetActive(true);
        Time.timeScale = 0f;
        juegoPausado = true;

    }

    public void Reanudar()
    {
        panelPausa.SetActive(false);
        Time.timeScale = 1f;
        juegoPausado = false;
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameManagerScript.perder = false;
    }

    public void SalirMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("menuScene");
    }

   public void loginButton()
    {
        string email = emailInput.text;
        string password = passwordInput.text;

        StartCoroutine(APIManager.instancia.Login(email, password, (resp) =>
        {
            if(resp != null && resp.usuario != null)
            {
                mensaje.text = "Inicio de sesión exitoso";
                Debug.Log("Funco");
                botonIniciarSesion.SetActive(false);
                botonCuenta.SetActive(true);
            }
            else
            {
                mensaje.text = "Error al iniciar sesión, email o contraseña incorrecta";
                Debug.Log("No fuco");
            }
        }));
    }

    public void Logout()
    {
        PlayerPrefs.DeleteKey("token");
        PlayerPrefs.DeleteKey("username");
        PlayerPrefs.Save();
        Debug.Log("Sesión cerrada correctamente.");
        botonIniciarSesion.SetActive(true);
        botonCuenta.SetActive(false);
    }

    public void AutoLogeo()
    {
        string token = PlayerPrefs.GetString("token", "");

        if(token != "")
        {
            Debug.Log("Usuario logueado: " + PlayerPrefs.GetString("username"));
            
            botonIniciarSesion.SetActive(false);
            botonCuenta.SetActive(true);
            
        }
        else
        {
            Debug.Log("No hay sesión guardada");
        }
    }

    public void cargarPerfilCuenta()
    {
        StartCoroutine(APIManager.instancia.CargarPerfil((resp) =>
        {
          if(resp != null && resp.nombreDeUsuario != null)
            {
                nombreUsuario.text = $"Nombre: {resp.nombreDeUsuario}";

                mejorPuntaje.text = $"Mejor puntaje: {resp.mejorPuntaje}";

                ultimoPuntaje.text = $"Ultimo puntaje: {resp.ultimoPuntaje}";
            }
            else
            {
                Debug.Log("No se pudo recuperar la informacion del usuario");
            }
        }));
    }

}