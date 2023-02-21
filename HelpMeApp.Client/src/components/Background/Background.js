import React from "react";
import "./Background.css";

const Background = () => {
    const randomBg = [];

    for (let i = 0; i < 40; i++) {
        randomBg.push({
            x: Math.random() * (2000 - 0) + 0,
            y: Math.random() * (2000 - 0) + 0
        });
    }

    return (
        <svg
            id="visual"

            width="100%"
            height="90vh"
            xmlns="http://www.w3.org/2000/svg"
            version="1.1"
            className="bg"
        >
            <rect width="100%" height="90vh" fill="#39ade3"></rect>
            <g>
                {randomBg.map((v) => {
                    return (
                        <g transform={`translate(${v.x} ${v.y})`} key={v.x}>
                            <path
                                d="M0 -61L52.8 -30.5L52.8 30.5L0 61L-52.8 30.5L-52.8 -30.5Z"
                                fill="#005d9f"
                            ></path>
                        </g>
                    );
                })}
            </g>
        </svg>
    );
};

export default Background;
