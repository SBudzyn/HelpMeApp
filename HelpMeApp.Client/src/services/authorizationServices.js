import routingUrl from "../constants/routingUrl";

export const checkToken = () => {
    return !!localStorage.getItem("token");
};

export const logout = () => {
    localStorage.removeItem("token");
    location.href = routingUrl.pathToHomePage;
};
