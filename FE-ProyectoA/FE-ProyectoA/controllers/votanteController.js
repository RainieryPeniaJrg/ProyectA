const axios = require("axios");

exports.getAgregarVotante = async (req, res, next) => {
    try {
        res.render("votante/agregar-votante", {
            title: "Agregar Votante",
        });
    } catch (error) {
        console.error('Error al mostrar el formulario de agregar votante:', error);
        next(error);
    }
};

exports.postAñadirVotante = async (req, res, next) => {
    try {
        const { nombre, apellido, cedula, numeroTelefono, activo, sector, provincia, casaElectoral, miembroId } = req.body;
        const nuevoVotante = {
            nombre,
            apellido,
            cedula,
            numeroTelefono,
            activo,
            sector,
            provincia,
            casaElectoral,
            miembroId
        };

        const respuesta = await axios.post('/Votantes/Create', nuevoVotante);
        res.redirect('/votantes');
    } catch (error) {
        console.error('Error al añadir el votante:', error);
        res.status(error.response.status || 500).json({ mensaje: error.message || 'Error al añadir el votante' });
    }
};

exports.getVotantes = async (req, res) => {
    try {
        const respuesta = await axios.get('/Votantes/GetAll');
        const votantes = respuesta.data;
        res.render("votante/lista-votantes", {
            title: "Votantes",
            votantes: votantes
        });
    } catch (error) {
        console.error('Error al obtener los votantes:', error);
        res.status(error.response.status || 500).json({ mensaje: error.message || 'Error al obtener los votantes' });
    }
}