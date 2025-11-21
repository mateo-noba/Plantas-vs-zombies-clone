import './scoreBoard.css';
import { Navbar } from '../Components/header';
import { Footer } from '../Components/footer';
import { useState, useEffect } from 'react';

interface ScoreBoardProp {
    nombreDeUsuario: string,
    mejorPuntaje: number,
    ultimoPuntaje: number
}

export function ScoreBoard(){
    const [usuarios, setUsuarios] = useState<ScoreBoardProp[]>([]);

    useEffect(() => {
        const cargandoScore = async () => {
            const res = await fetch("http://localhost:3000/api/puntajes");
            const data = await res.json();
            setUsuarios(data);
        }
        cargandoScore();
    }, []);

    return(
        <div>
            <Navbar/>
            <div className="partePrincipal">
                <div className="overlay">
                    <div className="parteScore">
                        <h1>Tabla de clasificaciones</h1>
                        <table>
                            <thead>
                                <tr>
                                    <th>Puesto</th>

                                    <th>Nombre de uasuario</th>

                                    <th>Mejor puntaje</th>

                                    <th>Ultimo puntaje</th>
                                </tr>
                            </thead>
                            <tbody>
                                {usuarios?.map((u, index) => (
                                    <tr key={index}>
                                        <td>{index + 1}</td>
                                        <td>{u.nombreDeUsuario}</td>
                                        <td>{u.mejorPuntaje}</td>
                                        <td>{u.ultimoPuntaje}</td>
                                    </tr>
                                ))}
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
    
            <Footer/>

        </div>
    )
}