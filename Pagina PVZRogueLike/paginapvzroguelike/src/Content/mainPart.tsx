import './mainPart.css';
import { Navbar } from '../Components/header';
import { Footer } from '../Components/footer';

export function MainPart(){

    return(
        <div>
            <Navbar/>
    
            <div className="partePrincipal">
                <div className="overlay">
                <a href="https://drive.google.com/file/d/1sv2CL5S9kJ2iscKxDYLWNW4n0zlUpZ_6/view?usp=sharing" target="_blank"><button id="botonDescarga">Descargar</button></a>
                </div>
            </div>
    
            <Footer/>

        </div>
    )
}