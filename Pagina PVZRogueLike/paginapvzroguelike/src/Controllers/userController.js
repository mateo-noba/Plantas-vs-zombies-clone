import User from "../Models/User.js";
import jwt from "jsonwebtoken";
import dotenv from "dotenv";

dotenv.config();

export const showUser = async (req, res) => {
    try{
        const users =  await User.find();
        res.json(users);
    }catch(error){
        console.log("No se pudo mostrar usuario");
        res.status(500).json({error: "Error al mostrar usuario"});
    }
}

export const sigUpUser = async (req, res) => {
    try{

        const {nombreDeUsuario, email, contraseña, repContraseña} = req.body;

        if(!nombreDeUsuario || !email || !contraseña || !repContraseña){
            return res.status(400).json({message: "Faltan datos"});
        }

        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

        if (!emailRegex.test(email)) {
            return res.status(400).json({ message: "El email no es válido" });
        }


        if(contraseña !== repContraseña){
            return res.status(400).json({message: "Las contraseñas no coinciden"});
        }

        const emailExistente = await User.findOne({ email});
        if(emailExistente){
            return res.status(400).json({message: "Ya existe una cuenta con ese mail"})
        }

        const ultimo = await User.findOne().sort({id: -1});
        const nuevoId = ultimo ? ultimo.id + 1 : 1;

        const nuevoUsuario = new User({
            id: nuevoId,
            nombreDeUsuario,
            email,
            contraseña,
            mejorPuntaje: 0,
            ultimoPuntaje: 0
        });

        await nuevoUsuario.save();

        const token = jwt.sign(
            {id: nuevoUsuario.id},
            process.env.JWT_SECRET,
            {expiresIn: "7d"}
        );


        res.json({
            message: "Registro exitoso",
            token,
            usuario: {
                id: nuevoUsuario.id,
                nombreDeUsuario: nuevoUsuario.nombreDeUsuario,
                email: nuevoUsuario.email
            }
        });
    }catch (error) {
        console.log(error);
        res.status(500).json({ message: "Error del servidor", error});
    }
};

export const logInUser = async (req, res) => {
    try{
        const {email, contraseña} = req.body;

        const usuario = await User.findOne({email});

        if(!usuario){
            return res.status(404).json({message: "Usuario no encontrado"})
        }
        if(usuario.contraseña !== contraseña){
            return res.status(400).json({message: "Contraseña incorrecta"});
        }
        const token = jwt.sign(
            { id: usuario.id },
            process.env.JWT_SECRET,
            { expiresIn: "7d" }
        );

        res.json({
            message: "Sesión iniciada",
            token,
            usuario: {
                id: usuario.id,
                nombreDeUsuario: usuario.nombreDeUsuario,
                email: usuario.email
            }
        });
    }catch (error){
        res.status(500).json({message: "Error del servidor"});
    }
};

export const scoreBoard = async (req, res) =>{
    try{
        const ranking = await User.find()
        .sort({mejorPuntaje: -1})
        .select("nombreDeUsuario mejorPuntaje ultimoPuntaje");

        res.json(ranking);
    }catch (error){
        res.status(500).json({message: "Error al obtener el score board"})
    }
}