const express = require("express");
const directorController = require("../controllers/directorController");
const authorizeRoles = require("../Middlewares/authorizeRole"); // Importa el middleware

const router = express.Router();

// Rutas sin protección de roles
router.get("/director-home", authorizeRoles,directorController.getHome);
router.get("/grupos", authorizeRoles,directorController.getGrupos);
router.get("/coordinadores", authorizeRoles,directorController.getCoordinadores);
router.get("/subcoordinadores", authorizeRoles,directorController.getSubCoordinadores);
router.get("/dirigentes",authorizeRoles, directorController.getDirigentes);
router.get("/votantes",authorizeRoles,directorController.getVotantesDirector);

// Rutas protegidas con el middleware authorizeRoles
router.get("/agregar-grupo", authorizeRoles, directorController.getAgregarGrupos);
router.get("/agregar-coordinadores", authorizeRoles,directorController.getAgregarCoordinador);
router.get("/agregar-subcoordinadores", authorizeRoles,directorController.getAgregarSubCoordinador);
router.get("/agregar-dirigente",  authorizeRoles,directorController.getAgregarDirigente);
router.get("/agregar-votante", directorController.getAgregarVotante)
router.get("/editar-coordinador/:coordinadorId",authorizeRoles, directorController.GetEditCoordinador);



// Rutas por POST
router.post("/agregar-grupo", authorizeRoles, directorController.PostAgregarGrupo);
router.post("/agregar-coordinadores", authorizeRoles, directorController.postAñadirCoordinador);
router.post("/agregar-subcoordinadores", authorizeRoles, directorController.postAgregarSubcoordinador);
router.post("/agregar-dirigente", authorizeRoles, directorController.postAgregarDirigente);
router.post("/editar-coordinador", authorizeRoles,directorController.PostEditCoordinador);
router.post("/agregar-votante",directorController.postAñadirVotante)
module.exports = router;