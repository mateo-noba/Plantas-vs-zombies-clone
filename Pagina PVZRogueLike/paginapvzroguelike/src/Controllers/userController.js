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

export const createUser = async (req, res) => {
    try{
        const newUser = new User(req.body);
        await newUser.save();
    }catch(error){
        console.log("No se pudo crear el usuario");
        res.status(500).json({error: "Error al crear usuario"});
    }
}