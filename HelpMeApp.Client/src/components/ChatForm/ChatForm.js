import React, { useState } from 'react';
import { Container, Row, Col, Form, Button, ListGroup } from 'react-bootstrap';

const Chat = () => {
  const [selectedChatId, setSelectedChatId] = useState(null);
  const [message, setMessage] = useState('');
  const [chats, setChats] = useState([
    {
      id: 1,
      name: 'John Doe',
      messages: [
        { id: 1, text: 'Hello!' },
        { id: 2, text: 'How are you doing today?' },
      ],
    },
    {
      id: 2,
      name: 'Jane Doe',
      messages: [
        { id: 1, text: 'Hi!' },
        { id: 2, text: 'What\'s up?' },
      ],
    },
  ]);

  const handleSelectChat = (id) => {
    setSelectedChatId(id);
  };

  const handleSubmit = (event) => {
    event.preventDefault();
    const selectedChatIndex = chats.findIndex(chat => chat.id === selectedChatId);
    const newChats = [...chats];
    newChats[selectedChatIndex].messages.push({
      id: newChats[selectedChatIndex].messages.length + 1,
      text: message,
    });
    setChats(newChats);
    setMessage('');
  };

  return (
    <Container>
      <Row>
        <Col xs={4}>
          <h2>Chats</h2>
          <ListGroup>
            {chats.map((chat) => (
              <ListGroup.Item
                key={chat.id}
                action
                onClick={() => handleSelectChat(chat.id)}
                active={chat.id === selectedChatId}
              >
                {chat.name}
              </ListGroup.Item>
            ))}
          </ListGroup>
        </Col>
        <Col xs={8}>
          {selectedChatId ? (
            <>
              <h2>Chat with {chats.find(chat => chat.id === selectedChatId).name}</h2>
              <div className="chat-window">
                {chats.find(chat => chat.id === selectedChatId).messages.map((msg) => (
                  <div key={msg.id} className="message">
                    {msg.text}
                  </div>
                ))}
              </div>
              <Form onSubmit={handleSubmit}>
                <Form.Group controlId="formMessage">
                  <Form.Control
                    type="text"
                    placeholder="Enter message..."
                    value={message}
                    onChange={(event) => setMessage(event.target.value)}
                  />
                </Form.Group>
                <Button type="submit">Send</Button>
              </Form>
            </>
          ) : (
            <h2>Select a chat</h2>
          )}