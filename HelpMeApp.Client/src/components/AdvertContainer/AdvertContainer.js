import axios from "axios";
import { React, useEffect, useState } from "react";
import { serverUrl } from "../../constants/server";
import AdvertCard from "../AdvertCard/AdvertCard";

const AdvertShortInfoLayout = () => {
    const [adverts, setAdverts] = useState([]);

    const retrieveAdverts = async () => {
        await axios
            .get(`${serverUrl}/api/advert/page`)
            .then((response) => {
                // alert(JSON.stringify(response.data));
                return response.data;
            })
            .then((data) => {
                setAdverts(data);
            });
    };

    useEffect(() => {
        retrieveAdverts();
    }, []);
    // let data = [];

    // const response = await axios.get(`${serverUrl}/api/advert/page`).then(response => data = response.data);
    // const data = [
    //     {
    //         id: 1,
    //         title: "We need help. Please help us as soon as possible ",
    //         location: "Kharkiv",
    //         date: new Date("12.22.2022")
    //     },
    //     {
    //         id: 2,
    //         title: "HELP HELP HELLO HELLO We need help. Please help us as soon as possible. Help me help me my hero. I need your help",
    //         location: "Kyiv",
    //         date: new Date("12.12.2022")
    //     },
    //     {
    //         id: 3,
    //         title: "DO you wanna help me? Please help us as soon as possible",
    //         location: "Odesa",
    //         date: new Date("12.24.2022")
    //     },
    //     {
    //         id: 4,
    //         title: "I am helping you today. Please help us as soon as possible",
    //         location: "Dnipro",
    //         date: new Date("5.1.2023")
    //     },
    //     {
    //         id: 5,
    //         title: "We need help. Please help us as soon as possible",
    //         location: "Lviv",
    //         date: new Date("12.24.2022")
    //     },
    //     {
    //         id: 6,
    //         title: "We need help. Please help us as soon as possible",
    //         location: "Poltava",
    //         date: new Date("12.12.2022")
    //     }
    // ];
    return (
        <div className="container">
            <div className="row">
                {adverts.map((a) => (
                    <div
                        className="col-xs-12 col-sm-8 col-md-6 col-lg-4 col-xl-3 col-xxl-3 mb-3"
                        key={a.id}
                    >
                        <AdvertCard
                            key={a.id}
                            id={a.id}
                            title={a.header}
                            location={a.location}
                            date={new Date(a.creationDate)}
                        />
                    </div>
                ))}
            </div>
        </div>
    );
};

export default AdvertShortInfoLayout;
