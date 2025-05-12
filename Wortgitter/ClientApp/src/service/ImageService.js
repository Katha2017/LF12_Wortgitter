import axios from './axios.js'

async function requestWordGrid(file) {
    const formData = new FormData();
    formData.append('file', file);
    await axios.post('/Image', formData).then(
        (response) => { return response; }
    );
} 

export default {
    requestWordGrid
}