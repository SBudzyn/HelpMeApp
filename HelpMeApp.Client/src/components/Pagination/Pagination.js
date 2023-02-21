import React from "react";
import PropTypes from "prop-types";
import "bootstrap/dist/css/bootstrap.css";

const Pagination = (props) => {
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
                        href={"/provide-help-board/" + (props.currentPage - 1)}
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
                        href={"/provide-help-board/" + (props.currentPage + 1)}
                    >
                        Next
                    </a>
                </li>
            </ul>
        </nav>
    );
};

Pagination.propTypes = {
    advertsByCurrentPage: PropTypes.number,
    currentPage: PropTypes.number
};

export default Pagination;
