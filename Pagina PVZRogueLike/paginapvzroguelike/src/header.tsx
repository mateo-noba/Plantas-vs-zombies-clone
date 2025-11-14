import './header.css';
import logoPVZroguelike from './imagenes/fondoPVZroguelike.png';

export function Navbar(){
    
    return(
        <div className="barraDeNavegacion">
            <img className="logoJuego" src={logoPVZroguelike} alt="Logo"/>

            <p><a href="/">Descarga</a></p>
            <p><a href="#">Sobre nosotros</a></p>
            <p><a href="#">Puntajes</a></p>

            <p><a href="/iniciarSesion">Iniciar sesión</a></p>
            <p><a href="/crearCuenta">Crear cuenta</a></p>
        </div>
    )
}