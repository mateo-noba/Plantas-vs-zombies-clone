import express from "express";
import { showUser, sigUpUser } from "../Controllers/userController.js";

const router = express.Router();

router.get("/users", showUser);

router.post("/registro", sigUpUser);

export default router;