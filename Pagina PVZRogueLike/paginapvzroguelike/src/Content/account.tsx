import './account.css';
import { Navbar } from '../Components/header';
import { Footer } from '../Components/footer';
import { useState, useEffect } from 'react';
import { useNavigate } from "react-router-dom";

interface UsuarioProp {
    id: number,
    nombreDeUsuario: string,
    email: string,
    contraseña: string,
    mejorPuntaje: number,
    ultimoPuntaje: number
}

export function Account(){
 
    const [usuario, setUsuario] = useState<UsuarioProp | null>(null);
    
    const Navigate = useNavigate();

    useEffect(() => {
        const token = localStorage.getItem("token");
        if (!token) return;
    
        const cargarUsuario = async () => {
            const res = await fetch("http://localhost:3000/api/perfil", {
                headers: {
                Authorization: "Bearer " + token
                }
            });
    
        const data = await res.json();
        if (data.usuario) setUsuario(data.usuario);
        };
    
        cargarUsuario();
        }, []);

    const logout = () => {
        localStorage.removeItem("token");
        setUsuario(null);
        Navigate("/")
    };

 return(
        <div>
            <Navbar/>
            <div className="partePrincipal">
                <div className="overlay">
                    <div className="parteCuenta">
                        <h1>Cuenta</h1>
                        <h2>Nombre: {usuario?.nombreDeUsuario}</h2>
                        <h2>Mejor puntaje: {usuario?.mejorPuntaje}</h2>
                        <h2>Ultimo puntaje: {usuario?.ultimoPuntaje}</h2>
                        <button onClick={logout}>Cerrar sesión</button>
                    </div>
                </div>
            </div>
    
            <Footer/>

        </div>
    )
}