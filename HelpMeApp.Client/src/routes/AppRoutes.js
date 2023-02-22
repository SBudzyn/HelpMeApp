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
import AdvertCreationPage from "../pages/AdvertUpdatingCreationPages/AdvertCreationPage";
import ChatPage from "../pages/ChatPage/ChatPage";
import UserProfilePages from "../pages/UserProfilePages/UserProfilePages";
import MyProfile from "../components/Profile/MyProfile";
import UserDataModificationForm from "../components/Profile/UserDataModificationForm";
import UsersAdvertsPage from "../pages/UserAdvertsPage/UserAdvertsPage";
import OtherUserProfile from "../components/Profile/OtherUserProfile";
import helpTypes from "../constants/helpTypes";
import AdvertUpdatingPage from "../pages/AdvertUpdatingCreationPages/AdvertUpdatingPage";
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
                element={<BoardPage helpTypeId={helpTypes.needHelp} />}
            />
            <Route
                path={routingUrl.pathToGiveHelpBoard + "/:page"}
                element={<BoardPage helpTypeId={helpTypes.canHelp} />}
            />
            <Route
                path={routingUrl.pathToAdvertById}
                element={<AdvertPage />}
            />
            <Route
                path={routingUrl.pathToChat}
                element={<RouteGuard element={ChatPage} />}
            />
            <Route
                path={routingUrl.pathToChatById}
                element={<RouteGuard element={ChatPage} />}
            />
            <Route
                path={routingUrl.pathToAdvertCreation}
                element={<RouteGuard element={AdvertCreationPage} />}
            />
            <Route
                path={routingUrl.pathToProfile}
                element={<UserProfilePages component={MyProfile}/>}
            />
            <Route
                path={routingUrl.pathToOtherUserProfile + "/:creatorId"}
                element={<UserProfilePages component={OtherUserProfile}/>}
            />
            <Route
                path={routingUrl.pathToProfileModification}
                element={<UserProfilePages component={UserDataModificationForm} />}
            />
            <Route
                path={routingUrl.pathToUsersAdverts + "/:page" + "/:creatorId"}
                element={<RouteGuard element={UsersAdvertsPage} />}
            />
            <Route
                path={routingUrl.pathToAdvertUpdateForm + "/:advertId"}
                element={<RouteGuard element={AdvertUpdatingPage}/>}
            />
            <Route path="*" element={<PageNotFound />} />
        </Routes>
    );
};

export default AppRoutes;
