import express from "express";
import mongoose from "mongoose";
import cors from "cors";
import dotenv from "dotenv";

dotenv.config();

const app = express();
app.use(cors());
app.use(express.json());

mongoose.connect(process.env.MONGO_URI)
    .then(() => console.log("Mongo conetado"))
    .catch(err => console.log(err));
/*import userRouter from "./Routers/users.js";
app.use("/api/user", userRouter);*/

app.get("/", (req, res) => {
    res.send("api funciona");
});

app.listen(process.env.PORT, () => {
    console.log("Servidor en puerto " + process.env.PORT);
})