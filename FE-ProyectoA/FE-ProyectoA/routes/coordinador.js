express = require("express");

const coordinadorController = require("../controllers/coordinadorController");
const authorizeRoles = require("../Middlewares/authorizeRole"); // Impor

const router = express.Router();





router.get("/coordinador-home",authorizeRoles,coordinadorController.getHome );

router.get("/coordinador-subcoordinadores", authorizeRoles,coordinadorController.getSubCoordinadoresCoo);
router.get("/coordinador-dirigentes",authorizeRoles, coordinadorController.getDirigentes);
router.get("/coordinador-agregar-votante",authorizeRoles, coordinadorController.getAgregarVotanteCoo)
router.get("/coordinador-agregar-subcoordinadores",authorizeRoles,coordinadorController.getAgregarSubCoordinadorCoo)
router.get("/coordinador-agregar-dirigente",authorizeRoles, coordinadorController.getAgregarDirigenteCoo)
router.get("/votantes-coordinador", authorizeRoles,coordinadorController.getVotantesCoo)
//RUTAS POR POST
router.post("/coordinador-agregar-votante", authorizeRoles,coordinadorController.postAñadirVotanteCoo)
router.post("/coordinador-agregar-subcoordinadores",authorizeRoles,coordinadorController.postAgregarSubcoordinadorCoo);
router.post("/coordinador-agregar-dirigente", authorizeRoles,coordinadorController.postAgregarDirigenteCoo)

module.exports = router;