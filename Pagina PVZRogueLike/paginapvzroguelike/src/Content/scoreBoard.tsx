import './scoreBoard.css';
import { Navbar } from '../Components/header';
import { Footer } from '../Components/footer';

export function ScoreBoard(){

    return(
        <div>
            <Navbar/>
            <div className="partePrincipal">
                <div className="overlay">
                    <div className="parteScore">
                        <h1>Tabla de clasificaciones</h1>
                        <table>
                            <tr>
                                <th>Puesto</th>

                                <th>Nombre de uasuario</th>

                                <th>Mejor puntaje</th>

                                <th>Ultimo puntaje</th>
                            </tr>
                            <tr>
                                <td>Puesto</td>
                                <td>Nombre de uasuario</td>
                                <td>Mejor puntaje</td>
                                <td>Ultimo puntaje</td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
    
            <Footer/>

        </div>
    )
}