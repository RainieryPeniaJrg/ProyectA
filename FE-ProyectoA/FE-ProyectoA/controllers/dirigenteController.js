exports.getHome = async (req, res) => {
    try {
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

        const respuesta = await req.axiosInstance.post('/Votantes/Create', nuevoVotante);
        console.log(respuesta);
        res.redirect('/votantes');
    } catch (error) {
        console.error('Error al añadir el votante:', error);
        res.status(error.response.status || 500).json({ mensaje: error.message || 'Error al añadir el votante' });
    }
};

exports.getVotantesDirigente = async (req, res) => {
    try {
        const respuesta = await req.axiosInstance.get(`/Dirigentes/GetAllVotantesByMemberId/${req.session.userId}`);
        const votantes = respuesta.data;
        res.render("dirigente/dirigente-votantes", {
            title: "Votantes",
            votantes: votantes
        });
    } catch (error) {
        console.error('Error al obtener los votantes:', error);
        res.status(error.response.status || 500).json({ mensaje: error.message || 'Error al obtener los votantes' });
    }
};

exports.getVotosDirigenteId = async (req, res) => {
    const { id } = req.params; // ID del coordinador obtenido de los parámetros de la URL
    try {
        // Realizar la solicitud HTTP al endpoint específico del coordinador
        const respuesta = await req.axiosInstance.get(`/Dirigentes/GetAllVotantesByMemberId/${id}`, {
            headers: {
                'Content-Type': 'application/json',
                'accept': '*/*'
            }
        });

        // Extraer los datos de la respuesta
        const votantes = respuesta.data;

        // Renderizar la vista con los datos de los votantes del coordinador
        res.render("votantesWithId/VotantesD", {
            title: "Votos del Dirigente",
            votantes: votantes,
            
            
        });
        console.log(votantes)
    } catch (error) {
        // Manejar cualquier error
        console.error('Error al obtener los votos del Dirigente:', error);
        res.status(500).json({ mensaje: 'Error al obtener los votos del Dirigente' });
    }
};