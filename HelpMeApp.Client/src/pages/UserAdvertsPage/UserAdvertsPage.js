import { React, useState, useEffect } from "react";
import PropTypes from "prop-types";
import UsersAdvertsContainer from "../../components/UsersAdvertsContainer/UsersAdvertsContainer";
import { useParams } from "react-router-dom";
import { baseRequestWithToken } from "../../services/axiosServices";
import UsersAdvertsPagination from "../../components/Pagination/UsersAdvertsPagination";

const UsersAdvertsPage = () => {
    const params = useParams();
    const [userAdverts, setUsersAdverts] = useState([]);

    const retrieveUsersAdverts = async () => {
        await baseRequestWithToken
            .get(`/profile/get-user-needs-help-adverts-by-page/${params.page}/${params.creatorId}`)
            .then((response) => {
                return response.data;
            })
            .then((data) => {
                setUsersAdverts(data);
            });
    };

    useEffect(() => {
        retrieveUsersAdverts();
    }, []);

    return (
        <div>
            <div className="centered-form mt-4">
                <UsersAdvertsContainer className="form" userAdverts={userAdverts} />
            </div>
            <hr />
            <div className="container mt-3 mb-3">
                <div className="row justify-content-center">
                    <div className="col-xs-12 col-md-6 col-lg-3 col-xl-2">
                        <UsersAdvertsPagination
                            advertsByCurrentPage={userAdverts.length}
                            currentPage={Number(params.page)}
                        />
                    </div>
                </div>
            </div>
        </div>
    );
};

UsersAdvertsPage.propTypes = {
    component: PropTypes.element
};

export default UsersAdvertsPage;
