import React from "react";
import { Route, Routes } from "react-router-dom";
import routingUrl from "../constants/routingUrl";
import LoginForm from "../components/AuthorizationForms/LoginForm";
import RegistrationForm from "../components/AuthorizationForms/RegistrationForm";
import AdvertShortInfoLayout from "../components/AdvertShortInfo/AdvertShortInfoLayout/AdvertShortInfoLayout";

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
            <Route path="/advert" element={<AdvertShortInfoLayout />} />
        </Routes>
    );
};

export default AppRoutes;
