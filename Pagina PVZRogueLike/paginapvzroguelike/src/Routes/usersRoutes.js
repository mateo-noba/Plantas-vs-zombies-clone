import express from "express";
import { showUser, sigUpUser, logInUser, scoreBoard } from "../Controllers/userController.js";
import User from "../Models/User.js";
import { verifyToken } from "../Middleware/verifyToken.js";

const router = express.Router();

router.get("/users", showUser);

router.post("/registro", sigUpUser);

router.post("/inicioSesion", logInUser);

router.get("/puntajes", scoreBoard);

router.get("/perfil", verifyToken, async (req, res) => {
  const usuario = await User.findOne({ id: req.user.id });

  res.json({ usuario });
});

export default router;