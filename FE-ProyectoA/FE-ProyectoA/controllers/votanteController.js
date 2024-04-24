const axios = require("axios");
const https = require('https');



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
        
        const { nombre, apellido, cantidadVotantes, cedula, numeroTelefono, activo, sector, provincia } = req.body;

       
        const nuevoVotante = {
            nombre,
            apellido,
            cantidadVotantes,
            cedula,
            numeroTelefono,
            activo,
            sector,
            provincia
        };

        
        const respuesta = await axios.post('https://localhost:7299/api/Votantes/Create', nuevoVotante, {
            headers: {
                'Content-Type': 'application/json',
                'accept': '*/*'
            },
            httpsAgent: new https.Agent({ rejectUnauthorized: false }) 
        });

        
        res.redirect('/director'); 
    } catch (error) {
        
        console.error('Error al añadir el votante:', error);
        res.status(500).json({ mensaje: 'Error al añadir el votante' });
    }
};