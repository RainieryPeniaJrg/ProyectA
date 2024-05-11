express = require("express");

const votanteController = require("../controllers/votanteController");
const authorizeRoles = require('../Middlewares/authorizeRole'); // Impor

const router = express.Router();


router.get("/votantes", (req, res, next) => {
    authorizeRoles(["Director", "Coordinador", "Dirigente", "Subcoordinador"])(req, res, next);
}, votanteController.getVotantes);

router.get("/agregar-votante", (req, res, next) => {
    authorizeRoles(["Director", "Coordinador", "Dirigente", "Subcoordinador"])(req, res, next);
}, votanteController.getAgregarVotante);

router.post("/agregar-votante", (req, res, next) => {
    authorizeRoles(["Director", "Coordinador", "Dirigente", "Subcoordinador"])(req, res, next);
}, votanteController.postAñadirVotante);



module.exports = router;