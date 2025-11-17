import { Footer } from "./footer";
import { Navbar } from "./header";
import logoPVZroguelike from './imagenes/fondoPVZroguelike.png';
import './singUp.css';


export function SingUp(){
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
                                <input type="text"/>
                                <br/>
                                <label>Email</label>
                                <br/>
                                <input type="email"/>
                                <br/>
                                <label>Contraseña</label>
                                <br/>
                                <input type="password"/>
                                <br></br>
                                <label>Confirmar contraseña</label>
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