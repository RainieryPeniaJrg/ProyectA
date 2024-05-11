const axios = require("axios");
const https = require('https');


exports.getHome = async (req, res) => {
    try {
        res.render("coordinador/coordinador-home", {
            title: "Home"
        });
    } catch (error) {
        console.error('Error al obtener la información:', error);
        res.status(500).json({ mensaje: 'Error al obtener la información' });
    }
};

exports.getSubCoordinadoresCoo = async (req, res) => {
    try {
        //NOTA: Asegúrate de agregar la URL correcta de la API para traer los subcoordinadores

        // Realizar la solicitud GET a la API utilizando el módulo Axios y el middleware configurado
        const respuesta = await req.axiosInstance.get('/SubCoordinador/GetAll', {
            headers: {
                'Content-Type': 'application/json',
                'accept': '*/*',
            }
        });

        // Extraer los datos de la respuesta
        const subCoordinadores = respuesta.data;

        // Renderizar la vista con los datos de los subcoordinadores
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

        // Realizar la solicitud GET a la API utilizando el módulo Axios y el middleware configurado
        const respuesta = await req.axiosInstance.get('/Dirigentes/GetAll');

        // Extraer los datos de la respuesta
        const dirigentes = respuesta.data;

        // Renderizar la vista con los datos de los dirigentes
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
            title: "Agregar Votante"
        });
    } catch (error) {
        console.error('Error al mostrar el formulario de agregar votante:', error);
        next(error);
    }
};


exports.postAñadirVotanteCoo = async (req, res, next) => {
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

        // Realizar la solicitud POST a la API utilizando el módulo Axios y el middleware configurado
        await req.axiosInstance.post('/Votantes/Create', nuevoVotante);

        // Redirigir al usuario a la página de votantes después de agregar el votante
        res.redirect('/votantes'); 
    } catch (error) {
        console.error('Error al añadir el votante:', error);
        res.status(500).json({ mensaje: 'Error al añadir el votante' });
    }
};

exports.getVotantesCoo = async (req, res) => {
    try {
        // Realizar la solicitud HTTP a la API utilizando el módulo Axios y el middleware configurado
        const respuesta = await req.axiosInstance.get(`/CoordinadoresGeneral/GetAllVotantesByMemberId/${req.body.memberId}`);

        // Extraer los datos de la respuesta
        const votantes = respuesta.data;

        // Renderizar la vista con los datos de los votantes
        res.render("coordinador/coordinador-votantes", {
            title: "Votantes",
            votantes: votantes
        });
    } catch (error) {
        // Manejar cualquier error
        console.error('Error al obtener los votantes:', error);
        res.status(error.response.status || 500).json({ mensaje: error.message || 'Error al obtener los votantes' });
    }
};
exports.getAgregarSubCoordinadorCoo = async (req, res, next) => {
    try {
        // Realizar la solicitud HTTP a la API utilizando el módulo Axios y el middleware configurado
        const respuesta = await req.axiosInstance.get('/CoordinadoresGeneral/GetAll', {
            headers: {
                'Content-Type': 'application/json',
                'accept': 'text/plain'
            }
        });

        // Extraer los datos de la respuesta
        const coordinador = respuesta.data;

        // Renderizar la vista con los datos de los coordinadores
        res.render("coordinador/coordinador-agregar-subcoo", {
            title: "Agregar SubCoordinador",
            coordinadores: coordinador
        });
    } catch (error) {
        // Manejar cualquier error
        console.error('Error al mostrar el formulario de agregar Subcoordinadores:', error);
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

        // Hacer la solicitud POST a la API para agregar un subcoordinador utilizando el módulo Axios y el middleware configurado
        const respuesta = await req.axiosInstance.post('/SubCoordinador/Create', nuevoSubcoordinador);

        // Redirigir al usuario a la página de inicio después de agregar el subcoordinador exitosamente
        res.redirect('/home'); 
    } catch (error) {
        // Manejar errores
        console.error('Error al añadir el subcoordinador:', error);
        res.status(error.response.status || 500).json({ mensaje: error.message || 'Error al añadir el subcoordinador' });
    }
};
exports.getAgregarDirigenteCoo = async (req, res, next) => {
    try {
        // Realizar una solicitud para obtener la lista de subcoordinadores
        const subcoordinadores = await req.axiosInstance.get('/SubCoordinador/GetAll', {
            headers: {
                'Content-Type': 'application/json',
                'accept': 'text/plain'
            }
        });

        // Extraer los datos de la respuesta
        const subcoordinador = subcoordinadores.data;

        // Renderizar la vista con los datos de los subcoordinadores
        res.render("coordinador/coordinador-agregar-dirigente", {
            title: "Agregar Dirigentes",
            subcoordinadores: subcoordinador
        });
    } catch (error) {
        // Manejar cualquier error
        console.error('Error al mostrar el formulario de agregar Dirigentes:', error);
        next(error); 
    }
};

exports.postAgregarDirigenteCoo = async (req, res) => {
    try {
        const { nombre, apellido, cedula, numeroTelefono, provincia, sector, casaElectoral, activo, subCoordinadoresId } = req.body;

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

        // Hacer la solicitud POST a la API para agregar un dirigente usando el axiosInstance del middleware
        const respuesta = await req.axiosInstance.post('/Dirigentes/Create', nuevoDirigente, {
            headers: {
                'Content-Type': 'application/json',
                'accept': '*/*'
            }
        });

        // Redirigir al usuario a la página de inicio después de agregar el dirigente exitosamente
        res.redirect('/home'); 
    } catch (error) {
        // Manejar errores
        console.error('Error al agregar el dirigente:', error);
        res.status(error.response.status || 500).json({ mensaje: error.message || 'Error al agregar el dirigente' });
    }
};

