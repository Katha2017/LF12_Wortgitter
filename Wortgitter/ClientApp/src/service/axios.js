import axios from 'axios';

const axiosInstance = axios.create({
  baseURL: 'https://localhost:44360/'
});

export default axiosInstance;