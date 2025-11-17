import type React from 'react';
import {createBrowserRouter, Outlet, RouterProvider} from 'react-router-dom';
import './App.css';
import { MainPart } from './mainPart';
import { Login } from './logIn';
import { SingUp } from './singUp';
import { ScoreBoard } from './scoreBoard';
import { AboutUs } from './aboutUs';

function Pagina() {
  return (
    <>
      <Outlet/>
    </>
  )
}

const router = createBrowserRouter([
  {
    path: '/',
    element: <Pagina/>,
    errorElement: '',
    children: [
      {
        index: true,
        element: <MainPart/>
      },
      {
        path: 'iniciarSesion',
        element: <Login/>
      },
      {
        path: 'crearCuenta',
        element: <SingUp/>
      },
      {
        path: 'clasificaciones',
        element: <ScoreBoard/>
      },
      {
        path: 'sobreNosotros',
        element: <AboutUs/>
      }
    ]
  }
])

const App: React.FC = () => {
  return <RouterProvider router={router} />
}

export default App
