const express = require("express");
const { engine } = require('express-handlebars');
const path = require("path")
const directorRoute = require('./routes/director')
const votanteRoute = require("./routes/votantes")
const sesionRoute = require("./routes/sesiones")
const dirigenteRoute = require("./routes/dirigente")
const coordRoute = require("./routes/coordinador")
const subRoute = require("./routes/subcoo")
const errorController = require("./controllers/errorController")
const { obtenerTotalCantidadVotantes } = require('./helpers/votosTotales') // Importa la función para obtener el total de cantidad de votantes
const axios = require('axios')
const bodyParser = require('body-parser');
const app = express();

app.use(bodyParser.urlencoded({ extended: false }));
app.use(bodyParser.json());

app.engine("hbs", engine({ layoutsDir: 'views/layouts/', defaultLayout: 'main-layout', extname: 'hbs' }));
app.set("view engine", "hbs");
app.set("views", "views") 

app.use(express.urlencoded({ extended: false }));
app.use(express.static(path.join(__dirname, "public")));

app.use(async (req, res, next) => {
    try {
 next()
    
        
    } catch (error) {
       next()
    }
});

app.use(sesionRoute)
app.use(directorRoute)
app.use(votanteRoute)
app.use(dirigenteRoute)
app.use(subRoute)
app.use(coordRoute)

//Error middleware
app.use("/", errorController.Get404)

app.listen(3001);