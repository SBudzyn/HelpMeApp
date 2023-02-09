import React from "react";
import PropTypes from "prop-types";

const Pagination = (props) => {
    const pageSize = 20;
    const numberOfPages = Math.ceil(props.adverts / pageSize);
    return (
        <nav aria-label="...">
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
                        props.currentPage >= numberOfPages ? "disabled" : ""
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
    adverts: PropTypes.number,
    currentPage: PropTypes.number
};

export default Pagination;
