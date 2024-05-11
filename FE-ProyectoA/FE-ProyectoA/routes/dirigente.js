const dirigenteController = require("../controllers/dirigenteController")
express = require("express");
const authorizeRoles = require("../Middlewares/authorizeRole"); // Importa
const router = express.Router();
router.get("/home-dirigente",authorizeRoles,dirigenteController.getHome)
router.get("/votantes-dirigente",authorizeRoles,dirigenteController.getVotantesDirigente)
router.get("/dirigente-agregar-votante", authorizeRoles,dirigenteController.getAgregarVotanteDirigente)


router.post("/dirigente-agregar-votante",authorizeRoles, dirigenteController.postAñadirVotanteDirigente)

module.exports = router;