const dirigenteController = require("../controllers/dirigenteController")
express = require("express");
const router = express.Router();
router.get("/home-dirigente",dirigenteController.getHome)
router.get("/votantes-dirigente",dirigenteController.getVotantesDirigente)
router.get("/dirigente-agregar-votante", dirigenteController.getAgregarVotanteDirigente)


router.post("/dirigente-agregar-votante", dirigenteController.postAñadirVotanteDirigente)

module.exports = router;