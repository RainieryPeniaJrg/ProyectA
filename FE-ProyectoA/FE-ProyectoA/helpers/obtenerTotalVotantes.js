const axios = require('axios');
const https = require('https');

// Función para obtener el total de cantidad de votantes de los endpoints
const obtenerTotalVotantes = async () => {
    try {
        const agent = new https.Agent({ rejectUnauthorized: false });

        // Define los URLs de los endpoints
        const urls = [
            'https://localhost:7299/api/SubCoordinador/GetAllVotantes',
            'https://localhost:7299/api/Dirigentes/GetAllVotantes',
            'https://localhost:7299/api/CoordinadoresGeneral/GetAllVotantes',
            'https://localhost:7299/api/Director/GetAllVotantes'
        ];

        // Array para almacenar las promesas de las solicitudes a los endpoints
        const solicitudes = [];

        // Realiza las solicitudes a cada endpoint y almacena las promesas en el array
        for (const url of urls) {
            solicitudes.push(axios.get(url, {
                headers: {
                    'Content-Type': 'application/json',
                    'accept': '*/*'
                },
                httpsAgent: agent
            }));
        }

        // Espera a que todas las promesas se resuelvan
        const respuestas = await Promise.all(solicitudes);

        // Suma la cantidad de votantes de todas las respuestas
        let totalVotantes = 0;
        for (const respuesta of respuestas) {
            totalVotantes += respuesta.data.length; // Suponiendo que cada respuesta contiene un arreglo de votantes y quieres contar la longitud de cada arreglo
        }

        return totalVotantes;

    } catch (error) {
        console.error('Error al obtener la información:', error);
        throw error;
    }
};

module.exports = { obtenerTotalVotantes };