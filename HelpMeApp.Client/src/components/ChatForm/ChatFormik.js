import React, { useState } from "react";
import { Container, Row, Col, Form, Button, ListGroup } from "react-bootstrap";
import "./Chat.css";

const Chat = () => {
    const [selectedChatId, setSelectedChatId] = useState(null);
    const [message, setMessage] = useState("");
    const [chats, setChats] = useState([
        {
            id: 1,
            name: "User 1",
            messages: [
                { text: "Hello, how are you?", sender: "User 1" },
                { text: "I'm doing well, thanks!", sender: "You" }
            ]
        },
        {
            id: 2,
            name: "User 2",
            messages: [
                { text: "Hi, what's up?", sender: "User 2" },
                { text: "Nothing much, just hanging out.", sender: "You" }
            ]
        }
    ]);

    const handleChatSelect = (id) => {
        setSelectedChatId(id);
    };

    const handleSubmit = (event) => {
        event.preventDefault();
        if (!selectedChatId) return;
        setChats(
            chats.map((chat) => {
                if (chat.id === selectedChatId) {
                    chat.messages = [
                        ...chat.messages,
                        { text: message, sender: "You" }
                    ];
                }
                return chat;
            })
        );
        setMessage("");
    };

    const selectedChat =
        selectedChatId && chats.find((chat) => chat.id === selectedChatId);

    return (
        <Container>
            <Row>
                <Col xs={4}>
                    <ListGroup>
                        {chats.map((chat) => (
                            <ListGroup.Item
                                key={chat.id}
                                action
                                active={selectedChatId === chat.id}
                                onClick={() => handleChatSelect(chat.id)}
                            >
                                {chat.name}
                            </ListGroup.Item>
                        ))}
                    </ListGroup>
                </Col>
                <Col xs={8}>
                    <h2>
                        Chat with {selectedChat ? selectedChat.name : "..."}
                    </h2>
                    <div className="chat-window">
                        {selectedChat &&
                            selectedChat.messages.map((message, index) => (
                                <div
                                    key={index}
                                    className={`message ${
                                        message.sender === "You"
                                            ? "right"
                                            : "left"
                                    }`}
                                >
                                    <img
                                        src={message.profile_pic}
                                        alt="Profile"
                                        className="profile-icon"
                                    />
                                    <p>
                                        {message.sender}: {message.text}
                                    </p>
                                </div>
                            ))}
                    </div>
                    <Form onSubmit={handleSubmit}>
                        <Form.Group controlId="formMessage">
                            <Form.Control
                                type="text"
                                placeholder="Enter message..."
                                value={message}
                                onChange={(event) =>
                                    setMessage(event.target.value)
                                }
                            />
                        </Form.Group>
                        <Button type="submit">Send</Button>
                    </Form>
                </Col>
            </Row>
        </Container>
    );
};

export default Chat;
