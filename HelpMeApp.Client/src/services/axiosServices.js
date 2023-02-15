import { serverUrl } from "../constants/server";
import axios from "axios";

const baseRequest = axios.create({
    baseURL: `${serverUrl}/api`,
    timeout: 3000,
    headers: {
        Accept: "application/json",
        "Content-Type": "application/json"
    }
});

export default baseRequest;
