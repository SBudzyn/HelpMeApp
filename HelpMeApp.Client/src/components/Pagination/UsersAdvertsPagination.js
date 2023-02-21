import React from "react";
import PropTypes from "prop-types";

const UsersAdvertsPagination = (props) => {
    const pageSize = 20;
    const numberOfPages = Math.ceil(props.adverts / pageSize);
    return (
        <nav>
            <ul className="pagination">
                <li
                    style={{ width: "50%", textAlign: "center" }}
                    className={`page-item ${
                        props.currentPage <= 1 ? "disabled" : ""
                    }`}
                >
                    <a
                        className="page-link"
                        href={"/my-adverts/" + (props.currentPage - 1)}
                    >
                        Previous
                    </a>
                </li>

                <li
                    style={{ width: "50%", textAlign: "center" }}
                    className={`page-item ${
                        props.currentPage >= numberOfPages ? "disabled" : ""
                    }`}
                >
                    <a
                        className="page-link"
                        href={"/my-adverts/" + (props.currentPage + 1)}
                    >
                        Next
                    </a>
                </li>
            </ul>
        </nav>
    );
};

UsersAdvertsPagination.propTypes = {
    adverts: PropTypes.number,
    currentPage: PropTypes.number
};

export default UsersAdvertsPagination;
