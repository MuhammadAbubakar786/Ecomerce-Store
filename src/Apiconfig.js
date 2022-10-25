import axios from "axios";
const LocalURL = "https://localhost:44348/api/";
const LocalImageURL = "https://localhost:44348/";
const LiveImageURL = "https://tradeposterapi.dselectricstore.com/";
const LiveUrl = "https://tradeposterapi.dselectricstore.com/api/";
const instance = axios.create({ baseURL: LiveUrl });

export default instance;
export const ImgUrl = LiveImageURL;
