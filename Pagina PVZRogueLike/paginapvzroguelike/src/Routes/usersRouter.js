import express from "express";
import { showUser, createUser } from "../Controllers/userController";

const router = express.Router();

router.get("/users", showUser);

router.post("/", createUser);

export default router;