//Librerias necesarias
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;

//Clase principal
public class APIManager : MonoBehaviour {

    //Variable para llamar facilmente a las funciones de APIManager desde cualquier archivo
    public static APIManager instancia;

    //Variable para saber si esta logeado o no
    public bool logeado;

    //Función awake para que el objeto en que esta el script no se destruya cuando pasa entre escenas
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
    //Clase para los datos de la peticion de la API del login
[Serializable]
    public class LoginRequest { 
        public string email; 
        public string contraseña; 
    }

    //Clase para recibir los datos del usuario
[Serializable]
    public class UsuarioDTO {  
        public int id; 
        public string nombreDeUsuario; 
        public string email; 
    }

    //Clase para recibir la respuesta del login de la api
[Serializable]
    public class LoginResponse { 
        public string message; 
        public string token; 
        public UsuarioDTO usuario; 
    }

    //Función corrutina del login
    public IEnumerator Login(string email, string contraseña, System.Action<LoginResponse> onDone) {

        var reqObj = new LoginRequest{ email = email, contraseña = contraseña };//Pasar los datos a un objeto

        string json = JsonUtility.ToJson(reqObj);//Pasar los datos del objeto a json

        //Crea la peticion para la API
        using var uwr = new UnityWebRequest("http://localhost:3000/api/inicioSesion", "POST") {//Le indica la url de la API y el metodo
            uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json)),//Le indica que es lo que le va a enviar
            downloadHandler = new DownloadHandlerBuffer()//Le indica que guarde la respuesta en la memoria
        };

        //Le indica el formato en el que se envia los datos
        uwr.SetRequestHeader("Content-Type","application/json");
        //Encia la petición
        yield return uwr.SendWebRequest();

        //En caso de que la respuesta de la API sea exitosa
        if (uwr.result == UnityWebRequest.Result.Success) {
            var resp = JsonUtility.FromJson<LoginResponse>(uwr.downloadHandler.text);//Guarda los datos obtenidos de la API en la variable resp
            PlayerPrefs.SetString("token", resp.token);//Guarda el token en el playerprefs
            PlayerPrefs.SetString("username", resp.usuario.nombreDeUsuario);//Guarda el nombre de usuario en el player pref
            PlayerPrefs.Save();//Guarda los datos del playerpref
            Debug.Log("Log in exitoso");//Hace un comentario en consola para saber que esta loeado
            logeado = true;//Pone la variable booleana en true para verificar si esta logeado
            onDone?.Invoke(resp);//Pasa los valores que recibió y avisa que la función terminó
        } else {//En caso de que la respuesta no sea exitosa
            Debug.LogError("Login error: " + uwr.error + " - " + uwr.downloadHandler.text);//Mensaje de error en consola
            onDone?.Invoke(null);//Le pasa nulo deciendo que la función no fue exitosa
            logeado = false;//Logeado queda en false porque no se pudo logear
        }
    }


    

//----------------Recuperar datos de usuario------------------------

    //Clase para los datos del usuario
    [Serializable]
    public class UsuarioPerfil {
        public int id;
        public string nombreDeUsuario;
        public string email;
        public int mejorPuntaje;
        public int ultimoPuntaje;
    }

    //Clase para la respuesta de la API
    [Serializable]
    public class PerfilResponse {
        public UsuarioPerfil usuario;
    }

    //Corrutina con la función que carga el perfil
    public IEnumerator CargarPerfil(System.Action<UsuarioPerfil> onDone)
    {
        //Recupera el token del playpref
        string token = PlayerPrefs.GetString("token", "");

        //Crea la peticion
        using (UnityWebRequest uwr = UnityWebRequest.Get("http://localhost:3000/api/perfil"))
        {
            //Define el header de a petición y le pasa el token
            uwr.SetRequestHeader("Authorization", "Bearer " + token);
            //Encnvia la petición
            yield return uwr.SendWebRequest();

            //En caso de que sea exitosa
            if (uwr.result == UnityWebRequest.Result.Success)
            {
                var data = JsonUtility.FromJson<PerfilResponse>(uwr.downloadHandler.text);//Guarda los datos en data
                onDone(data.usuario);//Los pasa como parametros cuando llamen a la función y avisa que salio bien
            }
            else
            {//En caso de que no sea exitoso
                Debug.LogError("Error cargando perfil: " + uwr.error);//Mensaje de error
                onDone(null);//Envia nulo mostrando que salio mal
            }
        }
    }

//--------------------Actualizar puntaje-----------------------------------
    //Clase para el envio del puntaje
    public class PuntajeRequest {
        public int puntaje;
    }

    //Función corrutina para envia el puntaje
    public IEnumerator EnviarPuntaje(int puntaje)
    {
        //Pasar los datos a un objeto
        PuntajeRequest data = new PuntajeRequest { puntaje = puntaje };
        string token = PlayerPrefs.GetString("token", "");//Guarda el token que esta en el playerpref en una variable

        string json = JsonUtility.ToJson(data);//Lo tranforma en json

        //Crea la petición para la Api
        using (UnityWebRequest uwr = new UnityWebRequest("http://localhost:3000/api/actualizarPuntaje", "POST"))
        {
            uwr.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json));//Le indica que es lo que le va a enviar
            uwr.downloadHandler = new DownloadHandlerBuffer();//Le indica que guarde la respuesta en la memoria
            uwr.SetRequestHeader("Content-Type", "application/json");//Le indica el formato en el que se envia los datos
            uwr.SetRequestHeader("Authorization", "Bearer " + token);//Define el header de a petición y le pasa el token

            //Envia la petición
            yield return uwr.SendWebRequest();

            //En caso exitoso
            if (uwr.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Puntaje actualizado correctamente");//Mensaje de exito
            }
            else//En caso de falla 
            {
                Debug.LogError("Error enviando puntaje: " + uwr.error);//Mensaje de error
            }
        }
    }
}