const authorizeRoles = async (req, res, next) => {
    try {
        // Verificar si el usuario tiene un token de sesión
        const token = req.session.token;
        if (!token) {
            return res.status(401).json({ mensaje: "Acceso no autorizado. Token no encontrado." });
        }
 
        // Obtener el userId del token de sesión
        const userId = req.session.userId;
        if (!userId) {
            return res.status(401).json({ mensaje: "Acceso no autorizado. UserId no encontrado." });
        }
 
        // Hacer una solicitud para obtener los roles del usuario
        const response = await req.axiosInstance.get("Account/identity/users-with-role");
        const usuariosConRoles = response.data;
 
        // Buscar el usuario en la lista de usuarios con roles
        const usuarioConRol = usuariosConRoles.find(usuario => usuario.userId === userId);
        if (!usuarioConRol) {
            return res.status(403).json({ mensaje: "Acceso prohibido. Usuario no encontrado en la lista de roles." });
        }
 
        // Obtener el roleName del usuario
        const roleName = usuarioConRol.roleName;
 
        // Agregar el roleName a req para que esté disponible en las rutas protegidas
        req.roleName = roleName;
        console.log(roleName);
        // Continuar con la solicitud si el usuario tiene los permisos necesarios
        next();
    } catch (error) {
        console.error("Error al autorizar roles:", error);
        res.status(500).json({ mensaje: "Error al autorizar roles" });
    }
 };

 module.exports = authorizeRoles;