import React from "react";
import "bootstrap/dist/css/bootstrap.css";
import { Link } from "react-router-dom";
import routingUrl from "../../constants/routingUrl";

const PageNotFound = () => {
    return (
        <div className="container">
            <div className="row justify-content-space-around">
                <h1 className="col-md-6">This page does not exist</h1>
            </div>
            <div className="row justify-content-space-around">
                <h4 className="col-md-3">you can go to:</h4>
            </div>
            <div className="row justify-content-space-around">
                <Link to={routingUrl.pathToHomePage} className="col-md-3">
                    <button
                        className="btn btn-primary mt-2"
                        style={{ width: "100%" }}
                    >
                        Home Page
                    </button>
                </Link>
                <Link
                    to={routingUrl.pathToGetHelpBoard + "/1"}
                    className="col-md-3"
                >
                    <button
                        className="btn btn-warning mt-2"
                        style={{ width: "100%" }}
                    >
                        Get Help board page
                    </button>
                </Link>
                <Link
                    to={routingUrl.pathToGiveHelpBoard + "/1"}
                    className="col-md-3"
                >
                    <button
                        className="btn btn-primary mt-2"
                        style={{ width: "100%" }}
                    >
                        Provide Help board page
                    </button>
                </Link>
            </div>
        </div>
    );
};

export default PageNotFound;
