express = require("express");
const sesionesController = require("../controllers/sesionesController");

const router = express.Router();

router.get("/registro", sesionesController.getRegistro)
router.post('/registro', sesionesController.registrarUsuario);


module.exports = router;