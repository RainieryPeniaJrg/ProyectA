express = require("express");
const { post } = require("jquery");
const votanteController = require("../controllers/votanteController");


const router = express.Router();





router.get("/agregar-votante", votanteController.getAgregarVotante);
router.post("/agregar-votante", votanteController.postAñadirVotante);





module.exports = router;