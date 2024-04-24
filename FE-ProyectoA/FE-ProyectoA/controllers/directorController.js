const axios = require("axios");
const https = require('https');

exports.getHome = async (req, res) => {


    res.render("director/home", {
        title: "Home"
    });
    res.status(200);

}

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
        //NOTA> agregar url correcto de la api para traer los coordinadores
        const respuesta = await axios.get('http://localhost:3000/2');


        const coordinadores = respuesta.data;


        res.render("director/coordinadores", {
            title: "Coordinadores",
            coordinadores: coordinadores

        });
    } catch (error) {
        console.error('Error al obtener los coordinadores:', error);
        res.status(500).json({ mensaje: 'Error al obtener los coordinadores' });
    }
};



exports.getSubCoordinadores = async (req, res) => {
    try {
        //NOTA> agregar url correcto de la api para traer los Subcoordinadores
        const respuesta = await axios.get('http://localhost:3000/2');


        const subCoordinadores = respuesta.data;


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
        //NOTA> agregar url correcto de la api para traer los dirigentes
        const respuesta = await axios.get('http://localhost:3000/2');


        const dirigentes = respuesta.data;


        res.render("director/dirigentes", {
            title: "dirigentes",
            dirigentes: dirigentes

        });
    } catch (error) {
        console.error('Error al obtener los dirigentes:', error);
        res.status(500).json({ mensaje: 'Error al obtener los dirigentes' });
    }
};



exports.getAgregarGrupos = async (req, res, next) => {
    try {
      

     
        res.render("director/agregar-grupo", {
            title: "Agregar Grupo",
          
        });
    } catch (error) {
        console.error('Error al mostrar el formulario de agregar grupo:', error);
        next(error); 
    }
};



//Controlador para agregar grupo
exports.PostAgregarGrupo = async (req, res) => {
    try {
       
        const { NombreGrupo, SubCoordinadores, Coordinadoresgeneral, Dirigentes, totalVotos } = req.body;

      
        const nuevoGrupo = {
            NombreGrupo,
            SubCoordinadores,
            Coordinadoresgeneral,
            Dirigentes,
            totalVotos
        };

        console.log(nuevoGrupo)
        const respuesta = await axios.post('URL api ', nuevoGrupo);

       
        res.status(201).json(respuesta.data);
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
        // Obtener los datos del formulario enviado por el cliente
        const { nombre, apellido, cedula, numeroTelefono, sector, provincia, Direccion_CasaElectoral } = req.body;

        // Crear el objeto de coordinador con los datos recibidos
        const nuevoCoordinador = {
            nombre,
            apellido,
            cedula,
            numeroTelefono,
            sector,
            provincia,
            Direccion_CasaElectoral
        };

        // Hacer la solicitud POST a la API para agregar un coordinador
        const respuesta = await axios.post('https://localhost:7299/api/CoordinadoresGeneral/Create', nuevoCoordinador, {
            headers: {
                'Content-Type': 'application/json',
                'accept': '*/*'
            },
            httpsAgent: new https.Agent({ rejectUnauthorized: false }) 
        });

        // Redirigir al usuario a la página de inicio después de agregar el coordinador exitosamente
        res.redirect('/home'); 
    } catch (error) {
        // Manejar errores
        console.error('Error al añadir el coordinador:', error);
        res.status(500).json({ mensaje: 'Error al añadir el coordinador' });
    }
};

exports.getAgregarSubCoordinador = async (req, res, next) => {
    try {
        

    
        res.render("miembros/agregar-subcoordinador", {
            title: "Agregar SubCoordinador",
       
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

exports.getAgregarDirigente = async (req, res, next) => {
    try {
        

    
        res.render("miembros/agregar-dirigente", {
            title: "Agregar Dirigentes",
       
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




