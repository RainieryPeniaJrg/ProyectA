express = require("express");
const subController = require("../controllers/SubController");
const router = express.Router();


router.get("/home-subcoordinador",subController.getHome)
router.get("/subcoo-dirigente",subController.getDirigentesSubCoo)
router.get("/votantes-subcoordinador", subController.getVotantesSubCoo)
router.get("/subcoo-agregar-votante",subController.getAgregarVotanteSubCoo)
router.get("/subcoo-agregar-dirigente",subController.getAgregarDirigenteSubCoo)

router.post("/subcoo-agregar-votante",subController.postAñadirVotanteSubCoo)
router.post("/subcoo-agregar-dirigente", subController.postAgregarDirigenteSubCoo)
module.exports = router;