const express = require("express");
const sesionesController = require("../controllers/sesionesController");

const router = express.Router();

router.get("/registro", sesionesController.getRegistro);
router.post("/registro", sesionesController.registrarUsuario);
router.get("/login", sesionesController.loginUsuario); // Ruta para mostrar el formulario de inicio de sesión

// Agrega la ruta para manejar el inicio de sesión
router.post("/login", sesionesController.iniciarSesion);

module.exports = router;