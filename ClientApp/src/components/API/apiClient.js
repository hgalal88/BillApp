import axios from 'axios';

const apiClient = axios.create({
    baseURL: 'https://localhost:44383/',
    timeout: 100000
});