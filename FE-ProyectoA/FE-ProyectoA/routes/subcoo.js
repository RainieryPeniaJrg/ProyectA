express = require("express");
const subController = require("../controllers/SubController");
const router = express.Router();
const authorizeRoles = require('../Middlewares/authorizeRole'); // Impor

router.get("/subcoo-subcoordinador", (req, res, next) => {
    authorizeRoles(["Subcoordinador"])(req, res, next);
}, subController.getHome);

router.get("/subcoo-dirigente", (req, res, next) => {
    authorizeRoles(["Subcoordinador"])(req, res, next);
}, subController.getDirigentesSubCoo);

router.get("/votantes-subcoordinador", (req, res, next) => {
    authorizeRoles(["Subcoordinador"])(req, res, next);
}, subController.getVotantesSubCoo);

router.get("/subcoo-agregar-votante", (req, res, next) => {
    authorizeRoles(["Subcoordinador"])(req, res, next);
}, subController.getAgregarVotanteSubCoo);

router.get("/subcoo-agregar-dirigente", (req, res, next) => {
    authorizeRoles(["Subcoordinador"])(req, res, next);
}, subController.getAgregarDirigenteSubCoo);


router.post("/subcoo-agregar-votante", (req, res, next) => {
    authorizeRoles(["Subcoordinador"])(req, res, next);
}, subController.postAñadirVotanteSubCoo);

router.post("/subcoo-agregar-dirigente", (req, res, next) => {
    authorizeRoles(["Subcoordinador"])(req, res, next);
}, subController.postAgregarDirigenteSubCoo);

router.get('/votos-Sub/:id', subController.getVotosSubId)
module.exports = router;