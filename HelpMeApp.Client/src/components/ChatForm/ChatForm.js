import React, { useState } from "react";
import { Container, Row, Col, Form, Button, ListGroup } from "react-bootstrap";
import "./Chat.css";
import avatar from "../../media/defaultAvatarProfileIcon.jpg";
import advertPicture from "../../media/defaultAdvertPhoto.jpg";
import routingUrl from "../../constants/routingUrl";

const ChatForm = () => {
    const [selectedChatId, setSelectedChatId] = useState(null);
    const [message, setMessage] = useState("");
    const meAsSender = "Me"

    const [chats, setChats] = useState([
        {
            id: 1,
            name: "Alex Petrov",
            advertId: 1,
            advert: "I need clothes",
            avatar,
            advertPicture,
            messages: [
                {
                    text: "Hello, I can help you!",
                    sender: "Responder",
                    sentTime: "15:05"
                },
                {
                    text: "Wow thank you. I need warm clothes as soon as possible",
                    sender: "Me",
                    sentTime: "15:10"
                }
            ]
        },
        {
            id: 2,
            name: "Vasyl Ignatenko",
            advertId: 2,
            advert: "I want to move to another city",
            avatar,
            advertPicture,
            messages: [
                {
                    text: "Hello. Do you need evacuation?",
                    sender: "Me",
                    sentTime: "12:02"
                },
                {
                    text: "Yes. Of course i need evacuation. Isnt it obviosly???",
                    sender: "Responder",
                    sentTime: "12:05"
                },
                {
                    text: "Yep, sorry. It wasnt clearly enough.",
                    sender: "Me",
                    sentTime: "12:05"
                },
                {
                    text: "Where are you now?",
                    sender: "Me",
                    sentTime: "12:05"
                }
            ]
        },
        {
            id: 3,
            name: "Marusya Velenko",
            advertId: 3,
            advert: "FOOD PLEASE",
            avatar,
            advertPicture,
            messages: [
                {
                    text: "Hello! I can send you some food!",
                    sender: "Responder",
                    sentTime: "15:05"
                },
                {
                    text: "Yes. please. I will send you my information",
                    sender: "Me",
                    sentTime: "15:08"
                },
                {
                    text: "Okay, i am waiting.",
                    sender: "Me",
                    sentTime: "15:15"
                },
                { text: "Hello?", sender: "Me", sentTime: "17:20" },
                {
                    text: "I am still waiting for your response",
                    sender: "Me",
                    sentTime: "19:30"
                },
                {
                    text: "I guess you don't need my help anymore...",
                    sender: "Me",
                    sentTime: "22:45"
                }
            ]
        },
        {
            id: 4,
            name: "Khrystyna Som",
            advertId: 4,
            advert: "I need clothes",
            avatar,
            advertPicture,
            messages: [
                {
                    text: "Hellloooo. I have clothes for 8yo girl and 15yo boy. What fits you?",
                    sender: "Responder",
                    sentTime: "12:05"
                },
                { text: "Oh, thank you.", sender: "Me", sentTime: "12:05" },
                {
                    text: "Clothes for boy will fits me more.",
                    sender: "Me",
                    sentTime: "12:05"
                },
                {
                    text: "Here is my info for sending clothes:",
                    sender: "Me",
                    sentTime: "12:05"
                }
            ]
        },
        {
            id: 5,
            name: "Oleg Vynnyk",
            advertId: 5,
            advert: "My roof is broken",
            avatar,
            advertPicture,
            messages: [
                {
                    text: "Oh, i am so sorry. How can i help you?",
                    sender: "Responder",
                    sentTime: "12:05"
                },
                {
                    text: "I have some money.",
                    sender: "Responder",
                    sentTime: "12:05"
                },
                { text: "Oh, no, thanks", sender: "Me", sentTime: "12:05" },
                { text: "I dont need money", sender: "Me", sentTime: "12:05" },
                {
                    text: "I need help with materials for my roof",
                    sender: "Me",
                    sentTime: "12:05"
                },
                {
                    text: "It is unreal to find anything here even if you have money",
                    sender: "Me",
                    sentTime: "12:05"
                },
                {
                    text: "Oh i understand it now...",
                    sender: "Responder",
                    sentTime: "12:05"
                },
                {
                    text: "Than i cant help you right now, sorry",
                    sender: "Responder",
                    sentTime: "12:05"
                }
            ]
        },
        {
            id: 6,
            name: "Alisa Bekker",
            advertId: 6,
            advert: "I dont have money for food",
            avatar,
            advertPicture,
            messages: [
                {
                    text: "Hello! I want to help you with food. How many peoples are there in your family?",
                    sender: "Responder",
                    sentTime: "12:05"
                },
                {
                    text: "Oooh, i have a big family.",
                    sender: "Me",
                    sentTime: "12:05"
                },
                { text: "There is 7 of us", sender: "Me", sentTime: "12:05" },
                { text: "I have 4 children.", sender: "Me", sentTime: "12:05" },
                {
                    text: "And i also count me, my husband and my mom",
                    sender: "Me",
                    sentTime: "12:05"
                },
                {
                    text: "Okay. Thats not a problem",
                    sender: "Responder",
                    sentTime: "12:05"
                },
                {
                    text: "Send me information for post office so i will be able to send you something. I will send some toys for kids also. How old are they?",
                    sender: "Responder",
                    sentTime: "12:05"
                },
                {
                    text: "They are 3, 5, 8 and 15 yo",
                    sender: "Me",
                    sentTime: "12:05"
                },
                {
                    text: "Great! I have some toys and clothes for them!",
                    sender: "Responder",
                    sentTime: "12:05"
                }
            ]
        }
    ]);

    const handleChatSelect = (id) => {
        setSelectedChatId(id);
    };

    const handleSubmit = (event) => {
        event.preventDefault();
        if (message && selectedChatId) {
            setChats(
                chats.map((chat) => {
                    if (chat.id === selectedChatId) {
                        const today = new Date();
                        const time =
                            today.getHours() + ":" + today.getMinutes();
                        chat.messages = [
                            ...chat.messages,
                            {
                                text: message,
                                sender: meAsSender,
                                sentTime: time
                            }
                        ];
                    }
                    return chat;
                })
            );
            setMessage("");
        }
    };

    const redirectToAdvert = () => {
        location.href = `${routingUrl.pathToAdvert}/${message.advertId}`;
    };

    const selectedChat =
        selectedChatId && chats.find((chat) => chat.id === selectedChatId);

    return (
        <Container>
            <Row className="mt-2">
                <Col xs={4} className="chats-list-window">
                    <ListGroup>
                        {chats.map((chat) => (
                            <ListGroup.Item
                                key={chat.id}
                                action
                                active={selectedChatId === chat.id}
                                onClick={() => handleChatSelect(chat.id)}
                                className="overflow-hidden lh-sm"
                            >
                                <img
                                    src={advertPicture}
                                    alt="Advert picture"
                                    className="image-icon mt-0"
                                />
                                <strong>{chat.advert}</strong>
                                <p className="p-0 my-0">{chat.name}</p>
                                <p className="text-truncate lh-base mb-0">
                                    {chat.messages[chat.messages.length - 1]
                                        .sender === meAsSender
                                        ? "You: "
                                        : " "}
                                    {
                                        chat.messages[chat.messages.length - 1]
                                            .text
                                    }
                                </p>
                            </ListGroup.Item>
                        ))}
                    </ListGroup>
                </Col>
                <Col xs={8} className="">
                    <div className="d-flex align-items-center border rounded-top">
                        <img
                            src={avatar}
                            alt="Profile"
                            className={`flex-shrink-0 image-icon ${
                                !selectedChat ? "d-none" : ""
                            } `}
                        />
                        <h2 className="flex-grow-1 ms-1">
                            {selectedChat ? selectedChat.name : "Select chat"}
                        </h2>
                        <Button
                            onClick={redirectToAdvert}
                            type="submit"
                            className="w-25"
                        >
                            Advert
                        </Button>
                    </div>

                    <div className="chat-window bg-primary bg-opacity-25">
                        {selectedChat &&
                            selectedChat.messages.map((message, index) => (
                                <div
                                    key={index}
                                    className={`message h-auto pb-0 ${
                                        message.sender === meAsSender
                                            ? "right"
                                            : "left"
                                    }`}
                                >
                                    <blockquote>
                                        <p>{message.text}</p>
                                        <p className="blockquote-footer text-end">
                                            {message.sentTime}
                                        </p>
                                    </blockquote>
                                </div>
                            ))}
                    </div>
                    <Row>
                        <Col xs={10} className="pe-0">
                            <Form.Group controlId="formMessage">
                                <Form.Control
                                    type="text"
                                    placeholder="Enter message..."
                                    value={message}
                                    className="rounded-bottom-left"
                                    onChange={(event) =>
                                        setMessage(event.target.value)
                                    }
                                />
                            </Form.Group>
                        </Col>
                        <Col xs={2} className="ps-0">
                            <Form onSubmit={handleSubmit}>
                                <Button
                                    type="submit"
                                    className="w-100 rounded-0 rounded-end"
                                >
                                    Send
                                </Button>
                            </Form>
                        </Col>
                    </Row>
                </Col>
            </Row>
        </Container>
    );
};

export default ChatForm;
