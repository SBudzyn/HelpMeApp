import React from "react";
import { Route, Routes } from "react-router-dom";
import routingUrl from "../constants/routingUrl";
import LoginForm from "../components/AuthorizationForms/LoginForm";
import RegistrationForm from "../components/AuthorizationForms/RegistrationForm";
import BoardPage from "../pages/BoardPage/BoardPage";

const AppRoutes = () => {
    return (
        <Routes>
            <Route
                path={routingUrl.pathToHomePage}
                exact
                element={<h1>Home page</h1>}
            />
            <Route path={routingUrl.pathToLoginPage} element={<LoginForm />} />
            <Route
                path={routingUrl.pathToSignUpPage}
                element={<RegistrationForm />}
            />
            <Route
                path={routingUrl.pathToGetHelpBoard}
                element={<BoardPage />}
            />
            <Route
                path={routingUrl.pathToGiveHelpBoard}
                element={<BoardPage />}
            />
            <Route
                path={routingUrl.pathToChat}
                element={<h1>Chat</h1>}
            />
            <Route
                path={routingUrl.pathToProfile}
                element={<h1>Profile</h1>}
            />
        </Routes>
    );
};

export default AppRoutes;
