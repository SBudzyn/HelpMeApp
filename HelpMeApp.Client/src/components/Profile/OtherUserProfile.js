import React, { useState, useEffect } from "react";
import "bootstrap/dist/css/bootstrap.css";
import { Link, useParams } from "react-router-dom";
import routingUrl from "../../constants/routingUrl";
import "./UserProfile.css";
import { baseRequestWithToken } from "../../services/axiosServices";
import defaultAdvertImage from "../../media/defaultAdvertPhoto.jpg";

const OtherUserProfile = () => {
    const params = useParams();
    const [userData, setGeneralData] = useState({});

    const retrieveUserData = async () => {
        await baseRequestWithToken
            .get(`/profile/get-user-by-id/${params.creatorId}`)
            .then((response) => {
                return response.data;
            })
            .then((data) => {
                setGeneralData(data);
            });
    };

    useEffect(() => {
        retrieveUserData();
    }, []);

    return (
        <div className="container">
            <div className="row mt-3 col-sm-12 ">
                <div className="col-lg-4">
                    <img
                        src={userData.photo === "" ? (defaultAdvertImage) : (userData.photo)}
                        style={{ width: "18rem" }}
                        className="border border-dark"
                    ></img>
                </div>

                <div className="col-lg-8">
                    <div className="row">
                        <div className="col-lg-9 col-md-3 text-profile">
                            <h1 className="name-surname-profile">{userData.name ?? "No data"} {userData.surname ?? "No data"}</h1>
                        </div>
                    </div>
                    <div className="row">
                        <h4 className="text-profile">Telephone number: <span className="user-data-profile">{userData.phoneNumber ?? "No data"}</span></h4>
                    </div>
                    <div className="row">
                        <h4 className="text-profile">E-mail: <span className="user-data-profile">{userData.email ?? "No data"}</span></h4>
                    </div>
                    <div className="row">
                        <h4 className="text-profile">
                            Helped: <span className="user-data-profile">{userData.advertsUserCanHelp ?? "0"} times </span>
                        </h4>
                    </div>
                    <div className="row mt-2">
                        <div className="col-lg-12">
                            <Link to={routingUrl.pathToUsersAdverts + "/1" + `/${params.creatorId}`}>
                                <button className="btn btn-warning btn-block btn-lg align-items-center justify-content-center w-100 link-buttons ">
                                    View users adverts
                                </button>
                            </Link>
                        </div>
                    </div>
                    <div className="row mt-4 bg-light col-sm-12 mt-3">
                        <div className="col-xs-12">
                            <p className="mt-4 info-profile">
                                {userData.info ?? "No data provided"}
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default OtherUserProfile;
