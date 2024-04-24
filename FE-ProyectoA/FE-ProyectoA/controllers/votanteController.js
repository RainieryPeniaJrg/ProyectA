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




exports.getVotantes = async (req, res) => {
    try {
        // Configurar el agente HTTPS para ignorar los errores de certificado
        const agent = new https.Agent({ rejectUnauthorized: false });

        // Realizar la solicitud HTTP a la API con el agente configurado
        const respuesta = await axios.get('https://localhost:7299/api/Votantes/GetAll', { httpsAgent: agent });

        // Extraer los datos de la respuesta
        const votantes = respuesta.data;

        // Renderizar la vista con los datos de los votantes
        res.render("votante/lista-votantes", {
            title: "Votantes",
            votantes: votantes
        });
    } catch (error) {
        // Manejar cualquier error
        console.error('Error al obtener los votantes:', error);
        res.status(500).json({ mensaje: 'Error al obtener los votantes' });
    }
};