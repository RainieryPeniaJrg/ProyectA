const axios = require('axios');
const https = require('https');

// Función para obtener el total de cantidad de votantes de los endpoints
const votosTotales = async () => {
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
            return respuesta.data.reduce((total, item) => total + item.cantidadVotantes, 0);
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

        return totalCantidadVotantes;

    } catch (error) {
        console.error('Error al obtener la información:', error);
        throw error;
    }
};

module.exports = { votosTotales };