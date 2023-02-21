import React from "react";
import PropTypes from "prop-types";
import { useParams } from "react-router-dom";

const UsersAdvertsPagination = (props) => {
    const params = useParams();
    const pageSize = 20;
    return (
        <nav>
            <ul className="pagination">
                <li
                    className={`w-50 text-center page-item ${
                        props.currentPage <= 1 && "disabled"
                    }`}
                >
                    <a
                        className="page-link"
                        href={"/user-adverts/" + (props.currentPage - 1) + `/${params.creatorId}`}
                    >
                        Previous
                    </a>
                </li>

                <li
                    className={`w-50 text-center page-item ${
                        props.advertsByCurrentPage < pageSize && "disabled"
                    }`}
                >
                    <a
                        className="page-link"
                        href={"/user-adverts/" + (props.currentPage + 1) + `/${params.creatorId}`}
                    >
                        Next
                    </a>
                </li>
            </ul>
        </nav>
    );
};

UsersAdvertsPagination.propTypes = {
    advertsByCurrentPage: PropTypes.number,
    currentPage: PropTypes.number
};

export default UsersAdvertsPagination;
