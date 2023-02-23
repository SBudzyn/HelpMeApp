using AutoMapper;
using HelpMeApp.DatabaseAccess.Interfaces;
using HelpMeApp.Services.Services;
using Moq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using System.Collections.Generic;
using HelpMeApp.DatabaseAccess.Entities.MessageEntity;
using HelpMeApp.DatabaseAccess.Entities.ChatEntity;
using HelpMeApp.Services.Models.Message;


namespace HelpMeApp.Tests.Services
{
    [TestFixture]
    public class MessagesServiceTests
    {
        private const string GetMessagesByChatMethodName = nameof(MessageService.GetMessagesByChat);
        private const string AddMessageAsyncMethodName = nameof(MessageService.AddMessageAsync);

        private Mock<IMessageWriteRepository> _messageWriteRepositoryMock;
        private Mock<IMessageReadRepository> _messageReadRepositoryMock;
        private Mock<IChatReadRepository> _chatReadRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private MessageService _messageService;

        [SetUp]
        public void TestInitialize()
        {
            _messageWriteRepositoryMock = new Mock<IMessageWriteRepository>();
            _messageReadRepositoryMock = new Mock<IMessageReadRepository>();
            _chatReadRepositoryMock = new Mock<IChatReadRepository>();
            _mapperMock = new Mock<IMapper>();

            _messageService = new MessageService
                (
                _messageReadRepositoryMock.Object,
                _messageWriteRepositoryMock.Object,
                _chatReadRepositoryMock.Object,
                _mapperMock.Object
            );
        }

        [TestCase(TestName = $"{GetMessagesByChatMethodName}. Should return all messages from the chat which id you provide to messageReadRepository")]
        public async Task GetReportByAdvertAndUserAsyncMethodName_ReturnsReportData()
        {
            IEnumerable<MessageData> expected = CreateMessageData();

            int chatID = 20;
            int page = 1;
            int amount = 100;

            SetupGetMessagesByChatAsyncMock(chatID, page, amount);
            SetupMessageMappingProfileToMessageDataMock();

            var actual = await _messageService.GetMessagesByChat(chatID);

            Assert.AreEqual(expected.GetType(), actual.GetType());
        }

        [TestCase(TestName = $"{AddMessageAsyncMethodName}. Should create a new message, passing the content of the message")]
        public async Task AddReportAsyncMethodName_ReturnsReportData()
        {
            MessageData expected = new MessageData();

            int chatId = 20;
            MessageData message = new MessageData();
            message.ChatId = chatId;

            SetupMessageMappingProfileToMessageMock();
            SetupChatRepositoryGetChatByIdAsyncMock(chatId);

            SetupAddMessageAsyncMock(new Message());
            SetupMessageMappingProfileToMessageDataMock();

            var actual = await _messageService.AddMessageAsync(message);

            Assert.AreEqual(expected.GetType(), actual.GetType());
        }

        private void SetupGetMessagesByChatAsyncMock(int chatId, int page, int amount)
        {
            _messageReadRepositoryMock
                .Setup(r => r.GetMessagesByChatAsync(chatId, page, amount))
                .ReturnsAsync(new List<Message>());
        }

        private void SetupChatRepositoryGetChatByIdAsyncMock(int chatId)
        {
            _chatReadRepositoryMock
                .Setup(r => r.GetChatByIdAsync(chatId))
                .ReturnsAsync(new Chat());
        }

        private void SetupAddMessageAsyncMock(Message message)
        {
            _messageWriteRepositoryMock
                .Setup(r => r.AddMessageAsync(message))
                .ReturnsAsync(new Message());
        }

        private void SetupMessageMappingProfileToMessageMock()
        {
            _mapperMock
                .Setup(m => m.Map<Message>(It.IsAny<MessageData>()))
                .Returns(new Message());
        }

        private void SetupMessageMappingProfileToMessageDataMock()
        {
            _mapperMock
                .Setup(m => m.Map<IEnumerable<MessageData>>(It.IsAny<IEnumerable<Message>>()))
                .Returns(new List<MessageData>());

            _mapperMock
                .Setup(m => m.Map<MessageData>(It.IsAny<Message>()))
                .Returns(new MessageData());
        }
        private IEnumerable<MessageData> CreateMessageData()
        {
            return new List<MessageData>();
        }
    }
}
