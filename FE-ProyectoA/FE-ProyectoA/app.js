const express = require("express");
const { engine } = require('express-handlebars');
const session = require('express-session');
const path = require("path")
const crypto = require('crypto');
const directorRoute = require('./routes/director')
const votanteRoute = require("./routes/votantes")
const sesionRoute = require("./routes/sesiones")
const dirigenteRoute = require("./routes/dirigente")
const coordRoute = require("./routes/coordinador")
const subRoute = require("./routes/subcoo")
const errorController = require("./controllers/errorController")
const https = require('https');
const bodyParser = require('body-parser');
const app = express();
const axios = require('axios');
const secret = crypto.randomBytes(64).toString('hex');
const {obtenerTotalVotantes }= require('./helpers/obtenerTotalVotantes')
//configuracion exrpess session
app.use(session({
   secret: secret,
   resave: false,
   saveUninitialized: false
}));

//configuracion bodyparser
app.use(bodyParser.urlencoded({ extended: false }));
app.use(bodyParser.json());

//configuracion layouts
app.engine("hbs", engine({ layoutsDir: 'views/layouts/', defaultLayout: 'main-layout', extname: 'hbs' }));
app.set("view engine", "hbs");
app.set("views", "views") 

app.use(express.urlencoded({ extended: false }));
app.use(express.static(path.join(__dirname, "public")));




app.use(async (req, res, next) => {
   try {
       const axiosInstance = axios.create({
           baseURL: 'https://localhost:7299/api/',
           headers: {
               'Content-Type': 'application/json',
               'accept': '*/*'
           },
           httpsAgent: new https.Agent({ rejectUnauthorized: false })
       });

       const token = req.session.token;
       if (token) {
           axiosInstance.defaults.headers.common['Authorization'] = `Bearer ${token}`;
       }
  
       console.log(await obtenerTotalVotantes())
       const totalVotantes = await obtenerTotalVotantes();
       res.locals.totalVotantes = totalVotantes;
       res.locals.userId = req.session.userId;
       req.axiosInstance = axiosInstance; // Ajuste para adjuntar la instancia de Axios a req
       next();
   } catch (error) {
       next(error)
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

app.listen(4000)