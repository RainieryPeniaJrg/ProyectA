express = require("express");
const directorController = require("../controllers/directorController");


const router = express.Router();





router.get("/", directorController.getGrupos)




//RUTAS POR GET
//router.get("/director", )
//router.get("/director/grupos", directorController.getGrupos);
//router.get("/director/coordinadores", );
//router.get("/director/subcoordinadores", );
//router.get("/director/dirigentes", );

//RUTAS POR POST
//router.post("/director/agregar-votante");


module.exports = router;