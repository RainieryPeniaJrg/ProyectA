const axios = require("axios");
const { METHODS } = require("http");
const https = require('https');
const id = 'DBCA455A-C2B9-4D54-8CC6-C9FDFAEBAEEA'
const token = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJhZG1pbkBhZG1pbi5jb20iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiQWRtaW4iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsIkZ1bGxOYW1lIjoiQWRtaW4iLCJleHAiOjE3MTQxMTA3NTEsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjcyOTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjQwMDAifQ.d28CmwuEa3zhZ20PNqigLPIXVPfiQt_rYpmYOZefRMo'
const config = {
    headers: {
      'Authorization': `Bearer ${token}`,
      'Content-Type': 'application/json'
    }
  };
  exports.getHome = async (req, res) => {
    try {
        const agent = new https.Agent({ rejectUnauthorized: false });
        const token = "<YourAccessToken>"; // Asegúrate de tener el token adecuado

        // Función para obtener y sumar la cantidad de votantes de un endpoint
        const obtenerYSumarCantidadVotantes = async (url) => {
            const respuesta = await axios.get(url, {
                headers: {
                    'Content-Type': 'application/json',
                    'accept': '*/*',
                    'Authorization': `Bearer ${token}`
                },
                httpsAgent: agent
            });

            // Sumar la cantidad de votantes de todas las respuestas
            return respuesta.data.reduce((total, item) => total + item.cantidadVotantes.value, 0);
        };

        // URLs de los endpoints GetAll
        const urls = [
            'https://localhost:7299/api/CoordinadoresGeneral/GetAll',
            'https://localhost:7299/api/SubCoordinador/GetAll',
            'https://localhost:7299/api/Dirigentes/GetAll'
        ];

        // Sumar la cantidad de votantes de todos los endpoints
        const sumaCantidadVotantes = await Promise.all(urls.map(obtenerYSumarCantidadVotantes));
        
        // Sumar todas las cantidades
        const totalCantidadVotantes = sumaCantidadVotantes.reduce((total, cantidad) => total + cantidad, 0);

        // Renderizar la vista home con el total de cantidad de votantes
        res.render("director/home", {
            title: "Home",
            totalCantidadVotantes: totalCantidadVotantes
        });

    } catch (error) {
        console.error('Error al obtener la información:', error);
        res.status(500).json({ mensaje: 'Error al obtener la información' });
    }
};

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
        // Configura el agente HTTPS con la verificación del certificado deshabilitada
        const agent = new https.Agent({ rejectUnauthorized: false });

        // Realiza la solicitud con Axios, pasando el agente con la verificación del certificado deshabilitada
        const respuesta = await axios.get('https://localhost:7299/api/CoordinadoresGeneral/GetAll', {
            headers: {
                'Content-Type': 'application/json',
                'accept': '*/*',
               
            },
            httpsAgent: agent // Utiliza el agente HTTPS configurado
        });

        const coordinadores = respuesta.data;
        console.log(coordinadores);

        res.render("director/coordinadores", {
            title: "Coordinadores",
            coordinadores: coordinadores
        });
    } catch (error) {
        console.log(error.response.data.errors)
        res.status(500).json({ mensaje: 'Error al obtener los coordinadores' });
    }
};


exports.getSubCoordinadores = async (req, res) => {
    try {
        //NOTA> agregar url correcto de la api para traer los Subcoordinadores
        const agent = new https.Agent({ rejectUnauthorized: false });

        const respuesta = await axios.get('https://localhost:7299/api/SubCoordinador/GetAll', {
            headers: {
                'Content-Type': 'application/json',
                'accept': '*/*',
                'Authorization': `Bearer ${token}`
            },
            httpsAgent: agent // Utiliza el agente HTTPS configurado
        });

        const subCoordinadores = respuesta.data;

        console.log(respuesta.data);

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

        res.render("director/dirigentes", {
            title: "Dirigentes",
            dirigentes: dirigentes
        });
    } catch (error) {
        console.error('Error al obtener los dirigentes:', error);
        res.status(500).json({ mensaje: 'Error al obtener los dirigentes' });
    }
};

exports.getAgregarGrupos = async (req, res, next) => {
    try {
      
        const subcoordinadores = await axios.get('http://localhost:7299/api/SubCoordinador/GetAll',{
            headers: {
                'Content-Type': 'application/json',
                'accept': '*/*'
            },
            httpsAgent: new https.Agent({ rejectUnauthorized: false }) 
        });
        const subCoordinador = subcoordinadores.data;



        const dirigentes = await axios.get('http://localhost:5030/api/Dirigentes/GetAlll',{
            headers: {
                'Content-Type': 'application/json',
                'accept': '*/*'
            },
            httpsAgent: new https.Agent({ rejectUnauthorized: false }) 
        });
        const dirigente = dirigentes.data;


        const coordinadores = await axios.get('http://localhost:5030/api/CoordinadoresGeneral/GetAl',{
            headers: {
                'Content-Type': 'application/json',
                'accept': '*/*'
            },
            httpsAgent: new https.Agent({ rejectUnauthorized: false }) 
        });
        const coordinador = coordinadores.data;


     
        res.render("miembros/agregar-grupos", {
            title: "Agregar Grupo",
            subCoordinador: subCoordinador,
            dirigente:dirigente,
            coordinador:coordinador
          
        });
    } catch (error) {
        console.error('Error al mostrar el formulario de agregar grupo:', error);
        next(error); 
    }
};



