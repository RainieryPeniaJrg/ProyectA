express = require("express");
const directorController = require("../controllers/directorController");


const router = express.Router();





router.get("/", directorController.getHome);
router.get("/grupos", directorController.getGrupos);
router.get("/coordinadores",directorController.getCoordinadores);
router.get("/subcoordinadores", directorController.getSubCoordinadores);
router.get("/dirigentes",directorController.getDirigentes );

//RUTAS POR POST
//router.post("/director/agregar-votante");


module.exports = router;