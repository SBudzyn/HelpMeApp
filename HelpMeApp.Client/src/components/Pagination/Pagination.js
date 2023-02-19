import React from "react";
import PropTypes from "prop-types";

const Pagination = (props) => {
    const pageSize = 20;
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
                        href={"/provide-help-board/" + (props.currentPage - 1)}
                    >
                        Previous
                    </a>
                </li>

                <li
                    style={{ width: "50%", textAlign: "center" }}
                    className={`page-item ${
                        props.advertsByCurrentPage < pageSize ? "disabled" : ""
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
