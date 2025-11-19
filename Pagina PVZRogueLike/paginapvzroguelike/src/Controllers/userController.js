import { error } from "console";
import User from "../Models/User.js";

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

        res.status(201).json({ message: "Usuario creado con exito", usuarios: nuevoUsuario});
    }catch (error) {
        console.log(error);
        res.status(500).json({ message: "Error del servidor", error});
    }
};

/*export const createUser = async (req, res) => {
    try{
        const newUser = new User(req.body);
        await newUser.save();
    }catch(error){
        console.log("No se pudo crear el usuario");
        res.status(500).json({error: "Error al crear usuario"});
    }
}*/