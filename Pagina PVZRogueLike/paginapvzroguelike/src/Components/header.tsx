import './header.css';
import logoPVZroguelike from '../imagenes/fondoPVZroguelike.png';
import { useEffect, useState } from 'react';

interface UsuarioProp {
    id: number,
    nombreDeUsuario: string,
    email: string,
    contraseña: string,
    mejorPuntaje: number,
    ultimoPuntaje: number
}

export function Navbar(){
    const [usuario, setUsuario] = useState<UsuarioProp | null>(null);

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

    return(
        <>
            {usuario ? (
            <div className="barraDeNavegacion">
                <a href='/'><img className="logoJuego" src={logoPVZroguelike} alt="Logo"/></a>

                <p><a href="/">Descarga</a></p>
                <p><a href="/sobreNosotros">Sobre nosotros</a></p>
                <p><a href="/clasificaciones">Puntajes</a></p>

                <p><a href="/cuenta">{usuario.nombreDeUsuario}</a></p>
                {/*<p><a href="/" >Cerrar sesion</a></p>*/}
            </div>
            ) : (
            <div className="barraDeNavegacion">
                <a href='/'><img className="logoJuego" src={logoPVZroguelike} alt="Logo"/></a>

                <p><a href="/">Descarga</a></p>
                <p><a href="/sobreNosotros">Sobre nosotros</a></p>
                <p><a href="/clasificaciones">Puntajes</a></p>

                <p><a href="/iniciarSesion">Iniciar sesión</a></p>
                <p><a href="/crearCuenta">Crear cuenta</a></p>
            </div>
            )}
        </>
    );
}