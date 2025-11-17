import './header.css';
import logoPVZroguelike from '../imagenes/fondoPVZroguelike.png';

export function Navbar(){
    
    return(
        <div className="barraDeNavegacion">
            <a href='/'><img className="logoJuego" src={logoPVZroguelike} alt="Logo"/></a>

            <p><a href="/">Descarga</a></p>
            <p><a href="/sobreNosotros">Sobre nosotros</a></p>
            <p><a href="/clasificaciones">Puntajes</a></p>

            <p><a href="/iniciarSesion">Iniciar sesión</a></p>
            <p><a href="/crearCuenta">Crear cuenta</a></p>
        </div>
    )
}