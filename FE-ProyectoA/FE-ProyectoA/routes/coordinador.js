express = require("express");
const { post } = require("jquery");
const coordinadorController = require("../controllers/coordinadorController");


const router = express.Router();





router.get("/coordinador-home",coordinadorController.getHome );

router.get("/coordinador-subcoordinadores", coordinadorController.getSubCoordinadoresCoo);
router.get("/coordinador-dirigentes", coordinadorController.getDirigentes);
router.get("/coordinador-agregar-votante", coordinadorController.getAgregarVotanteCoo)
router.get("/coordinador-agregar-subcoordinadores",coordinadorController.getAgregarSubCoordinadorCoo)
router.get("/coordinador-agregar-dirigente", coordinadorController.getAgregarDirigenteCoo)
router.get("/votantes-coordinador", coordinadorController.getVotantesCoo)
//RUTAS POR POST
router.post("/coordinador-agregar-votante", coordinadorController.postAñadirVotanteCoo)
router.post("/coordinador-agregar-subcoordinadores",coordinadorController.postAgregarSubcoordinadorCoo);
router.post("/coordinador-agregar-dirigente", coordinadorController.postAgregarDirigenteCoo)

module.exports = router;