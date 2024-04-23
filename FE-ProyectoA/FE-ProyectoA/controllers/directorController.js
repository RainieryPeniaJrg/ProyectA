const axios = require("axios");

exports.getHome = async (req, res) => {


    res.render("director/home", {
        title: "Home"
    });
    res.status(200);

}

exports.getGrupos = async (req, res) => {
    try {

        const respuesta = await axios.get('http://localhost:3000/2');


        const grupos = respuesta.data;


        res.render("director/grupos", {
            title: "Grupos",
            grupos: grupos

        });
    } catch (error) {
        // Manejar cualquier error
        console.error('Error al obtener los grupos:', error);
        res.status(500).json({ mensaje: 'Error al obtener los grupos' });
    }
};

exports.getCoordinadores = async (req, res) => {
    try {
        //NOTA> agregar url correcto de la api para traer los coordinadores
        const respuesta = await axios.get('http://localhost:3000/2');


        const coordinadores = respuesta.data;


        res.render("director/coordinadores", {
            title: "Coordinadores",
            coordinadores: coordinadores

        });
    } catch (error) {
        console.error('Error al obtener los coordinadores:', error);
        res.status(500).json({ mensaje: 'Error al obtener los coordinadores' });
    }
};



exports.getSubCoordinadores = async (req, res) => {
    try {
        //NOTA> agregar url correcto de la api para traer los Subcoordinadores
        const respuesta = await axios.get('http://localhost:3000/2');


        const subCoordinadores = respuesta.data;


        res.render("director/Subcoordinadores", {
            title: "SubCoordinadores",
            subCoordinadores: subCoordinadores

        });
    } catch (error) {
        console.error('Error al obtener los subcoordinadores:', error);
        res.status(500).json({ mensaje: 'Error al obtener los subcoordinadores' });
    }
};


exports.getDirigentes = async (req, res) => {
    try {
        //NOTA> agregar url correcto de la api para traer los dirigentes
        const respuesta = await axios.get('http://localhost:3000/2');


        const dirigentes = respuesta.data;


        res.render("director/dirigentes", {
            title: "dirigentes",
            dirigentes: dirigentes

        });
    } catch (error) {
        console.error('Error al obtener los dirigentes:', error);
        res.status(500).json({ mensaje: 'Error al obtener los dirigentes' });
    }
};