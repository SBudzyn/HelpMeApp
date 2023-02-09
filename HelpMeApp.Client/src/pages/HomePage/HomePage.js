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
                        <button className="btn btn-outline-primary full-to-relative">
                            I need Help
                        </button>
                    </Link>
                    <Link to={routingUrl.pathToGiveHelpBoard + "/1"} className="col-md-3 mt-3">
                        <button className="btn btn-outline-warning full-to-relative">
                            I can give Help
                        </button>
                    </Link>
                </div>
            </section>
            <section>
                <div className="row mt-5 justify-content-center">
                    <h6 className="col-md-12 text-center">About Us</h6>
                    <p className="col-md-6">
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit,
                        sed do eiusmod tempor incididunt ut labore et dolore
                        magna aliqua. Ut enim ad minim veniam, quis nostrud
                        exercitation ullamco laboris nisi ut aliquip ex ea
                        commodo consequat. Duis aute irure dolor in
                        reprehenderit in voluptate velit esse cillum dolore eu
                        fugiat nulla pariatur. Excepteur sint occaecat cupidatat
                        non proident, sunt in culpa qui officia deserunt mollit
                        anim id est laborum.
                    </p>
                </div>
            </section>
        </div>
    );
};

export default HomePage;
