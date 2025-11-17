import './mainPart.css';
import { Navbar } from '../Components/header';
import { Footer } from '../Components/footer';

export function MainPart(){

    return(
        <div>
            <Navbar/>
    
            <div className="partePrincipal">
                <div className="overlay">
                <a href="https://github.com/MateoBenjaminNobaFioriti/ProyectoDSOO.git" target="_blank"><button id="botonDescarga">Descargar</button></a>
                </div>
            </div>
    
            <Footer/>

        </div>
    )
}