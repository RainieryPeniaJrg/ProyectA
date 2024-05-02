const axios = require('axios');
const { error } = require('console');
const https = require('https');


exports.getRegistro = async (req, res) => {
    try {



          const roles = await axios.get('https://localhost:7299/api/Account/identity/role-list',  {
            headers: {
                'Content-Type': 'application/json',
                'accept': 'text/plain'
            },
            httpsAgent: new https.Agent({ rejectUnauthorized: false }) 

        });

        const rol = roles.data;

        res.render('sesion/registro', {
            title: 'Registro de Usuario',
            roles: rol
        });
    } catch (error) {
        console.error('Error al mostrar el formulario de registro:', error);
        res.status(500).json({ mensaje: 'Error al mostrar el formulario de registro' });
    }
};

exports.registrarUsuario = async (req, res) => {
    try {
      // Extract user data from the request body
      const {
        email,
        password,
        nombre,
        apellido,
        cedula,
        numeroTelefono,
        provincia,
        sector,
        casaElectoral,
        cantidadVotantes,
        activo,
        subCoordinadorId,
        coordinadorGeneralId,
        dirigenteId,
        confirmPassword,
        role
      } = req.body;
  
      // Create a user object with the received data
      const nuevoUsuario = {
        email,
        password,
        nombre,
        apellido,
        cedula,
        numeroTelefono,
        provincia,
        sector,
        casaElectoral,
        cantidadVotantes,
        subCoordinadorId,
        coordinadorGeneralId,
        dirigenteId,
        confirmPassword,
        role
      };
  
      // Make a registration request to the corresponding endpoint
      const respuesta = await axios.post(
        "https://localhost:7299/api/Account/identity/create",
        nuevoUsuario,
        {
          headers: {
            'Content-Type': 'application/json',
            'accept': 'text/plain'
          },
          httpsAgent: new https.Agent({ rejectUnauthorized: false })
        }
      );
  
      // Handle successful registration
      if (respuesta.status === 200) {
        res.redirect('/home');
        //res.status(200).json(respuesta.data);
      } else {
        // Handle registration errors
        const errorMensaje = respuesta.data.message || "Error al registrar el usuario";
        res.status(respuesta.status).json({ mensaje: errorMensaje });
      }
    } catch (error) {
      console.log(error.response.data.errors)
      res.status(500).json({ mensaje: "Error al registrar el usuario" });
    }
  };



  exports.loginUsuario = async (req, res) => {
    try {
        // Render the login view
        res.render('sesion/login', {
            title: 'Iniciar Sesión'
        });
    } catch (error) {
        console.error('Error al mostrar el formulario de inicio de sesión:', error);
        res.status(500).json({ mensaje: 'Error al mostrar el formulario de inicio de sesión' });
    }
};

exports.iniciarSesion = async (req, res) => {
  try {
      // Extraer datos de usuario del cuerpo de la solicitud
      const { email, password } = req.body;

      // Crear un objeto de usuario con los datos recibidos
      const credenciales = {
          email,
          password
      };

      // Realizar una solicitud de inicio de sesión al punto final correspondiente
      const respuesta = await axios.post(
          "https://localhost:7299/api/Account/identity/login",
          credenciales,
          {
              headers: {
                  'Content-Type': 'application/json',
                  'accept': 'text/plain'
              },
              httpsAgent: new https.Agent({ rejectUnauthorized: false })
          }
      );

      // Manejar el inicio de sesión exitoso
      if (respuesta.status === 200) {
         res.cookie('token', respuesta.data.token, { httpOnly: true }); // Envía el token como cookie
         res.status(200).json({ mensaje: 'Inicio de sesión exitoso' });
      } else {
          // Manejar errores de inicio de sesión
          const errorMensaje = respuesta.data.message || "Error al iniciar sesión";
          res.status(respuesta.status).json({ mensaje: errorMensaje });
      }
  } catch (error) {
      console.error("Error al iniciar sesión:", error);
      res.status(500).json({ mensaje: "Error al iniciar sesión" });
  }
};
  