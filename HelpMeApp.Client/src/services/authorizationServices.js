import routingUrl from "../constants/routingUrl";

export const checkToken = () => {
    return !!localStorage.getItem("token");
};

export const logout = () => {
    localStorage.removeItem("token");
    localStorage.removeItem("userId");
    location.href = routingUrl.pathToHomePage;
};
