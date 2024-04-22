const express = require("express");
const { engine } = require('express-handlebars');
const path = require("path")
const directorRoute = require('./routes/director')
const errorController = require("./controllers/errorController")
const axios = require('axios')
const app = express();

app.engine("hbs", engine({ layoutsDir: 'views/layouts/', defaultLayout: '', extname: 'hbs' }));
app.set("view engine", "hbs");
app.set("views", "views") 



app.use(directorRoute)



app.use(express.urlencoded({ extended: false }));
app.use(express.static(path.join(__dirname, "public")));


//Error middleware
app.use("/", errorController.Get404)
app.listen(4000);