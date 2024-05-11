
  exports.getHome = async (req, res) => {
    try {
        // Función para obtener y sumar la cantidad de votantes de un endpoint
       
        // Renderizar la vista home con el total de cantidad de votantes
        res.render("director/home", {
            title: "Home",
           
        });

    } catch (error) {
        console.error('Error al obtener la información:', error);
        res.status(500).json({ mensaje: 'Error al obtener la información' });
    }
};

exports.getGrupos = async (req, res) => {
    try {
        const respuesta = await req.axiosInstance.get('http://localhost:3000/2');

        const grupos = respuesta.data;

        res.render("director/grupos", {
            title: "Grupos",
            grupos: grupos
        });
    } catch (error) {
        console.error('Error al obtener los grupos:', error);
        res.status(500).json({ mensaje: 'Error al obtener los grupos' });
    }
};
exports.getCoordinadores = async (req, res) => {
    try {
        // Realizar la solicitud HTTP a la API utilizando el middleware de Axios configurado en req.axiosInstance
        const respuesta = await req.axiosInstance.get('/CoordinadoresGeneral/GetAll');

        // Extraer los datos de la respuesta
        const coordinadores = respuesta.data;

        // Renderizar la vista con los datos de los coordinadores
        res.render("director/coordinadores", {
            title: "Coordinadores",
            coordinadores: coordinadores
        });
    } catch (error) {
        // Manejar cualquier error
        console.error('Error al obtener los coordinadores:', error);
        res.status(error.response.status || 500).json({ mensaje: error.message || 'Error al obtener los coordinadores' });
    }
};
exports.getSubCoordinadores = async (req, res) => {
    try {
        // Realizar la solicitud HTTP a la API utilizando el middleware de Axios configurado en req.axiosInstance
        const respuesta = await req.axiosInstance.get('/SubCoordinador/GetAll');

        // Extraer los datos de la respuesta
        const subCoordinadores = respuesta.data;

        // Renderizar la vista con los datos de los subcoordinadores
        res.render("director/Subcoordinadores", {
            title: "SubCoordinadores",
            subCoordinadores: subCoordinadores
        });
    } catch (error) {
        // Manejar cualquier error
        console.error('Error al obtener los subcoordinadores:', error);
        res.status(error.response.status || 500).json({ mensaje: error.message || 'Error al obtener los subcoordinadores' });
    }
};
exports.getDirigentes = async (req, res) => {
    try {
        // Realizar la solicitud HTTP a la API utilizando el middleware de Axios configurado en req.axiosInstance
        const respuesta = await req.axiosInstance.get('/Dirigentes/GetAll');

        // Extraer los datos de la respuesta
        const dirigentes = respuesta.data;

        // Renderizar la vista con los datos de los dirigentes
        res.render("director/dirigentes", {
            title: "Dirigentes",
            dirigentes: dirigentes
        });
    } catch (error) {
        // Manejar cualquier error
        console.error('Error al obtener los dirigentes:', error);
        res.status(500).json({ mensaje: 'Error al obtener los dirigentes' });
    }
};
exports.getAgregarGrupos = async (req, res, next) => {
    try {
        const subCoordinadorPromise = req.axiosInstance.get('/SubCoordinador/GetAll');
        const dirigentePromise = req.axiosInstance.get('/Dirigentes/GetAll');
        const coordinadorPromise = req.axiosInstance.get('/CoordinadoresGeneral/GetAll');

        // Ejecutar todas las solicitudes de manera concurrente
        const [subCoordinadorResp, dirigenteResp, coordinadorResp] = await Promise.all([
            subCoordinadorPromise,
            dirigentePromise,
            coordinadorPromise
        ]);

        const subCoordinador = subCoordinadorResp.data;
        const dirigente = dirigenteResp.data;
        const coordinador = coordinadorResp.data;

        res.render("miembros/agregar-grupos", {
            title: "Agregar Grupo",
            subCoordinador: subCoordinador,
            dirigente: dirigente,
            coordinador: coordinador
        });
    } catch (error) {
        console.error('Error al mostrar el formulario de agregar grupo:', error);
        next(error);
    }
};


