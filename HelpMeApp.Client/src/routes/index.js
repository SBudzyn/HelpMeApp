import React from 'react';
import { Route, Routes } from 'react-router-dom';

import { routes } from '../configs/index';

import AuthForm from '../components/registration form/index';

const {
    pathToHomePage,
    pathToLoginPage,
    pathToSignUpPage
} = routes;



const AppRoutes = () => {
    return (
            <Routes>
                <Route path={pathToHomePage} exact element={<h1>Home page</h1>} />
                <Route path={pathToLoginPage} element={<AuthForm formType='login'/>}/>
                <Route path={pathToSignUpPage} element={<AuthForm formType='register'/>} />
            </Routes> 
    );
}

export default AppRoutes;