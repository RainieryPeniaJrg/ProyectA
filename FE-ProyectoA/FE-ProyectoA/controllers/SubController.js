
exports.getHome = async (req, res) => {
    try {
        // No necesitas crear un nuevo agente HTTPS aquí, ya que la instancia de Axios tiene uno configurado

        // Renderizar la vista home con el total de cantidad de votantes
        res.render("subcoordinador/subcoo-home", {
            title: "Home",
        });
        res.redirect('/subcoo-home')
    } catch (error) {
        console.error('Error al obtener la información:', error);
        res.status(500).json({ mensaje: 'Error al obtener la información' });
    }
};

exports.getDirigentesSubCoo = async (req, res) => {
    try {
        // Realizar la solicitud HTTP para obtener la lista de dirigentes
        const respuesta = await req.axiosInstance.get('Dirigentes/GetAll');

        // Extraer los datos de la respuesta
        const dirigentes = respuesta.data;

        // Renderizar la vista con los datos de los dirigentes
        res.render("subcoordinador/subcoo-dirigente", {
            title: "Dirigentes",
            dirigentes: dirigentes
        });
    } catch (error) {
        console.error('Error al obtener los dirigentes:', error);
        res.status(500).json({ mensaje: 'Error al obtener los dirigentes' });
    }
};


exports.getAgregarVotanteSubCoo = async (req, res, next) => {
    try {
        res.render("votante/agregar-votante", {
            title: "Agregar Votante",
        });
    } catch (error) {
        console.error('Error al mostrar el formulario de agregar votante:', error);
        next(error); 
    }
};

exports.postAñadirVotanteSubCoo = async (req, res, next) => {
    try {
        const nuevoVotante = req.body;

        // Realizar la solicitud HTTP para agregar un nuevo votante
        await req.axiosInstance.post('Votantes/Create', nuevoVotante);

        res.redirect('/votantes'); 
    } catch (error) {
        console.error('Error al añadir el votante:', error);
        res.status(500).json({ mensaje: 'Error al añadir el votante' });
    }
};


exports.getVotantesSubCoo = async (req, res) => {
    try {
        // Realizar la solicitud HTTP para obtener los votantes del subcoordinador
        const respuesta = await req.axiosInstance.get(`SubCoordinador/GetAllVotantesByMemberId/${req.session.userId}`);

        // Extraer los datos de la respuesta
        const votantes = respuesta.data;

        // Renderizar la vista con los datos de los votantes
        res.render("subcoordinador/subcoo-votantes", {
            title: "Votantes",
            votantes: votantes
        });
    } catch (error) {
        console.error('Error al obtener los votantes:', error);
        res.status(500).json({ mensaje: 'Error al obtener los votantes' });
    }
};


exports.getAgregarDirigenteSubCoo = async (req, res, next) => {
    try {
        const subcoordinadoresRespuesta = await req.axiosInstance.get('SubCoordinador/GetAll');

        const subcoordinadores = subcoordinadoresRespuesta.data;

        res.render("subcoordinador/subcoo-agregar-dirigente", {
            title: "Agregar Dirigentes",
            subcoordinadores: subcoordinadores
        });
    } catch (error) {
        console.error('Error al mostrar el formulario de agregar Dirigentes:', error);
        next(error); 
    }
}

exports.postAgregarDirigenteSubCoo = async (req, res) => {
    try {
        const nuevoDirigente = req.body;

        // Realizar la solicitud HTTP para agregar un nuevo dirigente
        await req.axiosInstance.post('Dirigentes/Create', nuevoDirigente);

        res.redirect('/home'); 
    } catch (error) {
        console.error('Error al agregar el dirigente:', error);
        res.status(500).json({ mensaje: 'Error al agregar el dirigente' });
    }
}


exports.getVotosSubId = async (req, res) => {
    const { id } = req.params; // ID del coordinador obtenido de los parámetros de la URL
    try {
        // Realizar la solicitud HTTP al endpoint específico del coordinador
        const respuesta = await req.axiosInstance.get(`/SubCoordinador/GetAllVotantesByMemberId/${id}`, {
            headers: {
                'Content-Type': 'application/json',
                'accept': '*/*'
            }
        });

        // Extraer los datos de la respuesta
        const votantes = respuesta.data;

        // Renderizar la vista con los datos de los votantes del coordinador
        res.render("votantesWithId/VotanteS", {
            title: "Votos del Sub Coordinador",
            votantes: votantes,
            
            
        });
        console.log(votantes)
    } catch (error) {
        // Manejar cualquier error
        console.error('Error al obtener los votos del Subcoordinador:', error);
        res.status(500).json({ mensaje: 'Error al obtener los votos del Subcoordinador' });
    }
};