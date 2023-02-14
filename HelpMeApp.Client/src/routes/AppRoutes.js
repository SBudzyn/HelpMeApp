import React from "react";
import { Route, Routes } from "react-router-dom";
import BoardPage from "../pages/BoardPage/BoardPage";
import AuthorizationPage from "../pages/AuthorizationPage/AuthorizationPage";
import routingUrl from "../constants/routingUrl";
import LoginForm from "../components/AuthorizationForms/LoginForm";
import RegistrationForm from "../components/AuthorizationForms/RegistrationForm";
import AdvertCreationPage from "../pages/AdvertCreationPage/AdvertCreationPage";
import ChatPage from "../pages/ChatPage/ChatPage";

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
                element={<AuthorizationPage component={LoginForm} />}
            />
            <Route
                path={routingUrl.pathToSignUpPage}
                element={<AuthorizationPage component={RegistrationForm} />}
            />
            <Route
                path={routingUrl.pathToGetHelpBoard}
                element={<BoardPage />}
            />
            <Route
                path={routingUrl.pathToGiveHelpBoard}
                element={<BoardPage />}
            />
            <Route path={routingUrl.pathToChat} element={<ChatPage />} />
            <Route path={routingUrl.pathToProfile} element={<h1>Profile</h1>} />
            <Route
                path={routingUrl.pathToAdvertCreation}
                element={<AdvertCreationPage />}
            />
        </Routes>
    );
};

export default AppRoutes;
