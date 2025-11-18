import mongoose from "mongoose";

const UserSchema = new mongoose.Schema({
    id: {type: int},
    nombreDeUsuario: {type: string},
    email: {type: string},
    contraseña: {type: string},
    mejorPuntaje: {type: string},
    ultimoPuntaje: {type: string}
});

export default mongoose.model("User", UserSchema);