exports.PostAgregarGrupo = async (req, res) => {
    try {
        // Obtener los datos del formulario enviado por el cliente
        const { nombreGrupo, dirigentesMultiplicadoresIds, subCoordinadoresIds, coordinadoresGeneralesIds, active } = req.body;

        // Convertir las IDs en arrays si no lo son
        const dirigentesIds = Array.isArray(dirigentesMultiplicadoresIds) ? dirigentesMultiplicadoresIds : [dirigentesMultiplicadoresIds];
        const subCoordinadoresIdsArray = Array.isArray(subCoordinadoresIds) ? subCoordinadoresIds : [subCoordinadoresIds];
        const coordinadoresGeneralesIdsArray = Array.isArray(coordinadoresGeneralesIds) ? coordinadoresGeneralesIds : [coordinadoresGeneralesIds];

        // Crear el objeto de nuevo grupo con los datos recibidos
        const nuevoGrupo = {
            nombreGrupo,
            dirigentesMultiplicadoresIds: dirigentesIds,
            subCoordinadoresIds: subCoordinadoresIdsArray,
            coordinadoresGeneralesIds: coordinadoresGeneralesIdsArray,
            active
        };

        // Hacer la solicitud POST a la API para agregar un grupo utilizando el módulo Axios y el middleware configurado
        await req.axiosInstance.post('/Grupos/Create', nuevoGrupo);

        // Redirigir al usuario a la página de inicio después de agregar el grupo exitosamente
        res.redirect('/home');
    } catch (error) {
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
            activo
        };

        // Este token parece ser un token de prueba. No debería estar codificado en el código, sino almacenado de manera segura y obtenido según sea necesario.

        // Hacer la solicitud POST a la API para agregar un coordinador utilizando el módulo Axios y el middleware configurado
        const respuesta = await req.axiosInstance.post('/CoordinadoresGeneral/GetAl', nuevoCoordinador, {
            headers: {
                'Content-Type': 'application/json',
                'accept': '*/*',
            
            }
        });

        // Redirigir al usuario a la página de inicio después de agregar el coordinador exitosamente
        res.redirect('/home');
    } catch (error) {
        console.error('Error al añadir el coordinador:', error);
        res.status(500).json({ mensaje: 'Error al añadir el coordinador' });
    }
};

exports.getAgregarSubCoordinador = async (req, res, next) => {
    try {
        // Realizar la solicitud GET a la API para obtener los coordinadores generales utilizando el módulo Axios y el middleware configurado
        const coordinadores = await req.axiosInstance.get('/CoordinadoresGeneral/GetAll', {
            headers: {
                'Content-Type': 'application/json',
                'accept': 'text/plain'
            }
        });

        // Extraer los datos de los coordinadores generales de la respuesta
        const coordinador = coordinadores.data;

        // Renderizar la vista con los datos de los coordinadores generales
        res.render("miembros/agregar-subcoordinador", {
            title: "Agregar SubCoordinador",
            coordinadores: coordinador
        });
    } catch (error) {
        console.error('Error al mostrar el formulario de agregar Subcoordinadores:', error);
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

        // Hacer la solicitud POST a la API para agregar un subcoordinador utilizando el módulo Axios y el middleware configurado
        const respuesta = await req.axiosInstance.post('/SubCoordinador/Create', nuevoSubcoordinador);

        // Redirigir al usuario a la página de inicio después de agregar el subcoordinador exitosamente
        res.redirect('/home');
    } catch (error) {
        // Manejar errores
        console.error('Error al añadir el subcoordinador:', error);
        res.status(500).json({ mensaje: 'Error al añadir el subcoordinador' });
    }
}

exports.getAgregarDirigente = async (req, res, next) => {
    try {
        // Realizar la solicitud GET a la API para obtener los coordinadores generales utilizando el módulo Axios y el middleware configurado
        const coordinadoresResp = await req.axiosInstance.get('/CoordinadoresGeneral/GetAll', {
            headers: {
                'Content-Type': 'application/json',
                'accept': 'text/plain'
            }
        });

        // Realizar la solicitud GET a la API para obtener los subcoordinadores utilizando el módulo Axios y el middleware configurado
        const subcoordinadoresResp = await req.axiosInstance.get('/SubCoordinador/GetAll', {
            headers: {
                'Content-Type': 'application/json',
                'accept': 'text/plain'
            }
        });

        // Extraer los datos de los coordinadores generales y subcoordinadores de las respuestas
        const coordinadores = coordinadoresResp.data;
        const subcoordinadores = subcoordinadoresResp.data;

        // Renderizar la vista con los datos de los coordinadores generales y subcoordinadores
        res.render("miembros/agregar-dirigente", {
            title: "Agregar Dirigentes",
            coordinadores: coordinadores,
            subcoordinadores: subcoordinadores
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

        // Hacer la solicitud POST a la API para agregar un dirigente utilizando el módulo Axios y el middleware configurado
        const respuesta = await req.axiosInstance.post('/Dirigentes/Create', nuevoDirigente);

        // Redirigir al usuario a la página de inicio después de agregar el dirigente exitosamente
        res.redirect('/home');
    } catch (error) {
        console.error('Error al agregar el dirigente:', error);
        res.status(500).json({ mensaje: 'Error al agregar el dirigente' });
    }
};


exports.getVotantesDirector = async (req, res) => {
    try {
        // Realizar la solicitud HTTP a la API utilizando el módulo Axios y el middleware configurado
        const respuesta = await req.axiosInstance.get(`/Director/GetAllVotantesByMemberId/${req.params.id}`, {
            headers: {
                'Content-Type': 'application/json',
                'accept': '*/*'
            }
        });

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

