const express = require("express");
const sesionesController = require("../controllers/sesionesController");

const router = express.Router();

// Middleware para verificar si el usuario está autenticado
const verificarAutenticacion = (req, res, next) => {
    // Verifica si el usuario está autenticado
    if (!req.session.usuarioAutenticado) {
        // Si el usuario no está autenticado, redirige a la ruta de inicio de sesión
        return res.redirect("/login");
    }
    // Si el usuario está autenticado, continúa con la siguiente middleware o ruta
    next();
};

// Rutas de registro y autenticación
router.get("/registro", sesionesController.getRegistro);
router.post("/registro", sesionesController.registrarUsuario);
router.get("/login", sesionesController.loginUsuario); // Ruta para mostrar el formulario de inicio de sesión
router.post("/login", sesionesController.iniciarSesion); // Ruta para manejar el inicio de sesión

// Rutas protegidas por autenticación
router.get("/", verificarAutenticacion, (req, res) => {
    // Esta es una ruta protegida que solo se muestra si el usuario está autenticado
    res.send("Bienvenido a la página principal");
});

module.exports = router;