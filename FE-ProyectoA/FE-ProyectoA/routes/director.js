express = require("express");
const { post } = require("jquery");
const directorController = require("../controllers/directorController");


const router = express.Router();





router.get("/", directorController.getHome);
router.get("/grupos", directorController.getGrupos);
router.get("/coordinadores",directorController.getCoordinadores);
router.get("/subcoordinadores", directorController.getSubCoordinadores);
router.get("/dirigentes",directorController.getDirigentes );

router.get("/agregar-grupo",directorController.getAgregarGrupos)
router.get("/agregar-coordinadores",directorController.getAgregarCoordinador)
router.get("/agregar-subcoordinadores",directorController.getAgregarSubCoordinador)
router.get("/agregar-dirigente",directorController.getAgregarDirigente)

//RUTAS POR POST
router.post("/agregar-grupo", directorController.PostAgregarGrupo);
router.post("/agregar-coordinadores",directorController.postAñadirCoordinador);
router.post("/agregar-subcoordinadores",directorController.postAgregarSubcoordinador);
router.post("/agregar-dirigente",directorController.postAgregarDirigente)

module.exports = router;