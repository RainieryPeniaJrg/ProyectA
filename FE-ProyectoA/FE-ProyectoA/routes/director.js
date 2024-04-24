express = require("express");
const directorController = require("../controllers/directorController");


const router = express.Router();





router.get("/", directorController.getHome);
router.get("/grupos", directorController.getGrupos);
router.get("/coordinadores",directorController.getCoordinadores);
router.get("/subcoordinadores", directorController.getSubCoordinadores);
router.get("/dirigentes",directorController.getDirigentes );
router.get("/agregar-grupo",directorController.getAgregarGrupos)

//RUTAS POR POST
router.post("/agregar-grupo", directorController.PostAgregarGrupo);


module.exports = router;