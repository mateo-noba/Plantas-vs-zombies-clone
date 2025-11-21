import { Footer } from "../Components/footer";
import { Navbar } from "../Components/header";
import logoPVZroguelike from '../imagenes/fondoPVZroguelike.png';
import './logIn.css';
import { useState } from "react";
import { useNavigate } from "react-router-dom";



export function Login(){

    const [email, setEmail] = useState("");
    const [contraseña, setContraseña] = useState("");

    const Navigate = useNavigate();

    const logInUser = async () =>{
        const respuesta = await fetch("http://localhost:3000/api/inicioSesion", {
            method: "POST",
            headers: {"Content-Type": "application/json"},
            body: JSON.stringify({ email, contraseña})
        });

        const data = await respuesta.json();
        console.log(data);
        alert(data.message);

        if (data.token) {
        localStorage.setItem("token", data.token);
        window.location.reload(); // fuerza recargar el header actualizado
        }
        if(respuesta.ok){
            Navigate("/")
        }
    }

    return(
        <div>
           <Navbar/>
            <div className="partePrincipal">
                <div className="overlay">
                    <div className="parteIniciarSesion">
                        <div className="divIniciarSesion">
                            <img className="logoJuegoSesion" src={logoPVZroguelike} alt="Logo"/>
                            <h2>Iniciar sesión</h2>
                        </div>
                        <div className="divFormulario">
                            <form>
                                <label>Email</label>
                                <br/>
                                <input type="email" onChange={(e) => setEmail(e.target.value)}/>
                                <br/>
                                <label>Contraseña</label>
                                <br/>
                                <input id="inputContraseña" type="password" onChange={(e) => setContraseña(e.target.value)}/>
                                <p><a href="/crearCuenta">Crear cuenta?</a></p>
                                <button onClick={(e) => {e.preventDefault(); logInUser()}}>Iniciar sesión</button>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
            <Footer/>
        </div>
    )
}