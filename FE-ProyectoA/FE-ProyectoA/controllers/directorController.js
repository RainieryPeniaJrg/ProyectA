const axios = require("axios");

exports.getGrupos = async (req, res) => {
    try {

        const response = await axios.get('http://localhost:3000/1');
        res.render("director/index", {
            title: "ver grupos"
        });
        const grupos = response.data;
        console.log('Grupos:', grupos);
        res.status(200);
    } catch (error) {
        console.error('Error al obtener los grupos:', error.message);
        res.status(500).send('Error al obtener los grupos');
    }
}