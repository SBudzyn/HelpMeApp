import React from 'react';
import { Route, Routes } from 'react-router-dom';

import { routes } from '../Constants/index';

import LoginForm from '../Components/AuthorizationForms/LoginForm';
import RegistrationForm from '../Components/AuthorizationForms/RegistrationForm';

const {
    pathToHomePage,
    pathToLoginPage,
    pathToSignUpPage
} = routes;



const AppRoutes = () => {
    return (
            <Routes>
                <Route path={pathToHomePage} exact element={<h1>Home page</h1>} />
                <Route path={pathToLoginPage} element={<LoginForm />}/>
                <Route path={pathToSignUpPage} element={<RegistrationForm />} />
            </Routes> 
    );
}

export default AppRoutes;