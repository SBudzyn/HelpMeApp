import React from "react";
import { Route, Routes } from "react-router-dom";
import RouteGuard from "../components/RouteGuard/RouteGuard";
import BoardPage from "../pages/BoardPage/BoardPage";
import AdvertPage from "../pages/AdvertPage/AdvertPage";
import AuthorizationPage from "../pages/AuthorizationPage/AuthorizationPage";
import routingUrl from "../constants/routingUrl";
import LoginForm from "../components/AuthorizationForms/LoginForm";
import RegistrationForm from "../components/AuthorizationForms/RegistrationForm";
import HomePage from "../pages/HomePage/HomePage";
import PageNotFound from "../pages/PageNotFound/PageNotFound";
import AdvertCreationPage from "../pages/AdvertCreationPage/AdvertCreationPage";
import UserProfile from "../components/Profile/UserProfile";
import ModifyProfileDataForm from "../components/Profile/UserDataModificationForm";
import ProfilePage from "../pages/ProfilePage/ProfilePage";
const AppRoutes = () => {
    return (
        <Routes>
            <Route
                path={routingUrl.pathToHomePage}
                exact
                element={<HomePage />}
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
                path={routingUrl.pathToGetHelpBoard + "/:page"}
                element={<BoardPage helpTypeId={1} />}
            />
            <Route
                path={routingUrl.pathToGiveHelpBoard + "/:page"}
                element={<BoardPage helpTypeId={2} />}
            />
            <Route
                path={routingUrl.pathToAdvertById}
                element={<AdvertPage />}
            />
            <Route
                path={routingUrl.pathToChat}
                element={<RouteGuard element={<h1>Chat</h1>} />}
            />
            <Route
                path={routingUrl.pathToAdvertCreation}
                element={<AdvertCreationPage />}
            />
            <Route
                path={routingUrl.pathToProfile}
                element={<ProfilePage component={UserProfile} />}
            />
            <Route
                path={routingUrl.pathToModifyProfileData}
                element={<ProfilePage component={ModifyProfileDataForm} />}
            />
            <Route path="*" element={<PageNotFound />} />
        </Routes>
    );
};

export default AppRoutes;
