import { Footer } from "./footer";
import { Navbar } from "./header";
import logoPVZroguelike from './imagenes/fondoPVZroguelike.png';
import './logIn.css';


export function Login(){
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
                                <input type="email"/>
                                <br/>
                                <label>Contraseña</label>
                                <br/>
                                <input type="password"/>
                                <a><button>Iniciar sesión</button></a>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
            <Footer/>
        </div>
    )
}