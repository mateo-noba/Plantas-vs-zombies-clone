using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;


public class APIManager : MonoBehaviour {

    public static APIManager instancia;

    public bool logeado;

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

//--------------------Login---------------------------------
[Serializable]
    public class LoginRequest { 
        public string email; 
        public string contraseña; 
    }

[Serializable]
    public class UsuarioDTO {  
        public int id; 
        public string nombreDeUsuario; 
        public string email; 
    }

[Serializable]
    public class LoginResponse { 
        public string message; 
        public string token; 
        public UsuarioDTO usuario; 
    }

    public IEnumerator Login(string email, string contraseña, System.Action<LoginResponse> onDone) {

        var reqObj = new LoginRequest{ email = email, contraseña = contraseña };//Pasar los datos a un objeto

        string json = JsonUtility.ToJson(reqObj);//Pasar los datos del objeto a json

        using var uwr = new UnityWebRequest("http://192.168.0.187:3000/api/inicioSesion", "POST") {
            uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json)),
            downloadHandler = new DownloadHandlerBuffer()
        };
        uwr.SetRequestHeader("Content-Type","application/json");
        yield return uwr.SendWebRequest();

        if (uwr.result == UnityWebRequest.Result.Success) {
            var resp = JsonUtility.FromJson<LoginResponse>(uwr.downloadHandler.text);
            PlayerPrefs.SetString("token", resp.token);
            PlayerPrefs.SetString("username", resp.usuario.nombreDeUsuario);
            PlayerPrefs.Save();
            Debug.Log("Log in exitoso");
            logeado = true;
            onDone?.Invoke(resp);
        } else {
            Debug.LogError("Login error: " + uwr.error + " - " + uwr.downloadHandler.text);
            onDone?.Invoke(null);
            logeado = false;
        }
    }


    

//----------------Recuperar datos de usuario------------------------

    [Serializable]
    public class UsuarioPerfil {
        public int id;
        public string nombreDeUsuario;
        public string email;
        public int mejorPuntaje;
        public int ultimoPuntaje;
    }

    [Serializable]
    public class PerfilResponse {
        public UsuarioPerfil usuario;
    }

    public IEnumerator CargarPerfil(System.Action<UsuarioPerfil> onDone)
    {
        string token = PlayerPrefs.GetString("token", "");

        using (UnityWebRequest uwr = UnityWebRequest.Get("http://192.168.0.187:3000/api/perfil"))
        {
            uwr.SetRequestHeader("Authorization", "Bearer " + token);
            yield return uwr.SendWebRequest();

            if (uwr.result == UnityWebRequest.Result.Success)
            {
                var data = JsonUtility.FromJson<PerfilResponse>(uwr.downloadHandler.text);
                onDone(data.usuario);
            }
            else
            {
                Debug.LogError("Error cargando perfil: " + uwr.error);
                onDone(null);
            }
        }
    }

//--------------------Actualizar puntaje-----------------------------------
    public class PuntajeRequest {
        public int puntaje;
    }

    public IEnumerator EnviarPuntaje(int puntaje)
    {
        PuntajeRequest data = new PuntajeRequest { puntaje = puntaje };
        string token = PlayerPrefs.GetString("token", "");

        string json = JsonUtility.ToJson(data);

        using (UnityWebRequest uwr = new UnityWebRequest("http://192.168.0.187:3000/api/actualizarPuntaje", "POST"))
        {
            uwr.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json));
            uwr.downloadHandler = new DownloadHandlerBuffer();
            uwr.SetRequestHeader("Content-Type", "application/json");
            uwr.SetRequestHeader("Authorization", "Bearer " + token);

            yield return uwr.SendWebRequest();

            if (uwr.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Puntaje actualizado correctamente");
            }
            else
            {
                Debug.LogError("Error enviando puntaje: " + uwr.error);
            }
        }
    }
}