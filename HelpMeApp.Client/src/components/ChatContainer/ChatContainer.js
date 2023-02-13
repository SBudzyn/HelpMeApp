import { React } from "react";
import ChatCard from "../ChatCard/ChatCard";

const ChatShortInfoLayout = () => {
    const data = [
        {
            id: 1,
            title: "We need help ",
            location: "Kharkiv",
            date: new Date("12.22.2022")
        },
        {
            id: 2,
            title: "HELP HELP help",
            location: "Kyiv",
            date: new Date("12.12.2022")
        },
        {
            id: 3,
            title: "DO as soon as possible",
            location: "Odesa",
            date: new Date("12.24.2022")
        },
        {
            id: 4,
            title: "I am helping you today",
            location: "Dnipro",
            date: new Date("5.1.2023")
        },
        {
            id: 5,
            title: "We need help.",
            location: "Lviv",
            date: new Date("12.24.2022")
        },
        {
            id: 6,
            title: "We need help.",
            location: "Poltava",
            date: new Date("12.12.2022")
        }
    ];
    return (
        <div className="container">
            <div className="row">
                {data.map((a) => (
                    <div
                        className="col-xs-12 col-sm-8 col-md-6 col-lg-4 col-xl-3 col-xxl-3 mb-3"
                        key={a.id}
                    >
                        <ChatCard
                            key={a.id}
                            id={a.id}
                            title={a.title}
                            location={a.location}
                            date={a.date}
                        />
                    </div>
                ))}
            </div>
        </div>
    );
};

export default ChatShortInfoLayout;
