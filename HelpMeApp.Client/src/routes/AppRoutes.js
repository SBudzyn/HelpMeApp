import React from "react";
import { Route, Routes } from "react-router-dom";
import RouteGuard from "../components/RouteGuard/RouteGuard";
import BoardPage from "../pages/BoardPage/BoardPage";
import AdvertPage from "../pages/AdvertPage/AdvertPage";
import AuthorizationPage from "../pages/AuthorizationPage/AuthorizationPage";
import routingUrl from "../constants/routingUrl";
import LoginForm from "../components/AuthorizationForms/LoginForm";
import RegistrationForm from "../components/AuthorizationForms/RegistrationForm";

const AppRoutes = () => {
    return (
        <Routes>
            <Route
                path={routingUrl.pathToHomePage}
                exact
                element={<h1>Home page</h1>}
            />
            <Route
                path={routingUrl.pathToLoginPage}
                element={<AuthorizationPage component={ LoginForm } />}
            />
            <Route
                path={routingUrl.pathToSignUpPage}
                element={<AuthorizationPage component={ RegistrationForm } />}
            />
            <Route
                path={routingUrl.pathToGetHelpBoard}
                element={<BoardPage />}
            />
            <Route
                path={routingUrl.pathToGiveHelpBoard}
                element={<BoardPage />}
            />
            <Route path={routingUrl.pathToAdvertById} element={<AdvertPage />} />
            <Route path={routingUrl.pathToChat} element={<h1>Chat</h1>} />
            <Route path={routingUrl.pathToProfile} element={<h1>Profile</h1>} />
            <Route path={routingUrl.pathToPostAdvert} element={<RouteGuard element={BoardPage} />} />
        </Routes>
    );
};

export default AppRoutes;
