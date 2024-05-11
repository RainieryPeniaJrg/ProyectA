// axiosConfig.js
const axios = require('axios');
const https = require('https');

const axiosInstance = axios.create({
    baseURL: 'https://localhost:7299/api/',
    headers: {
        'Content-Type': 'application/json',
        'accept': '*/*'
    },
    httpsAgent: new https.Agent({ rejectUnauthorized: false })
});

module.exports = axiosInstance;