import mongoose from "mongoose";

const UserSchema = new mongoose.Schema({
    id: {type: Number},
    nombreDeUsuario: {type: String},
    email: {type: String},
    contraseña: {type: String},
    mejorPuntaje: {type: String},
    ultimoPuntaje: {type: String}
});

export default mongoose.model("User", UserSchema);