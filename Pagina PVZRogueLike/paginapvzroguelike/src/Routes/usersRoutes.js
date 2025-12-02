import express from "express";
import { sigUpUser, logInUser, scoreBoard, updateScore, showPerfil } from "../Controllers/userController.js";
import User from "../Models/User.js";
import { verifyToken } from "../Middleware/verifyToken.js";

const router = express.Router();

router.post("/registro", sigUpUser);

router.post("/inicioSesion", logInUser);

router.get("/puntajes", scoreBoard);

router.get("/perfil", verifyToken, showPerfil);

router.post("/actualizarPuntaje", verifyToken, updateScore)

export default router;