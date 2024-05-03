const https = require('https');
const axios = require("axios");

exports.getHome = async (req, res) => {
    try {
        const agent = new https.Agent({ rejectUnauthorized: false });
        

        // Renderizar la vista home con el total de cantidad de votantes
        res.render("dirigente/dirigente-home", {
            title: "Home",
           
        });

    } catch (error) {
        console.error('Error al obtener la información:', error);
        res.status(500).json({ mensaje: 'Error al obtener la información' });
    }
};



exports.getAgregarVotanteDirigente = async (req, res, next) => {
    try {
        

    
        res.render("votante/agregar-votante", {
            title: "Agregar Votante",
       
        });
    } catch (error) {
      
        console.error('Error al mostrar el formulario de agregar votante:', error);
        next(error); 
    }
};



exports.postAñadirVotanteDirigente = async (req, res, next) => {
    try {
        
        const { nombre, apellido,cedula, numeroTelefono, activo, sector, provincia,casaElectoral,miembroId } = req.body;

       
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

        
        const respuesta = await axios.post('https://localhost:7299/api/Votantes/Create', nuevoVotante, {
            headers: {
                'Content-Type': 'application/json',
                'accept': '*/*',
                
            },
            httpsAgent: new https.Agent({ rejectUnauthorized: false }) 
        });

        
        res.redirect('/votantes'); 
    } catch (error) {
        console.log(error.response.data.errors)
       // console.error('Error al añadir el votante:', error);
        res.status(500).json({ mensaje: 'Error al añadir el votante' });
    }
};

exports.getVotantesDirigente = async (req, res) => {
    try {
        // Configurar el agente HTTPS para ignorar los errores de certificado
        const agent = new https.Agent({ rejectUnauthorized: false });

        // Realizar la solicitud HTTP a la API con el agente configurado
        const respuesta = await axios.get('https://localhost:7299/api/Votantes/GetAll',  {
            headers: {
                'Content-Type': 'application/json',
                'accept': '*/*',
              
            },
            httpsAgent: agent // Utiliza el agente HTTPS configurado
        });

        // Extraer los datos de la respuesta
        const votantes = respuesta.data;
        console.log(votantes);
        // Renderizar la vista con los datos de los votantes
        res.render("dirigente/dirigente-votantes", {
            title: "Votantes",
            votantes: votantes
        });
    } catch (error) {
        // Manejar cualquier error
        console.error('Error al obtener los votantes:', error);
        res.status(500).json({ mensaje: 'Error al obtener los votantes' });
    }
};