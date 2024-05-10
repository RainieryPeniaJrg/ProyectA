const axios = require('axios');
const { error } = require('console');
const https = require('https');


exports.getRegistro = async (req, res) => {
  try {
      const rolesResponse = await req.axiosInstance.get('Account/identity/role-list');
      const roles = rolesResponse.data;

      res.render('sesion/registro', {
          title: 'Registro de Usuario',
          roles: roles
      });
  } catch (error) {
      console.error('Error al mostrar el formulario de registro:', error);
      res.status(500).json({ mensaje: 'Error al mostrar el formulario de registro' });
  }
};exports.registrarUsuario = async (req, res) => {
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
      const respuesta = await req.axiosInstance.post(
          "Account/identity/create",
          nuevoUsuario
      );

      // Handle successful registration
      if (respuesta.status === 200) {
          res.redirect('/home');
      } else {
          // Handle registration errors
          const errorMensaje = respuesta.data.message || "Error al registrar el usuario";
          res.status(respuesta.status).json({ mensaje: errorMensaje });
      }
  } catch (error) {
      console.error("Error al registrar el usuario:", error);
      res.status(500).json({ mensaje: "Error al registrar el usuario" });
  }
};


  exports.loginUsuario = async (req, res) => {
    try {
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
        const { email, password } = req.body;
        const credenciales = { email, password };

        const respuesta = await req.axiosInstance.post(
            "Account/identity/login",
            credenciales
        );

        if (respuesta.status === 200) {
            req.session.token = respuesta.data.token;
            req.session.userId = respuesta.data.userId;

           

            // Verificar si el token se guardó correctamente en req.session.token


            res.send('Inicio de sesión exitoso');
            res.redirect('/votantes'); 
        } else {
            const errorMensaje = respuesta.data.message || "Error al iniciar sesión";
            res.status(respuesta.status).json({ mensaje: errorMensaje });
        }
    } catch (error) {
        console.error("Error al iniciar sesión:", error);
        res.status(500).json({ mensaje: "Error al iniciar sesión" });
    }
};