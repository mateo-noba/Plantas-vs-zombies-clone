import { Footer } from "../Components/footer";
import { Navbar } from "../Components/header";
import logoPVZroguelike from '../imagenes/fondoPVZroguelike.png';
import './singUp.css';
import { useState } from "react";


export function SingUp(){
    const [nombreDeUsuario, setNombre] = useState("");
    const [email, setEmail] = useState("");
    const [contraseña, setContraseña] = useState("");
    const [repContraseña, setRepContraseña] = useState("");

    const registro = async () => {
        const respuesta = await fetch("http://localhost:3000/api/registro", {
            method: "POST",
            headers: {"Content-Type": "application/json"},
            body: JSON.stringify({nombreDeUsuario, email, contraseña, repContraseña})
        });

        const data = await respuesta.json();
        console.log(data);
        alert(data.message);
    }

    return(
        <div>
           <Navbar/>
            <div className="partePrincipal">
                <div className="overlay">
                    <div className="parteRegistro">
                        <div className="divRegistro">
                            <img className="logoJuegoRegistro" src={logoPVZroguelike} alt="Logo"/>
                            <h2>Crear cuenta</h2>
                        </div>
                        <div className="divFormulario">
                            <form>
                                <label>Nombre de usuario</label>
                                <br/>
                                <input type="text" onChange={(e) => setNombre(e.target.value)}/>
                                <br/>
                                <label>Email</label>
                                <br/>
                                <input type="email" onChange={(e) => setEmail(e.target.value)}/>
                                <br/>
                                <label>Contraseña</label>
                                <br/>
                                <input type="password" onChange={(e) => setContraseña(e.target.value)}/>
                                <br></br>
                                <label>Confirmar contraseña</label>
                                <br/>
                                <input type="password" onChange={(e) => setRepContraseña(e.target.value)}/>
                                <button onClick={(e) => {e.preventDefault(); registro();}}>Crear cuenta</button>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
            <Footer/>
        </div>
    )
}