const axios = require("axios");
const https = require('https');
const id = "F8BD0159-B427-42F8-9CCD-EB5AF9BF5FF8"

exports.getHome = async (req, res) => {
    try {
        const agent = new https.Agent({ rejectUnauthorized: false });
        

        
        res.render("coordinador/coordinador-home", {
            title: "Home",
           
        });

    } catch (error) {
        console.error('Error al obtener la información:', error);
        res.status(500).json({ mensaje: 'Error al obtener la información' });
    }
};


exports.getSubCoordinadoresCoo = async (req, res) => {
    try {
       
        const agent = new https.Agent({ rejectUnauthorized: false });

        const respuesta = await axios.get('https://localhost:7299/api/SubCoordinador/GetAll', {
            headers: {
                'Content-Type': 'application/json',
                'accept': '*/*',
               
            },
            httpsAgent: agent 
        });

        const subCoordinadores = respuesta.data;

        console.log(respuesta.data);

        res.render("coordinador/coordinador-subcoordinadores", {
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
        //NOTA: Asegúrate de agregar la URL correcta de la API para traer los dirigentes
        const agent = new https.Agent({ rejectUnauthorized: false });

        const respuesta = await axios.get('https://localhost:7299/api/Dirigentes/GetAll', {
            headers: {
                'Content-Type': 'application/json',
                'accept': '*/*',
                // No necesitas autorización en este caso
            },
            httpsAgent: agent // Utiliza el agente HTTPS configurado
        });

        const dirigentes = respuesta.data;
        console.log(respuesta.data);

        res.render("coordinador/coordinador-dirigentes", {
            title: "Dirigentes",
            dirigentes: dirigentes
        });
    } catch (error) {
        console.error('Error al obtener los dirigentes:', error);
        res.status(500).json({ mensaje: 'Error al obtener los dirigentes' });
    }
};


exports.getAgregarVotanteCoo = async (req, res, next) => {
    try {
        

    
        res.render("votante/agregar-votante", {
            title: "Agregar Votante",
       
        });
    } catch (error) {
      
        console.error('Error al mostrar el formulario de agregar votante:', error);
        next(error); 
    }
};



exports.postAñadirVotanteCoo = async (req, res, next) => {
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

exports.getVotantesCoo = async (req, res) => {
    try {
        
        const agent = new https.Agent({ rejectUnauthorized: false });

       
        const respuesta = await axios.get(`https://localhost:7299/api/CoordinadoresGeneral/GetAllVotantesByMemberId/${id}`,  {
            headers: {
                'Content-Type': 'application/json',
                'accept': '*/*',
                
              
            },
            httpsAgent: agent 
        });

      
        const votantes = respuesta.data;
        console.log(votantes);
        
        res.render("coordinador/coordinador-votantes", {
            title: "Votantes",
            votantes: votantes
        });
    } catch (error) {
    
        console.error('Error al obtener los votantes:', error);
        res.status(500).json({ mensaje: 'Error al obtener los votantes' });
    }
};


exports.getAgregarSubCoordinadorCoo = async (req, res, next) => {
    try {
        
        const coordinadores = await axios.get('https://localhost:7299/api/CoordinadoresGeneral/GetAll', {
            headers: {
              'Content-Type': 'application/json',
              'accept': 'text/plain'
            },
            httpsAgent: new https.Agent({ rejectUnauthorized: false })
          }
        );

        const coordinador = coordinadores.data;

    
        res.render("coordinador/coordinador-agregar-subcoo", {
            title: "Agregar SubCoordinador",
            coordinadores: coordinador
       
        });
    } catch (error) {
      
        console.error('Error al mostrar el formulario de agregar Subcoordinaroes:', error);
        next(error); 
    }
};


exports.postAgregarSubcoordinadorCoo = async (req, res, next) => {
    try {
        // Obtener los datos del formulario enviado por el cliente
        const { nombre, apellido, cantidadVotantes, cedula, activo, provincia, sector, casaElectoral, numeroTelefono, coordinadorsGeneralesId } = req.body;

        // Crear el objeto de subcoordinador con los datos recibidos
        const nuevoSubcoordinador = {
            nombre,
            apellido,
            cedula,
            provincia,
            sector,
            casaElectoral,
            numeroTelefono,
            coordinadorsGeneralesId
        };

        // Hacer la solicitud POST a la API para agregar un subcoordinador
        const respuesta = await axios.post('https://localhost:7299/api/SubCoordinador/Create', nuevoSubcoordinador, {
            headers: {
                'Content-Type': 'application/json',
                'accept': '*/*'
            },
            httpsAgent: new https.Agent({ rejectUnauthorized: false }) 
        });

        // Redirigir al usuario a la página de inicio después de agregar el subcoordinador exitosamente
        res.redirect('/home'); 
    } catch (error) {
        // Manejar errores
        console.error('Error al añadir el subcoordinador:', error);
        res.status(500).json({ mensaje: 'Error al añadir el subcoordinador' });
    }
};


exports.getAgregarDirigenteCoo = async (req, res, next) => {
    try {



        const subcoordinadores = await axios.get('https://localhost:7299/api/SubCoordinador/GetAll', {
            headers: {
              'Content-Type': 'application/json',
              'accept': 'text/plain'
            },
            httpsAgent: new https.Agent({ rejectUnauthorized: false })
          }
        );

        const subcoordinador = subcoordinadores.data;

        res.render("coordinador/coordinador-agregar-dirigente", {
            title: "Agregar Dirigentes",
            subcoordinadores: subcoordinador

       
        });
    } catch (error) {
      
        console.error('Error al mostrar el formulario de agregar Dirigentes:', error);
        next(error); 
    }
};


exports.postAgregarDirigenteCoo = async (req, res) => {
    try {
        const { nombre, apellido, cantidadVotantes, cedula, numeroTelefono, provincia, sector, casaElectoral, activo, subCoordinadoresId } = req.body;

        const nuevoDirigente = {
            nombre,
            apellido,
        
            cedula,
            numeroTelefono,
            provincia,
            sector,
            casaElectoral,
            subCoordinadoresId
        };

        const respuesta = await axios.post('https://localhost:7299/api/Dirigentes/Create', nuevoDirigente, {
            headers: {
                'Content-Type': 'application/json',
                'accept': '*/*'
            },
            httpsAgent: new https.Agent({ rejectUnauthorized: false }) 
        });
        res.redirect('/home'); 
    } catch (error) {
        console.error('Error al agregar el dirigente:', error);
        res.status(500).json({ mensaje: 'Error al agregar el dirigente' });
    }
};