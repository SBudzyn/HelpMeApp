using AutoMapper;
using HelpMeApp.DatabaseAccess.Entities.ChatEntity;
using HelpMeApp.DatabaseAccess.Interfaces;
using HelpMeApp.Services.Models.Chat;
using HelpMeApp.Services.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelpMeApp.Tests.Services
{
    [TestFixture]
    public class ChatServiceTests
    {
        private const string GetChatByIdAsyncMethodName = nameof(ChatService.GetChatByIdAsync);
        private const string GetChatByAdvertAndResponderAsyncMethodName = nameof(ChatService.GetChatByAdvertAndResponderAsync);
        private const string GetChatsByUserAsyncMethodName = nameof(ChatService.GetChatsByUserAsync);
        private const string AddChatAsyncMethodName = nameof(ChatService.AddChatAsync);

        private Mock<IChatReadRepository> _chatReadRepositoryMock;
        private Mock<IChatWriteRepository> _chatWriteRepositoryMock;
        private Mock<IMapper> _mapperMock;

        private ChatService _chatService;

        [SetUp]
        public void TestInitialize()
        {
            _chatReadRepositoryMock = new Mock<IChatReadRepository>();
            _chatWriteRepositoryMock = new Mock<IChatWriteRepository>();
            _mapperMock = new Mock<IMapper>();

            _chatService = new ChatService
                (
                _chatReadRepositoryMock.Object, 
                _chatWriteRepositoryMock.Object, 
                _mapperMock.Object
                );
        }

        [TestCase(TestName = $"{GetChatByIdAsyncMethodName}. Should return ChatPreviewData mapped from Chat")]
        public async Task GetChatByIdAsync_ReturnsChatPreviewData()
        {
            ChatPreviewData expected = new ChatPreviewData();

            int chatId = 1;

            SetupChatRepositoryGetChatByIdAsyncMock(chatId);
            SetupChatMappingProfileChatToChatPreviewData();

            var actual = await _chatService.GetChatByIdAsync(chatId);

            Assert.AreEqual(expected.GetType(), actual.GetType());
        }

        [TestCase(TestName = $"{GetChatByAdvertAndResponderAsyncMethodName}. Should return mapped ChatPreviewData")]
        public async Task GetChatByAdvertAndResponderAsync_ReturnsChatPreviewData()
        {
            ChatPreviewData expected = new ChatPreviewData();

            int chatId = 1;
            Guid userId = new Guid();

            SetupChatRepositoryGetChatByAdvertAndResponderAsyncMock(chatId, userId);
            SetupChatMappingProfileChatToChatPreviewData();

            var actual = await _chatService.GetChatByAdvertAndResponderAsync(chatId, userId);

            Assert.AreEqual(expected.GetType(), actual.GetType()); 
        }

        [TestCase(TestName = $"{GetChatsByUserAsyncMethodName}. Should return ChatPreviewData mapped from Chat recived from IChatRepository")]
        public async Task GetChatsByUserAsync_ReturnsChatPreviewData()
        {
            IEnumerable<ChatPreviewData> expected = CreateChatsPreviewResponseData();

            Guid userId = new Guid();
            int page = 1;
            int pageSize = 20;

            SetupChatRepositoryGetChatsByUserAsyncMock(userId, page, pageSize);
            SetupChatMappingProfileChatToChatPreviewData();

            var actual = await _chatService.GetChatsByUserAsync(userId, page, pageSize);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestName = $"{AddChatAsyncMethodName}. Should return ChatPreviewData that is mapped from added Chat")]
        public async Task AddChatAsync_ReturnsChatPreviewData()
        {
            ChatPreviewData expected = new ChatPreviewData();

            int advertId = 1;
            Guid userId = new Guid();

            SetupChatRepositoryAddChatAsyncMock();
            SetupChatMappingProfileChatToChatPreviewData();

            var actual = await _chatService.AddChatAsync(advertId, userId);

            Assert.AreEqual(expected.GetType(), actual.GetType());
        }

        private void SetupChatRepositoryGetChatByIdAsyncMock(int chatId)
        {
            _chatReadRepositoryMock
                .Setup(r => r.GetChatByIdAsync(chatId))
                .ReturnsAsync(new Chat());
        }

        private void SetupChatRepositoryGetChatByAdvertAndResponderAsyncMock(int chatId, Guid userId)
        {
            _chatReadRepositoryMock
                .Setup(r => r.GetChatByAdvertAndResponderAsync(chatId, userId))
                .ReturnsAsync(new Chat());
        }

        private void SetupChatRepositoryGetChatsByUserAsyncMock(Guid userId, int page, int pageSize)
        {
            _chatReadRepositoryMock
                .Setup(r => r.GetChatsByUserAsync(userId, page, pageSize))
                .ReturnsAsync(new List<Chat>());
        }

        private void SetupChatRepositoryAddChatAsyncMock()
        {
            _chatWriteRepositoryMock
                .Setup(r => r.AddChatAsync(It.IsAny<Chat>()))
                .ReturnsAsync(new Chat());
        }

        private void SetupChatMappingProfileChatToChatPreviewData()
        {
            _mapperMock
                .Setup(m => m.Map<ChatPreviewData>(It.IsAny<Chat>()))
                .Returns(new ChatPreviewData());

            _mapperMock
                .Setup(m => m.Map<IEnumerable<ChatPreviewData>>(It.IsAny<IEnumerable<Chat>>()))
                .Returns(new List<ChatPreviewData>());
        }

        private IEnumerable<ChatPreviewData> CreateChatsPreviewResponseData()
        {
            return new List<ChatPreviewData>(); 
        }
    }
}
