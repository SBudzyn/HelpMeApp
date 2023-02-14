import React from "react";
import { Link } from "react-router-dom";
import "./HomePage.css";
import "bootstrap/dist/css/bootstrap.css";
import routingUrl from "../../constants/routingUrl";

const HomePage = () => {
    return (
        <div className="container">
            <section>
                <div className="row justify-content-space-around mt-5">
                    <Link to={routingUrl.pathToGetHelpBoard + "/1"} className="col-md-3 mt-3">
                        <button className="btn btn-outline-primary w-100 h-100">
                            I need Help
                        </button>
                    </Link>
                    <Link to={routingUrl.pathToGiveHelpBoard + "/1"} className="col-md-3 mt-3">
                        <button className="btn btn-outline-warning w-100 h-100">
                            I can give Help
                        </button>
                    </Link>
                </div>
            </section>
            <section>
                <div className="row mt-5 justify-content-center">
                    <h6 className="col-md-12 text-center">About the project</h6>
                    <p className="col-md-6">
                        HelpMeApp is an application that is aimed to connect,
                        people who need help and those who want to help someone.
                        So instead of looking for help among friends or using
                        social medias, you can use board on the website, filter
                        adverts and sort them. Also, the application is to provide
                        a way of communication between users.
                    </p>
                </div>
            </section>
        </div>
    );
};

export default HomePage;