//Controlador para agregar grupo
exports.PostAgregarGrupo = async (req, res) => {
    try {
        
        const dirigentesIds = Array.isArray(dirigentesMultiplicadoresIds) ? dirigentesMultiplicadoresIds : [dirigentesMultiplicadoresIds];
        const subCoordinadoresIds = Array.isArray(subCoordinadoresIds) ? subCoordinadoresIds : [subCoordinadoresIds];
        const coordinadoresGeneralesIds = Array.isArray(coordinadoresGeneralesIds) ? coordinadoresGeneralesIds : [coordinadoresGeneralesIds];

        const nuevoGrupo = {
            nombreGrupo,
            dirigentesMultiplicadoresIds: dirigentesIds,
            subCoordinadoresIds,
            coordinadoresGeneralesIds,
            active
        };
        
        const respuesta = await axios.post('https://localhost:5030/api/Grupos/Create', nuevoGrupo,  {
            headers: {
                'Content-Type': 'application/json',
                'accept': '*/*'
            },
            httpsAgent: new https.Agent({ rejectUnauthorized: false }) 
        });
        res.redirect('/home'); 
    } catch (error) {
       console.log(error)
        console.error('Error al agregar el grupo:', error);
        res.status(500).json({ mensaje: 'Error al agregar el grupo' });
    }

};



exports.getAgregarCoordinador = async (req, res, next) => {
    try {
        

    
        res.render("miembros/agregar-coordinadores", {
            title: "Agregar Coordinador",
       
        });
    } catch (error) {
      
        console.error('Error al mostrar el formulario de agregar coordinaroes:', error);
        next(error); 
    }
};



exports.postAñadirCoordinador = async (req, res, next) => {
    try {
        const { nombre, apellido, cedula, numeroTelefono, sector, provincia, casaElectoral, activo } = req.body;

        const nuevoCoordinador = {
            nombre,
            apellido,
            cedula,
            numeroTelefono,
            sector,
            provincia,
            casaElectoral,
            cantidadVotantes, 
            activo
        };
const accessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJhZG1pbkBhZG1pbi5jb20iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiQWRtaW4iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsIkZ1bGxOYW1lIjoiQWRtaW4iLCJleHAiOjE3MTQwNzAwNDgsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjcyOTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjQwMDAifQ.klpocRFo8KcdwOAEmY4kycI68-AwuxtO34LQgVK_P9I";
        const respuesta = await axios.post('http://localhost:5030/api/CoordinadoresGeneral/GetAl', nuevoCoordinador, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'accept': '*/*',
                "Authorization": `Bearer ${accessToken}`
            },
            httpsAgent: new https.Agent({ rejectUnauthorized: false })
        });

        res.redirect('/home');
    } catch (error) {
        console.log(error.response.data.errors)
        res.status(500).json({ mensaje: 'Error al añadir el coordinador' });
    }
};

exports.getAgregarSubCoordinador = async (req, res, next) => {
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

    
        res.render("miembros/agregar-subcoordinador", {
            title: "Agregar SubCoordinador",
            coordinadores: coordinador
       
        });
    } catch (error) {
      
        console.error('Error al mostrar el formulario de agregar Subcoordinaroes:', error);
        next(error); 
    }
};


exports.postAgregarSubcoordinador = async (req, res, next) => {
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
        const respuesta = await axios.post('https://localhost:5030/api/SubCoordinador/Create', nuevoSubcoordinador, {
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

exports.getAgregarDirigente = async (req, res, next) => {
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


        const subcoordinadores = await axios.get('https://localhost:7299/api/SubCoordinador/GetAll', {
            headers: {
              'Content-Type': 'application/json',
              'accept': 'text/plain'
            },
            httpsAgent: new https.Agent({ rejectUnauthorized: false })
          }
        );

        const subcoordinador = subcoordinadores.data;

        res.render("miembros/agregar-dirigente", {
            title: "Agregar Dirigentes",
            coordinadores: coordinador,
            subcoordinadores: subcoordinador

       
        });
    } catch (error) {
      
        console.error('Error al mostrar el formulario de agregar Dirigentes:', error);
        next(error); 
    }
};


exports.postAgregarDirigente = async (req, res) => {
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

        const respuesta = await axios.post('https://localhost:5030/api/Dirigentes/Create', nuevoDirigente, {
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

exports.getVotantesDirector = async (req, res) => {
    try {
        // Configurar el agente HTTPS para ignorar los errores de certificado
        const agent = new https.Agent({ rejectUnauthorized: false });

        // Realizar la solicitud HTTP a la API con el agente configurado
        const respuesta = await axios.get(`https://localhost:7299/api/Director/GetAllVotantesByMemberId/${id}`,  {
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


exports.GetEditCoordinador = (req, res, next) => {
    const coordinadorId = req.params.coordinadorId;
    const edit = req.query.edit;

    


    if (!edit) {
        return res.redirect("/coordinadores")
    }
 
            res.render("miembros/agregar-coordinadores", {
                pageTittle: "Editar coordinador",
                editMode: edit,
                coordinadorId,
                
            })
        }




        exports.PostEditCoordinador = async (req, res, next) => {
       
            try {
               
           
                const { coordinadorId, nombre, apellido, cedula, numeroTelefono, sector, provincia, casaElectoral, activo, } = req.body;
        
                const editCoordinador = {
                    id: coordinadorId,
                    nombre,
                    apellido,
                    cedula,
                    numeroTelefono,
                    sector,
                    provincia,
                    casaElectoral,
                  
                    activo
                }
        
                const respuesta = await axios.put(`https://localhost:7299/api/CoordinadoresGeneral/Update/${coordinadorId}`,editCoordinador, {
                    headers: {
                        'Content-Type': 'application/json',
                        'accept': '*/*'
                    },
                    httpsAgent: new https.Agent({ rejectUnauthorized: false }) 
                });
                res.redirect('/home'); 
            } catch (error) {
                console.log(error.response.data.errors)
                res.status(500).json({ mensaje: 'Error al editar el dirigente' });
            }
        };
        
        


      