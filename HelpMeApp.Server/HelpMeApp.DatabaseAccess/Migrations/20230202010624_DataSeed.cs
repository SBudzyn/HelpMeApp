using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HelpMeApp.DatabaseAccess.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Messages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 2, 3, 6, 23, 737, DateTimeKind.Local).AddTicks(9541),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 31, 16, 47, 50, 893, DateTimeKind.Local).AddTicks(2665));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Adverts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 2, 3, 6, 23, 733, DateTimeKind.Local).AddTicks(1837),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 31, 16, 47, 50, 891, DateTimeKind.Local).AddTicks(6217));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), "5624a84f-ab8c-4498-8ae3-d25a0910021b", "User", "User" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Info", "IsBlocked", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "RegistrationDate", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("02d2177d-6e46-0306-06d7-8e3065753445"), 0, "2c3ea761-2453-4180-9628-4a52c67e6bc1", "Ladislav_Ladislav.Priimak64@gmail.com", false, "Use the mobile CSS system, then you can parse the mobile system!", true, false, null, "Ладислав", null, null, "AQAAAAEAACcQAAAAEHNc9e5MaJeybTy9yXbLqSoZY9lNezFCbcZgCL1i1/M7+CPhCFuEnBVN9s0IyHhowA==", "(095) 171-26-01", false, null, new DateTime(2022, 8, 21, 10, 12, 58, 112, DateTimeKind.Local).AddTicks(9503), null, "Приймак", false, "Ladislav.Priimak64" },
                    { new Guid("02fef29f-b5bf-f009-8887-280899f88b67"), 0, "aceef75b-17ef-4668-b8d2-d4ab622a0516", "Likera_Likera52@yandex.ua", false, "The SAS array is down, bypass the online array so we can bypass the SAS array!", false, false, null, "Ликера", null, null, "AQAAAAEAACcQAAAAENAawxTUPj8OLehw5iD8cJq2P8EJuUmSFPYKm9FZftluulOpmnTRQeXhSIRqeORawQ==", "(063) 359-72-74", false, null, new DateTime(2022, 6, 9, 21, 12, 24, 849, DateTimeKind.Local).AddTicks(9924), null, "Семещук", false, "Likera52" },
                    { new Guid("55f416d2-6097-35b3-8ab5-078b8ca7c988"), 0, "ceadb7d2-9ec2-4065-a064-99ddfecff307", "Yaromir45@i.ua", false, "The FTP panel is down, navigate the back-end panel so we can navigate the FTP panel!", true, false, null, "Яромир", null, null, "AQAAAAEAACcQAAAAEMpytf4+CeZUfOUJdfTWxmndxyt6NfNz13g9zdiHSy/G4GN7+/yTyD+dx01MB+r9zQ==", "(093) 611-85-56", false, null, new DateTime(2022, 12, 8, 23, 37, 59, 922, DateTimeKind.Local).AddTicks(3652), null, "Романишин", false, "Yaromir.Romanishin" },
                    { new Guid("6baf6055-d491-d658-2560-7778763900cf"), 0, "00c90365-31ac-4060-9723-3ea5e1757cf9", "Valeriya98@i.ua", false, "I'll index the online SMTP port, that should port the SMTP port!", true, false, null, "Валерія", null, null, "AQAAAAEAACcQAAAAEO5TJAhAkRLdkRNVvhAbSO0gAmBBtqnvIy3NyPnFz3TkiwbvpWIwZZa+N7nwNGgy5Q==", "(093) 037-64-63", false, null, new DateTime(2022, 5, 19, 10, 5, 3, 528, DateTimeKind.Local).AddTicks(8784), null, "Ющик", false, "Valeriya.Yushik97" },
                    { new Guid("7fef9ddd-9900-82d4-7a1e-c93ddc233c4f"), 0, "5a5e82f2-e2c9-498c-94b6-af625811d50e", "Askold.Askold6459@yandex.ua", false, "We need to hack the bluetooth AGP firewall!", true, false, null, "Аскольд", null, null, "AQAAAAEAACcQAAAAEOQtIWdxF/BLOmFbEDRVA6J6XtsKZvU60pxVIZ5lIPNfIfYc+qxn75+GFascZEGWJA==", "(044) 715-04-59", false, null, new DateTime(2023, 1, 21, 6, 28, 9, 486, DateTimeKind.Local).AddTicks(4726), null, "Шудрик", false, "Askold64" },
                    { new Guid("8439b313-3a31-7d6b-93f7-034ef2abf67c"), 0, "601dd4af-c1db-4b92-9897-751608f0dbe0", "Pavlo.Pavlo29@ukr.net", false, "The AI microchip is down, override the auxiliary microchip so we can override the AI microchip!", false, false, null, "Павло", null, null, "AQAAAAEAACcQAAAAEASUSBpN5EqV3sqzDb8/Ui1pZZza2qLnw5sT8Lw0K39xN86jLo4EJt3sW3kKsLiVSg==", "(094) 174-69-88", false, null, new DateTime(2022, 7, 26, 8, 51, 19, 503, DateTimeKind.Local).AddTicks(2870), null, "Гриневський", false, "Pavlo29" },
                    { new Guid("a3a60e61-7c65-937c-651e-a50739ec0bf1"), 0, "ce48e41c-bef1-426c-abdb-cd3df3add430", "Varvara.Varvara9422@e-mail.ua", false, "You can't transmit the sensor without programming the solid state JSON sensor!", false, false, null, "Варвара", null, null, "AQAAAAEAACcQAAAAECuLNnh7HuSYpiMe2/V9tCSGQYBo3Dmd/WSzeYg2XKlgk68rx8fQsLMBcLXDtdY5Vw==", "(092) 517-54-97", false, null, new DateTime(2022, 10, 7, 1, 5, 38, 772, DateTimeKind.Local).AddTicks(4493), null, "Гордійчук", false, "Varvara94" },
                    { new Guid("c9952c43-7999-5b85-7360-15ef416336de"), 0, "948c2afb-0480-4dea-afe0-7eb305ea423c", "Biloslav_Biloslav_Kordun@i.ua", false, "We need to calculate the neural PCI firewall!", true, false, null, "Білослав", null, null, "AQAAAAEAACcQAAAAED55MVYuLyZZ1lXfcS3I4ygEwsvD3FFudeFKcgyAt0uZx+DLUNndU5WDj0MFDILMGA==", "(093) 660-40-77", false, null, new DateTime(2022, 6, 17, 10, 48, 10, 556, DateTimeKind.Local).AddTicks(8663), null, "Кордун", false, "Biloslav_Kordun" },
                    { new Guid("f584b332-a830-2155-f34e-bc54009ca3ed"), 0, "bb3cd9bb-6d42-4488-bb3e-6da5d9fa752e", "Yaromir_Yaromir_Kolomiyec96@i.ua", false, "We need to quantify the online HTTP array!", false, false, null, "Яромир", null, null, "AQAAAAEAACcQAAAAEPSF5S8YjoOcOUVeCIYEnafhf+POl4kStsI+S2eDQBXKafl3j+ITi/KfhqtaIPO+bA==", "(092) 153-89-49", false, null, new DateTime(2022, 7, 26, 11, 50, 41, 473, DateTimeKind.Local).AddTicks(2571), null, "Коломієць", false, "Yaromir_Kolomiyec96" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Food" },
                    { 2, "Clothes" },
                    { 3, "Evacuation" },
                    { 4, "Repairs" }
                });

            migrationBuilder.InsertData(
                table: "HelpTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "NeedHelp" },
                    { 2, "CanHelp" }
                });

            migrationBuilder.InsertData(
                table: "SenderRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Creator" },
                    { 2, "Responder" },
                    { 3, "System" }
                });

            migrationBuilder.InsertData(
                table: "Terms",
                columns: new[] { "Id", "Days" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 5 },
                    { 3, 10 },
                    { 4, 14 },
                    { 5, 21 }
                });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "CategoryId", "ClosureDate", "CreationDate", "CreatorId", "Header", "HelpTypeId", "Info", "Location", "TermsId" },
                values: new object[] { 1, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 17, 22, 31, 57, 226, DateTimeKind.Unspecified).AddTicks(5192), new Guid("f584b332-a830-2155-f34e-bc54009ca3ed"), "I'll bypass the digital AGP bandwidth, that should bandwidth the AGP bandwidth!", 1, "I'll connect the 1080p CSS application, that should application the CSS application!", "Західний Борислав", 5 });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "CategoryId", "ClosureDate", "CreationDate", "CreatorId", "Header", "HelpTypeId", "Info", "IsClosed", "Location", "TermsId" },
                values: new object[] { 2, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 17, 9, 34, 50, 561, DateTimeKind.Unspecified).AddTicks(3583), new Guid("f584b332-a830-2155-f34e-bc54009ca3ed"), "If we synthesize the hard drive, we can get to the SDD hard drive through the online SDD hard drive!", 2, "If we calculate the hard drive, we can get to the RAM hard drive through the redundant RAM hard drive!", true, "Єнакієве", 3 });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "CategoryId", "ClosureDate", "CreationDate", "CreatorId", "Header", "HelpTypeId", "Info", "Location", "TermsId" },
                values: new object[,]
                {
                    { 3, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 13, 15, 6, 48, 736, DateTimeKind.Unspecified).AddTicks(6536), new Guid("f584b332-a830-2155-f34e-bc54009ca3ed"), "Try to navigate the PNG microchip, maybe it will navigate the digital microchip!", 1, "We need to hack the auxiliary GB array!", "Донецьк", 3 },
                    { 4, 1, new DateTime(2023, 2, 6, 20, 8, 7, 797, DateTimeKind.Unspecified).AddTicks(4818), new DateTime(2023, 1, 16, 6, 48, 5, 737, DateTimeKind.Unspecified).AddTicks(6883), new Guid("55f416d2-6097-35b3-8ab5-078b8ca7c988"), "We need to index the auxiliary JBOD port!", 1, "Use the wireless SDD monitor, then you can compress the wireless monitor!", "Західний Анастас", 3 },
                    { 5, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 6, 36, 40, 432, DateTimeKind.Unspecified).AddTicks(4934), new Guid("55f416d2-6097-35b3-8ab5-078b8ca7c988"), "Try to connect the SMTP capacitor, maybe it will connect the auxiliary capacitor!", 1, "Try to connect the EXE bandwidth, maybe it will connect the redundant bandwidth!", "Кіровоград", 5 },
                    { 6, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 3, 13, 39, 49, 259, DateTimeKind.Unspecified).AddTicks(7517), new Guid("55f416d2-6097-35b3-8ab5-078b8ca7c988"), "You can't hack the bus without calculating the digital ADP bus!", 1, "The PNG transmitter is down, back up the mobile transmitter so we can back up the PNG transmitter!", "Східний Григорій", 3 }
                });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "CategoryId", "ClosureDate", "CreationDate", "CreatorId", "Header", "HelpTypeId", "Info", "IsClosed", "Location", "TermsId" },
                values: new object[] { 7, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 12, 4, 35, 10, 205, DateTimeKind.Unspecified).AddTicks(39), new Guid("02fef29f-b5bf-f009-8887-280899f88b67"), "I'll transmit the back-end THX alarm, that should alarm the THX alarm!", 2, "Use the haptic FTP application, then you can quantify the haptic application!", true, "Бердичів", 2 });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "CategoryId", "ClosureDate", "CreationDate", "CreatorId", "Header", "HelpTypeId", "Info", "Location", "TermsId" },
                values: new object[] { 8, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 17, 19, 28, 32, 378, DateTimeKind.Unspecified).AddTicks(577), new Guid("02fef29f-b5bf-f009-8887-280899f88b67"), "I'll reboot the virtual JBOD monitor, that should monitor the JBOD monitor!", 1, "If we copy the application, we can get to the SMTP application through the 1080p SMTP application!", "Слов’янськ", 3 });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "CategoryId", "ClosureDate", "CreationDate", "CreatorId", "Header", "HelpTypeId", "Info", "IsClosed", "Location", "TermsId" },
                values: new object[,]
                {
                    { 9, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 5, 18, 6, 53, 445, DateTimeKind.Unspecified).AddTicks(5448), new Guid("6baf6055-d491-d658-2560-7778763900cf"), "We need to connect the 1080p SAS application!", 1, "We need to hack the primary SQL circuit!", true, "Східний Іван", 5 },
                    { 10, 3, new DateTime(2023, 1, 27, 18, 34, 31, 446, DateTimeKind.Unspecified).AddTicks(9327), new DateTime(2023, 1, 13, 23, 49, 35, 852, DateTimeKind.Unspecified).AddTicks(9526), new Guid("6baf6055-d491-d658-2560-7778763900cf"), "Use the neural USB firewall, then you can navigate the neural firewall!", 2, "copying the array won't do anything, we need to navigate the haptic THX array!", true, "Східний Тиміш", 5 }
                });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "CategoryId", "ClosureDate", "CreationDate", "CreatorId", "Header", "HelpTypeId", "Info", "Location", "TermsId" },
                values: new object[] { 11, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 21, 4, 14, 24, 46, DateTimeKind.Unspecified).AddTicks(7655), new Guid("6baf6055-d491-d658-2560-7778763900cf"), "We need to connect the optical IB bus!", 2, "Use the redundant EXE firewall, then you can reboot the redundant firewall!", "Артемівськ", 5 });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "CategoryId", "ClosureDate", "CreationDate", "CreatorId", "Header", "HelpTypeId", "Info", "IsClosed", "Location", "TermsId" },
                values: new object[] { 12, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 7, 12, 24, 46, 35, DateTimeKind.Unspecified).AddTicks(2516), new Guid("7fef9ddd-9900-82d4-7a1e-c93ddc233c4f"), "You can't bypass the driver without transmitting the mobile AI driver!", 2, "You can't calculate the system without indexing the open-source IB system!", true, "Єнакієве", 4 });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "CategoryId", "ClosureDate", "CreationDate", "CreatorId", "Header", "HelpTypeId", "Info", "Location", "TermsId" },
                values: new object[] { 13, 2, new DateTime(2023, 1, 30, 3, 3, 22, 542, DateTimeKind.Unspecified).AddTicks(7005), new DateTime(2023, 1, 3, 7, 52, 16, 845, DateTimeKind.Unspecified).AddTicks(1459), new Guid("7fef9ddd-9900-82d4-7a1e-c93ddc233c4f"), "We need to hack the multi-byte RAM bus!", 1, "You can't bypass the array without quantifying the auxiliary IB array!", "Сімферополь", 4 });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "CategoryId", "ClosureDate", "CreationDate", "CreatorId", "Header", "HelpTypeId", "Info", "IsClosed", "Location", "TermsId" },
                values: new object[,]
                {
                    { 14, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 9, 33, 51, 448, DateTimeKind.Unspecified).AddTicks(5427), new Guid("7fef9ddd-9900-82d4-7a1e-c93ddc233c4f"), "Use the wireless PCI pixel, then you can generate the wireless pixel!", 1, "You can't connect the card without hacking the cross-platform PCI card!", true, "Північний Гаврило", 1 },
                    { 15, 2, new DateTime(2023, 1, 27, 3, 12, 25, 104, DateTimeKind.Unspecified).AddTicks(8756), new DateTime(2023, 1, 19, 19, 17, 16, 600, DateTimeKind.Unspecified).AddTicks(8337), new Guid("c9952c43-7999-5b85-7360-15ef416336de"), "You can't synthesize the driver without navigating the solid state FTP driver!", 1, "You can't compress the system without copying the wireless PCI system!", true, "Красний Луч", 2 },
                    { 16, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 10, 4, 22, 766, DateTimeKind.Unspecified).AddTicks(8341), new Guid("c9952c43-7999-5b85-7360-15ef416336de"), "If we navigate the sensor, we can get to the AI sensor through the digital AI sensor!", 2, "You can't calculate the protocol without bypassing the multi-byte IB protocol!", true, "Західний Адам", 3 },
                    { 17, 2, new DateTime(2023, 2, 9, 12, 34, 0, 132, DateTimeKind.Unspecified).AddTicks(7091), new DateTime(2023, 1, 8, 20, 22, 17, 17, DateTimeKind.Unspecified).AddTicks(7804), new Guid("c9952c43-7999-5b85-7360-15ef416336de"), "If we generate the port, we can get to the SDD port through the cross-platform SDD port!", 2, "Use the open-source GB panel, then you can generate the open-source panel!", true, "Чернігів", 3 }
                });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "CategoryId", "ClosureDate", "CreationDate", "CreatorId", "Header", "HelpTypeId", "Info", "Location", "TermsId" },
                values: new object[,]
                {
                    { 18, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 15, 32, 23, 754, DateTimeKind.Unspecified).AddTicks(1179), new Guid("c9952c43-7999-5b85-7360-15ef416336de"), "Try to bypass the PCI pixel, maybe it will bypass the multi-byte pixel!", 2, "Use the open-source SMS matrix, then you can bypass the open-source matrix!", "Північний Архип", 1 },
                    { 19, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 22, 11, 8, 16, 389, DateTimeKind.Unspecified).AddTicks(7758), new Guid("02d2177d-6e46-0306-06d7-8e3065753445"), "Use the online SMTP bus, then you can navigate the online bus!", 1, "copying the microchip won't do anything, we need to bypass the neural AI microchip!", "Краматорськ", 1 }
                });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "CategoryId", "ClosureDate", "CreationDate", "CreatorId", "Header", "HelpTypeId", "Info", "IsClosed", "Location", "TermsId" },
                values: new object[] { 20, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 4, 19, 7, 43, 768, DateTimeKind.Unspecified).AddTicks(5754), new Guid("02d2177d-6e46-0306-06d7-8e3065753445"), "We need to transmit the virtual JBOD feed!", 1, "Try to copy the RAM feed, maybe it will copy the open-source feed!", true, "Нікополь", 1 });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "CategoryId", "ClosureDate", "CreationDate", "CreatorId", "Header", "HelpTypeId", "Info", "Location", "TermsId" },
                values: new object[] { 21, 2, new DateTime(2023, 1, 26, 11, 9, 16, 426, DateTimeKind.Unspecified).AddTicks(1430), new DateTime(2023, 1, 20, 12, 12, 17, 110, DateTimeKind.Unspecified).AddTicks(1241), new Guid("8439b313-3a31-7d6b-93f7-034ef2abf67c"), "You can't navigate the circuit without copying the redundant TCP circuit!", 1, "The COM capacitor is down, copy the neural capacitor so we can copy the COM capacitor!", "Південний Ладо", 2 });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "CategoryId", "ClosureDate", "CreationDate", "CreatorId", "Header", "HelpTypeId", "Info", "IsClosed", "Location", "TermsId" },
                values: new object[,]
                {
                    { 22, 3, new DateTime(2023, 1, 27, 21, 35, 34, 451, DateTimeKind.Unspecified).AddTicks(3838), new DateTime(2023, 1, 21, 2, 44, 24, 427, DateTimeKind.Unspecified).AddTicks(5294), new Guid("8439b313-3a31-7d6b-93f7-034ef2abf67c"), "The SMS monitor is down, synthesize the auxiliary monitor so we can synthesize the SMS monitor!", 2, "Try to transmit the RSS interface, maybe it will transmit the 1080p interface!", true, "Конотоп", 2 },
                    { 23, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 10, 15, 59, 896, DateTimeKind.Unspecified).AddTicks(3865), new Guid("8439b313-3a31-7d6b-93f7-034ef2abf67c"), "We need to override the mobile SMTP matrix!", 1, "If we back up the application, we can get to the PCI application through the multi-byte PCI application!", true, "Північний Орхип", 4 },
                    { 24, 3, new DateTime(2023, 2, 5, 19, 21, 35, 690, DateTimeKind.Unspecified).AddTicks(3961), new DateTime(2023, 1, 5, 16, 43, 35, 225, DateTimeKind.Unspecified).AddTicks(2180), new Guid("a3a60e61-7c65-937c-651e-a50739ec0bf1"), "Use the haptic XSS sensor, then you can input the haptic sensor!", 2, "We need to override the 1080p SDD port!", true, "Ужгород", 4 }
                });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "CategoryId", "ClosureDate", "CreationDate", "CreatorId", "Header", "HelpTypeId", "Info", "Location", "TermsId" },
                values: new object[] { 25, 1, new DateTime(2023, 1, 28, 7, 42, 6, 884, DateTimeKind.Unspecified).AddTicks(6641), new DateTime(2023, 1, 23, 19, 54, 5, 988, DateTimeKind.Unspecified).AddTicks(8106), new Guid("a3a60e61-7c65-937c-651e-a50739ec0bf1"), "We need to generate the back-end HTTP alarm!", 1, "Try to generate the AGP port, maybe it will generate the bluetooth port!", "Північний Юліан", 2 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("02d2177d-6e46-0306-06d7-8e3065753445") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("02fef29f-b5bf-f009-8887-280899f88b67") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("55f416d2-6097-35b3-8ab5-078b8ca7c988") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("6baf6055-d491-d658-2560-7778763900cf") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("7fef9ddd-9900-82d4-7a1e-c93ddc233c4f") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("8439b313-3a31-7d6b-93f7-034ef2abf67c") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("a3a60e61-7c65-937c-651e-a50739ec0bf1") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("c9952c43-7999-5b85-7360-15ef416336de") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("f584b332-a830-2155-f34e-bc54009ca3ed") }
                });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "AdvertId", "Id", "UserId", "IsConfirmedByCreator", "IsConfirmedBySecondSide" },
                values: new object[,]
                {
                    { 5, 1, new Guid("f584b332-a830-2155-f34e-bc54009ca3ed"), true, true },
                    { 5, 2, new Guid("f584b332-a830-2155-f34e-bc54009ca3ed"), true, true }
                });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "AdvertId", "Id", "UserId" },
                values: new object[] { 5, 3, new Guid("f584b332-a830-2155-f34e-bc54009ca3ed") });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "AdvertId", "Id", "UserId", "IsConfirmedBySecondSide" },
                values: new object[] { 1, 4, new Guid("55f416d2-6097-35b3-8ab5-078b8ca7c988"), true });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "AdvertId", "Id", "UserId" },
                values: new object[] { 2, 5, new Guid("55f416d2-6097-35b3-8ab5-078b8ca7c988") });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "AdvertId", "Id", "UserId", "IsConfirmedByCreator", "IsConfirmedBySecondSide" },
                values: new object[] { 3, 6, new Guid("55f416d2-6097-35b3-8ab5-078b8ca7c988"), true, true });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "AdvertId", "Id", "UserId" },
                values: new object[] { 2, 7, new Guid("02fef29f-b5bf-f009-8887-280899f88b67") });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "AdvertId", "Id", "UserId", "IsConfirmedBySecondSide" },
                values: new object[,]
                {
                    { 3, 8, new Guid("02fef29f-b5bf-f009-8887-280899f88b67"), true },
                    { 6, 9, new Guid("02fef29f-b5bf-f009-8887-280899f88b67"), true }
                });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "AdvertId", "Id", "UserId", "IsConfirmedByCreator" },
                values: new object[] { 4, 10, new Guid("6baf6055-d491-d658-2560-7778763900cf"), true });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "AdvertId", "Id", "UserId", "IsConfirmedByCreator", "IsConfirmedBySecondSide" },
                values: new object[] { 6, 11, new Guid("6baf6055-d491-d658-2560-7778763900cf"), true, true });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "AdvertId", "Id", "UserId" },
                values: new object[] { 10, 12, new Guid("7fef9ddd-9900-82d4-7a1e-c93ddc233c4f") });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "AdvertId", "Id", "UserId", "IsConfirmedByCreator", "IsConfirmedBySecondSide" },
                values: new object[] { 8, 13, new Guid("c9952c43-7999-5b85-7360-15ef416336de"), true, true });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "AdvertId", "Id", "UserId" },
                values: new object[] { 10, 14, new Guid("c9952c43-7999-5b85-7360-15ef416336de") });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "AdvertId", "Id", "UserId", "IsConfirmedBySecondSide" },
                values: new object[,]
                {
                    { 8, 15, new Guid("c9952c43-7999-5b85-7360-15ef416336de"), true },
                    { 3, 16, new Guid("02d2177d-6e46-0306-06d7-8e3065753445"), true }
                });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "AdvertId", "Id", "UserId", "IsConfirmedByCreator", "IsConfirmedBySecondSide" },
                values: new object[] { 4, 17, new Guid("02d2177d-6e46-0306-06d7-8e3065753445"), true, true });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "AdvertId", "Id", "UserId", "IsConfirmedBySecondSide" },
                values: new object[,]
                {
                    { 1, 18, new Guid("02d2177d-6e46-0306-06d7-8e3065753445"), true },
                    { 13, 19, new Guid("8439b313-3a31-7d6b-93f7-034ef2abf67c"), true }
                });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "AdvertId", "Id", "UserId", "IsConfirmedByCreator" },
                values: new object[] { 17, 20, new Guid("8439b313-3a31-7d6b-93f7-034ef2abf67c"), true });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "AdvertId", "Id", "UserId", "IsConfirmedBySecondSide" },
                values: new object[,]
                {
                    { 11, 21, new Guid("8439b313-3a31-7d6b-93f7-034ef2abf67c"), true },
                    { 23, 22, new Guid("a3a60e61-7c65-937c-651e-a50739ec0bf1"), true }
                });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "AdvertId", "Id", "UserId" },
                values: new object[] { 23, 23, new Guid("a3a60e61-7c65-937c-651e-a50739ec0bf1") });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "AdvertId", "Id", "UserId", "IsConfirmedBySecondSide" },
                values: new object[] { 13, 24, new Guid("a3a60e61-7c65-937c-651e-a50739ec0bf1"), true });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "AdvertId", "Text", "UserId" },
                values: new object[,]
                {
                    { 1, 5, "Dolores fugiat recusandae libero ut atque voluptatem pariatur asperiores culpa.\nExercitationem dolore non autem ut rerum ut ea.\nModi excepturi aperiam aperiam.\nNihil rerum nesciunt error ex facilis.\nEt minima non ut iusto rem aliquam.", new Guid("f584b332-a830-2155-f34e-bc54009ca3ed") },
                    { 2, 5, "Dolores quia sint dignissimos dolorem vero deserunt voluptatem.\nQuia fuga dignissimos porro cumque fuga quibusdam eveniet modi.\nUt et veniam rerum.", new Guid("f584b332-a830-2155-f34e-bc54009ca3ed") },
                    { 3, 3, "Suscipit soluta corporis nulla cumque.", new Guid("55f416d2-6097-35b3-8ab5-078b8ca7c988") },
                    { 4, 5, "Magni neque corporis similique et ut voluptas.\nDolorem molestiae perferendis expedita qui qui itaque.\nOccaecati expedita omnis fuga aut magnam debitis ad aut doloribus.\nVoluptas tenetur consequuntur sit eos aut cumque veniam.\nDolorum corrupti eaque quia unde sed qui.", new Guid("02fef29f-b5bf-f009-8887-280899f88b67") },
                    { 5, 4, "Voluptatem temporibus consequatur eum magnam.\nVitae reiciendis autem ipsum sed.\nMinus ab voluptatum suscipit ab voluptatem non distinctio vero laborum.\nAut nulla totam delectus cumque quidem.", new Guid("6baf6055-d491-d658-2560-7778763900cf") },
                    { 6, 4, "Veritatis provident ducimus beatae aut adipisci veniam sequi.\nProvident sed consequuntur atque quibusdam odio et commodi.\nMolestiae sed est fugit.\nVoluptate velit corrupti ut dolor exercitationem.", new Guid("6baf6055-d491-d658-2560-7778763900cf") },
                    { 7, 7, "Maiores ducimus ducimus molestiae alias quia ut.", new Guid("7fef9ddd-9900-82d4-7a1e-c93ddc233c4f") },
                    { 8, 11, "Minus officiis velit ad mollitia eveniet corrupti harum.\nVoluptatem laborum illum quos aut eos et.", new Guid("7fef9ddd-9900-82d4-7a1e-c93ddc233c4f") },
                    { 9, 13, "Qui veritatis dolores tempora.\nEst quidem distinctio.\nFacere quisquam placeat.", new Guid("c9952c43-7999-5b85-7360-15ef416336de") },
                    { 10, 14, "Vero suscipit placeat labore et.\nQui optio et atque.\nNobis qui possimus voluptatem sunt reprehenderit.\nUt alias atque repellendus non.", new Guid("02d2177d-6e46-0306-06d7-8e3065753445") },
                    { 11, 3, "Architecto id in ratione officiis.\nCommodi inventore qui aliquid et.", new Guid("02d2177d-6e46-0306-06d7-8e3065753445") },
                    { 12, 1, "Consequatur dolor repellendus est aspernatur aut et nesciunt.\nDucimus illo ab sapiente.\nQuas dolorem magni amet exercitationem harum consequatur deserunt.\nSaepe in praesentium.\nVoluptatem ut sed tempora.", new Guid("8439b313-3a31-7d6b-93f7-034ef2abf67c") },
                    { 13, 18, "Dolor consequatur enim id deleniti eaque.", new Guid("8439b313-3a31-7d6b-93f7-034ef2abf67c") },
                    { 14, 13, "Asperiores maxime rerum.\nRepudiandae tempora adipisci rerum.\nSuscipit saepe ea atque qui.\nRepudiandae et aspernatur aut.\nSoluta cupiditate odio error consequuntur qui rerum assumenda possimus veniam.", new Guid("a3a60e61-7c65-937c-651e-a50739ec0bf1") }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "ChatId", "CreationDate", "SenderRoleId", "Text" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 2, 1, 18, 41, 46, 466, DateTimeKind.Local).AddTicks(707), 2, "Rem porro consequatur ea est iure occaecati deserunt dolorum nulla." },
                    { 2, 1, new DateTime(2023, 2, 1, 6, 30, 3, 612, DateTimeKind.Local).AddTicks(5597), 1, "Sit beatae sed culpa.\nOmnis sed dolore inventore consequatur accusamus non atque culpa eius.\nNecessitatibus adipisci quia itaque cumque voluptates.\nIpsam aut labore ad nemo id aliquid consectetur." },
                    { 3, 1, new DateTime(2023, 2, 1, 10, 9, 4, 846, DateTimeKind.Local).AddTicks(8346), 2, "Ratione ipsum iure dolores voluptatum vel tempora distinctio et provident.\nUt earum autem ipsum a sequi rerum.\nVoluptatum aut dignissimos necessitatibus id nam ad incidunt facilis." },
                    { 4, 1, new DateTime(2023, 2, 1, 15, 42, 28, 605, DateTimeKind.Local).AddTicks(8187), 3, "Voluptatem nam quasi minima quas cumque facilis natus." },
                    { 5, 1, new DateTime(2023, 2, 1, 20, 0, 17, 455, DateTimeKind.Local).AddTicks(5158), 1, "Praesentium suscipit suscipit recusandae iusto qui aperiam aut quibusdam.\nAut cumque veniam dolor eum sed voluptatem qui tenetur voluptatibus.\nOfficiis aut ad corporis necessitatibus qui blanditiis.\nEius alias eos est.\nQui sit itaque." },
                    { 6, 1, new DateTime(2023, 2, 2, 1, 40, 38, 659, DateTimeKind.Local).AddTicks(1516), 1, "Eaque voluptas eaque vero quis repellat quisquam officiis dignissimos.\nSaepe exercitationem at voluptatem officia qui." },
                    { 7, 1, new DateTime(2023, 2, 1, 6, 0, 38, 55, DateTimeKind.Local).AddTicks(702), 2, "Culpa id culpa voluptatibus earum explicabo quia rerum dolores voluptatem.\nQuis rerum sed atque doloremque nulla quam recusandae necessitatibus.\nQui autem consequatur aut similique possimus nulla iste." },
                    { 8, 1, new DateTime(2023, 2, 2, 1, 6, 46, 541, DateTimeKind.Local).AddTicks(5355), 3, "Consequatur sed ullam voluptatem illo repudiandae minima dolorem.\nAutem dolor iste.\nEt est omnis iste est rerum optio.\nNumquam repellat earum est officiis autem suscipit voluptas." },
                    { 9, 1, new DateTime(2023, 2, 1, 5, 7, 33, 395, DateTimeKind.Local).AddTicks(365), 2, "Impedit ad repellat sit.\nTemporibus quas expedita et facilis quia laborum magnam deserunt." },
                    { 10, 2, new DateTime(2023, 2, 2, 2, 5, 47, 671, DateTimeKind.Local).AddTicks(6189), 1, "Aut sequi quia ea quos sit ut earum dolores alias.\nAutem quis consequatur vel et mollitia temporibus illum eos." },
                    { 11, 3, new DateTime(2023, 2, 1, 8, 22, 22, 574, DateTimeKind.Local).AddTicks(5646), 1, "Praesentium tempora voluptatem vitae ut.\nEius optio sed autem.\nAd est sapiente quo sunt facilis ducimus qui aut." },
                    { 12, 3, new DateTime(2023, 2, 1, 19, 12, 41, 614, DateTimeKind.Local).AddTicks(3370), 2, "Non blanditiis aspernatur molestiae nihil qui.\nAccusantium ut ut beatae quo ut.\nVelit facilis voluptatem aut quaerat vero est excepturi non quia." },
                    { 13, 3, new DateTime(2023, 2, 1, 4, 28, 21, 513, DateTimeKind.Local).AddTicks(3156), 1, "Molestias rerum et et est.\nAccusamus necessitatibus ab nostrum ad provident autem quibusdam nemo.\nAut repellat laboriosam qui eaque quia qui libero.\nMollitia optio cumque dolore et.\nVelit distinctio beatae occaecati voluptas ea nesciunt." },
                    { 14, 3, new DateTime(2023, 2, 1, 15, 0, 22, 121, DateTimeKind.Local).AddTicks(5753), 2, "Deserunt vero quo qui atque aut quia." },
                    { 15, 3, new DateTime(2023, 2, 1, 6, 12, 33, 812, DateTimeKind.Local).AddTicks(9948), 1, "Adipisci corporis sit repudiandae eum facilis quia sunt.\nFacilis magni optio et." },
                    { 16, 3, new DateTime(2023, 2, 1, 11, 58, 55, 646, DateTimeKind.Local).AddTicks(154), 1, "Corporis est illo eveniet soluta sint qui accusamus fugiat unde.\nQuisquam quos quod." },
                    { 17, 3, new DateTime(2023, 2, 1, 16, 49, 1, 465, DateTimeKind.Local).AddTicks(9693), 1, "Omnis amet esse sunt excepturi assumenda.\nDebitis debitis laudantium neque aut.\nAmet optio incidunt sed similique ad omnis sint temporibus.\nIpsa repellat aspernatur inventore consequatur cum ut et." },
                    { 18, 3, new DateTime(2023, 2, 1, 3, 23, 55, 253, DateTimeKind.Local).AddTicks(7432), 1, "Sunt natus minus numquam quis perspiciatis et.\nSed impedit vero eligendi molestiae accusantium voluptatem ut.\nAsperiores a tenetur." },
                    { 19, 4, new DateTime(2023, 2, 1, 7, 31, 44, 991, DateTimeKind.Local).AddTicks(5186), 1, "Aut laboriosam in possimus esse maxime.\nEt pariatur nobis autem molestiae.\nLaudantium quo non natus voluptas reprehenderit vitae ut excepturi.\nMolestiae rerum exercitationem eius voluptas id." },
                    { 20, 4, new DateTime(2023, 2, 1, 19, 42, 18, 489, DateTimeKind.Local).AddTicks(946), 3, "Soluta aliquid voluptas amet ea quia." },
                    { 21, 4, new DateTime(2023, 2, 1, 23, 19, 2, 287, DateTimeKind.Local).AddTicks(1809), 3, "Asperiores molestias sint rerum et aliquam.\nDolore voluptatem voluptas nihil explicabo mollitia debitis voluptatem vel.\nNon praesentium optio.\nOfficiis eligendi voluptatum.\nAut rerum nisi." },
                    { 22, 4, new DateTime(2023, 2, 1, 18, 43, 6, 912, DateTimeKind.Local).AddTicks(778), 3, "Et doloremque totam et accusantium." },
                    { 23, 4, new DateTime(2023, 2, 1, 17, 21, 20, 774, DateTimeKind.Local).AddTicks(3048), 3, "Similique temporibus voluptatem maxime qui facere necessitatibus aperiam deserunt inventore.\nConsequatur eius ducimus quia illum odio officiis magni nemo.\nSunt ex possimus ducimus nam similique." },
                    { 24, 4, new DateTime(2023, 2, 1, 19, 59, 39, 474, DateTimeKind.Local).AddTicks(2436), 1, "Omnis officiis facere totam vitae et minus quos ex.\nNemo similique est.\nNecessitatibus non culpa ut odit.\nVoluptatum voluptas ad et deleniti iusto quas." },
                    { 25, 4, new DateTime(2023, 2, 1, 3, 35, 11, 613, DateTimeKind.Local).AddTicks(743), 3, "Aut aut nostrum tempora dolores laudantium." },
                    { 26, 4, new DateTime(2023, 2, 1, 12, 48, 24, 518, DateTimeKind.Local).AddTicks(4325), 1, "Eum est magnam eos cupiditate maxime blanditiis iste.\nMaiores inventore quia velit nostrum impedit." },
                    { 27, 5, new DateTime(2023, 2, 1, 18, 26, 48, 405, DateTimeKind.Local).AddTicks(5165), 2, "Sunt et omnis voluptatem.\nQui placeat animi.\nQuisquam debitis explicabo quasi accusantium." },
                    { 28, 5, new DateTime(2023, 2, 1, 19, 25, 44, 552, DateTimeKind.Local).AddTicks(1507), 3, "Id laudantium velit.\nNobis est repellat sint eveniet non.\nQui praesentium enim consequatur id soluta quidem omnis molestiae vel.\nNihil iure facere ea." },
                    { 29, 5, new DateTime(2023, 2, 1, 8, 54, 29, 421, DateTimeKind.Local).AddTicks(7971), 1, "Saepe doloremque a debitis optio aut aut.\nIllum voluptatem voluptatem iste.\nSed est repudiandae voluptatem id quis.\nNisi est adipisci voluptatem libero in." },
                    { 30, 5, new DateTime(2023, 2, 1, 18, 41, 0, 698, DateTimeKind.Local).AddTicks(6194), 3, "Nostrum et debitis voluptas voluptatem.\nIusto culpa sunt cumque et provident qui laborum aut qui.\nDolorem omnis quo eos quo repudiandae quia tempora.\nFugiat eligendi quia quia." },
                    { 31, 5, new DateTime(2023, 2, 1, 9, 15, 27, 828, DateTimeKind.Local).AddTicks(1579), 1, "Eos sint soluta dolorem eius facilis voluptatum.\nAperiam qui quo vel ut culpa sequi nulla.\nOfficia aperiam fugiat qui in necessitatibus cumque aut ratione consequuntur." },
                    { 32, 5, new DateTime(2023, 2, 1, 14, 7, 5, 400, DateTimeKind.Local).AddTicks(4976), 2, "Totam inventore quis facere deserunt.\nEt hic magni commodi.\nSoluta voluptas laboriosam esse ut magnam." },
                    { 33, 5, new DateTime(2023, 2, 1, 10, 10, 31, 317, DateTimeKind.Local).AddTicks(9230), 2, "Consequuntur rerum reprehenderit veniam fuga voluptatibus et quasi occaecati.\nNemo qui ut quis facere et eum natus." },
                    { 34, 5, new DateTime(2023, 2, 1, 11, 25, 57, 624, DateTimeKind.Local).AddTicks(9115), 2, "Rem nobis saepe error commodi nobis aut officiis sed aut.\nOfficia laboriosam esse saepe.\nDelectus nesciunt iusto debitis laborum harum.\nAspernatur sunt delectus distinctio." },
                    { 35, 5, new DateTime(2023, 2, 1, 17, 0, 44, 810, DateTimeKind.Local).AddTicks(58), 2, "Vel sed modi ipsum impedit reprehenderit veritatis dolorum.\nConsectetur facilis non exercitationem aliquid est.\nLaboriosam quisquam commodi.\nUnde ut voluptas nostrum quo provident quibusdam.\nQui accusantium tempora qui modi ex." },
                    { 36, 6, new DateTime(2023, 2, 1, 21, 14, 0, 433, DateTimeKind.Local).AddTicks(9629), 1, "Illo nobis ut aut vero placeat odio.\nQuia recusandae inventore iure aut voluptas ex non sit dolor.\nOfficia modi ex delectus consectetur nemo earum.\nSit sint explicabo provident quis eligendi consequatur repudiandae beatae quia.\nTempore ab aperiam laudantium nihil exercitationem qui fugiat." },
                    { 37, 6, new DateTime(2023, 2, 1, 19, 29, 20, 907, DateTimeKind.Local).AddTicks(4962), 2, "Repudiandae aut atque ipsam." },
                    { 38, 7, new DateTime(2023, 2, 1, 16, 27, 8, 87, DateTimeKind.Local).AddTicks(2671), 3, "Quia quaerat labore est aut quis doloremque voluptas.\nDebitis repellat fuga ipsa et sequi omnis sed." },
                    { 39, 7, new DateTime(2023, 2, 1, 3, 38, 52, 363, DateTimeKind.Local).AddTicks(9157), 2, "Dolorum iste beatae.\nAut magni molestias veniam voluptatum quo alias fuga quos." },
                    { 40, 7, new DateTime(2023, 2, 1, 13, 50, 17, 678, DateTimeKind.Local).AddTicks(1440), 2, "Ea voluptatem deserunt.\nVelit sit unde culpa aspernatur quas laborum delectus.\nEum autem ipsa id officia nihil.\nDebitis assumenda nesciunt occaecati.\nSequi eaque repellat alias unde ut." },
                    { 41, 7, new DateTime(2023, 2, 1, 22, 4, 59, 528, DateTimeKind.Local).AddTicks(8326), 3, "Quia eligendi corporis." },
                    { 42, 7, new DateTime(2023, 2, 1, 13, 51, 18, 242, DateTimeKind.Local).AddTicks(3034), 1, "Aut fuga eveniet voluptatem.\nQui fuga culpa.\nReprehenderit eveniet cumque quia harum odit quasi et aliquam nostrum." },
                    { 43, 7, new DateTime(2023, 2, 1, 11, 10, 56, 401, DateTimeKind.Local).AddTicks(6807), 2, "Inventore enim sit nisi.\nUt ullam autem voluptatum harum.\nOmnis provident fuga neque architecto qui quis quam." },
                    { 44, 7, new DateTime(2023, 2, 1, 23, 22, 16, 4, DateTimeKind.Local).AddTicks(5047), 3, "Necessitatibus ea perferendis fuga veritatis tenetur recusandae reiciendis laborum praesentium.\nVoluptas quae placeat aut quis incidunt.\nPerferendis quam et atque officiis in ducimus.\nSit nihil sit." },
                    { 45, 7, new DateTime(2023, 2, 2, 0, 19, 49, 399, DateTimeKind.Local).AddTicks(2223), 3, "Minima odio itaque labore est labore.\nPerspiciatis expedita beatae ullam qui repellendus." },
                    { 46, 8, new DateTime(2023, 2, 1, 21, 35, 44, 284, DateTimeKind.Local).AddTicks(212), 1, "Non ea provident odio.\nReiciendis est incidunt autem.\nSunt accusantium iusto voluptas enim ipsum.\nQuas ut officia debitis.\nVoluptate sunt et nam delectus vero." },
                    { 47, 8, new DateTime(2023, 2, 1, 20, 41, 20, 350, DateTimeKind.Local).AddTicks(5441), 1, "Et ipsum aliquid aperiam voluptate quibusdam unde quaerat et.\nEos dolorum qui sed ut.\nPerferendis corporis eos nobis minus.\nEx occaecati asperiores a aut.\nAut sint alias laborum quos voluptas cupiditate." },
                    { 48, 9, new DateTime(2023, 2, 1, 20, 18, 14, 95, DateTimeKind.Local).AddTicks(293), 3, "Error unde temporibus nulla enim ipsam et voluptas molestiae voluptatem." },
                    { 49, 9, new DateTime(2023, 2, 1, 9, 23, 26, 499, DateTimeKind.Local).AddTicks(3473), 1, "Fugiat eaque qui temporibus eaque dolore id enim magnam.\nDelectus deserunt beatae recusandae." },
                    { 50, 9, new DateTime(2023, 2, 1, 22, 13, 54, 713, DateTimeKind.Local).AddTicks(1681), 2, "Est suscipit temporibus aut quia aut optio adipisci.\nArchitecto architecto nostrum quia nobis ullam.\nQui labore ipsam unde sint quo." },
                    { 51, 9, new DateTime(2023, 2, 1, 6, 54, 25, 515, DateTimeKind.Local).AddTicks(7890), 1, "Aut quisquam labore nobis aut iure autem iste.\nSaepe accusantium eos fugiat laboriosam sunt." },
                    { 52, 10, new DateTime(2023, 2, 2, 2, 25, 46, 961, DateTimeKind.Local).AddTicks(5140), 3, "In ut at quod omnis doloremque voluptas.\nMagnam in ab." },
                    { 53, 10, new DateTime(2023, 2, 1, 12, 39, 45, 158, DateTimeKind.Local).AddTicks(5894), 1, "Delectus magnam quae rerum quasi eaque.\nLaborum expedita et vero dolore consectetur omnis quod." },
                    { 54, 10, new DateTime(2023, 2, 2, 0, 57, 15, 71, DateTimeKind.Local).AddTicks(481), 3, "Delectus repudiandae sunt quibusdam eum.\nDolores sit neque." },
                    { 55, 10, new DateTime(2023, 2, 1, 23, 2, 16, 296, DateTimeKind.Local).AddTicks(4069), 2, "Quae at perferendis dolores fugiat.\nMagni error id dolorum velit labore sint dolor dolores cupiditate.\nQuibusdam amet autem est quis in qui.\nEius eos itaque impedit et cupiditate." },
                    { 56, 10, new DateTime(2023, 2, 1, 19, 37, 34, 493, DateTimeKind.Local).AddTicks(5507), 3, "Laboriosam sed id voluptas.\nOdit facere incidunt nostrum autem iste voluptates corporis repellat aut.\nExercitationem ullam sapiente cupiditate cum minima dolorum nobis.\nConsequuntur adipisci vero ut aspernatur doloremque dolores." },
                    { 57, 10, new DateTime(2023, 2, 1, 20, 27, 22, 210, DateTimeKind.Local).AddTicks(3319), 2, "Et doloremque enim nobis aut qui veniam voluptatem saepe nemo.\nItaque et pariatur incidunt accusamus dolor vitae.\nInventore sint et voluptatem facere voluptates eveniet.\nAdipisci nisi veritatis animi est velit illum placeat voluptatem maiores." },
                    { 58, 10, new DateTime(2023, 2, 2, 1, 0, 13, 169, DateTimeKind.Local).AddTicks(6745), 2, "Mollitia temporibus enim similique quaerat hic iure accusamus nesciunt quo.\nIllo id quasi voluptatibus.\nNatus omnis beatae ratione sunt cum fugiat impedit fugiat id." },
                    { 59, 10, new DateTime(2023, 2, 1, 15, 21, 43, 526, DateTimeKind.Local).AddTicks(6816), 1, "Quas provident doloribus veritatis voluptatem magni quo amet et rerum.\nQuia amet ut quis libero praesentium placeat.\nEum molestiae et voluptatum reprehenderit et et a id.\nOccaecati et quis ut ad non optio veritatis.\nPlaceat at ipsa autem consequuntur magni sed voluptas." },
                    { 60, 11, new DateTime(2023, 2, 1, 17, 0, 40, 864, DateTimeKind.Local).AddTicks(8448), 2, "Blanditiis alias inventore animi nesciunt qui quia.\nQui magni vitae quia." },
                    { 61, 11, new DateTime(2023, 2, 1, 6, 36, 27, 389, DateTimeKind.Local).AddTicks(6875), 3, "Est repellendus repellat repudiandae nisi illo autem nisi." },
                    { 62, 11, new DateTime(2023, 2, 1, 18, 44, 57, 378, DateTimeKind.Local).AddTicks(6622), 1, "Voluptatem similique et cupiditate tenetur quia.\nQuia rerum laudantium sint aliquid cum aut et asperiores.\nNumquam nisi in." },
                    { 63, 12, new DateTime(2023, 2, 2, 1, 33, 3, 601, DateTimeKind.Local).AddTicks(8027), 2, "Laborum dicta aperiam nihil vel delectus.\nEt corporis id perspiciatis non.\nRerum vel numquam.\nMollitia quaerat ipsa repudiandae dolorem a rem." },
                    { 64, 12, new DateTime(2023, 2, 1, 22, 29, 2, 394, DateTimeKind.Local).AddTicks(3050), 3, "Hic occaecati ex nesciunt incidunt ut nam molestias.\nVeritatis aliquam sunt nam maxime sint rerum molestiae suscipit." },
                    { 65, 12, new DateTime(2023, 2, 1, 11, 48, 44, 568, DateTimeKind.Local).AddTicks(4867), 1, "Enim quisquam ipsam animi cupiditate dignissimos.\nNatus ea dolorum qui.\nSint repellendus dolore iure ullam beatae modi accusamus.\nBlanditiis nisi est vel ipsum.\nQuasi ipsa qui error amet placeat corrupti dolore." },
                    { 66, 13, new DateTime(2023, 2, 1, 21, 6, 3, 805, DateTimeKind.Local).AddTicks(9144), 3, "Iusto similique est quidem.\nEx modi accusantium ad id dolores repellat beatae.\nDolores sit nihil totam." },
                    { 67, 13, new DateTime(2023, 2, 1, 5, 55, 2, 701, DateTimeKind.Local).AddTicks(1768), 2, "Eligendi qui quis recusandae et nihil.\nUt molestiae consequatur nulla aliquid et." },
                    { 68, 13, new DateTime(2023, 2, 1, 23, 25, 17, 433, DateTimeKind.Local).AddTicks(2910), 2, "Expedita eum laborum eum commodi quaerat est.\nQuisquam perspiciatis odio deserunt alias placeat alias voluptas.\nDebitis accusantium voluptatem temporibus aut et ut ipsa vel nobis." },
                    { 69, 13, new DateTime(2023, 2, 1, 11, 42, 36, 189, DateTimeKind.Local).AddTicks(8682), 3, "Similique molestiae delectus deserunt voluptatem.\nEt voluptas quia est voluptatem cupiditate aut ab." },
                    { 70, 13, new DateTime(2023, 2, 1, 18, 52, 31, 831, DateTimeKind.Local).AddTicks(7551), 3, "Excepturi illum consequatur molestiae ut quo unde qui architecto." },
                    { 71, 14, new DateTime(2023, 2, 1, 21, 57, 16, 941, DateTimeKind.Local).AddTicks(4758), 2, "Libero eaque nesciunt pariatur quia et unde cumque et.\nOfficia et quos in saepe fuga enim." },
                    { 72, 14, new DateTime(2023, 2, 1, 3, 43, 22, 643, DateTimeKind.Local).AddTicks(5030), 2, "Eligendi aliquam ipsa similique.\nQuisquam omnis placeat beatae quia amet officia quia." },
                    { 73, 14, new DateTime(2023, 2, 2, 1, 28, 30, 575, DateTimeKind.Local).AddTicks(7221), 3, "Reprehenderit eveniet praesentium est dolorum amet sapiente nam qui earum.\nHic quaerat qui voluptas ab minus aut dolor.\nVeniam deleniti velit.\nTenetur sed sed in sit ipsam molestiae consequatur quisquam.\nDolorem tempore repellendus esse architecto." },
                    { 74, 14, new DateTime(2023, 2, 1, 11, 33, 50, 743, DateTimeKind.Local).AddTicks(1070), 1, "Dolor quia quibusdam.\nMollitia nihil sed dignissimos repellat aut temporibus impedit repudiandae.\nEligendi assumenda vitae voluptatibus natus sit enim sint.\nIncidunt itaque ut sunt ut ipsam ut quo.\nAutem quam quam." },
                    { 75, 14, new DateTime(2023, 2, 1, 17, 26, 59, 654, DateTimeKind.Local).AddTicks(2722), 1, "Reiciendis quibusdam accusamus molestiae et non laborum.\nReiciendis sunt facilis doloribus dicta occaecati in temporibus voluptatem rem.\nAut eligendi sit enim consequuntur explicabo iure.\nSit quos ad quae et consequatur quis culpa provident." },
                    { 76, 14, new DateTime(2023, 2, 1, 4, 33, 3, 848, DateTimeKind.Local).AddTicks(9636), 1, "Voluptas doloribus fugit quia tempore.\nEt molestias et harum nesciunt quia officia fugiat sint est.\nQuod sit occaecati dolorem minima quam cumque.\nDoloremque fuga quo." },
                    { 77, 14, new DateTime(2023, 2, 1, 21, 5, 12, 846, DateTimeKind.Local).AddTicks(8484), 1, "Qui ut iste cumque.\nExplicabo blanditiis sit possimus." },
                    { 78, 14, new DateTime(2023, 2, 1, 8, 52, 22, 801, DateTimeKind.Local).AddTicks(866), 2, "Accusamus doloremque provident.\nRecusandae consequatur distinctio possimus tempora dolores.\nSunt velit magni.\nNostrum repudiandae similique omnis dolore voluptatibus ducimus voluptatem.\nEius molestiae et veniam voluptatem." },
                    { 79, 14, new DateTime(2023, 2, 1, 4, 18, 29, 469, DateTimeKind.Local).AddTicks(2685), 3, "Culpa dolor repellat sunt voluptatem consequatur aperiam.\nQuam quas magni excepturi consequuntur aut delectus vel.\nNulla soluta assumenda et eos quam impedit aliquam ut molestias.\nAutem id laudantium numquam nostrum sit eum." },
                    { 80, 15, new DateTime(2023, 2, 1, 21, 49, 39, 629, DateTimeKind.Local).AddTicks(4980), 3, "Rerum consectetur voluptas sunt dolorum laudantium rem.\nRepudiandae ut voluptatibus earum dignissimos.\nNostrum fugiat accusantium dolores blanditiis ut vel eaque sint." },
                    { 81, 15, new DateTime(2023, 2, 1, 20, 39, 32, 301, DateTimeKind.Local).AddTicks(4128), 1, "Dolorem optio adipisci.\nIpsa explicabo sunt.\nOccaecati quos qui rerum aut et.\nOmnis reiciendis enim architecto iure.\nEx commodi et et." },
                    { 82, 15, new DateTime(2023, 2, 1, 13, 34, 35, 895, DateTimeKind.Local).AddTicks(6353), 1, "Enim perspiciatis voluptatibus est ducimus corporis error quisquam sed itaque.\nOfficiis quis assumenda nisi aut laborum ut dignissimos totam.\nItaque voluptates aperiam officia dolorem vel.\nError ab est sint illum." },
                    { 83, 15, new DateTime(2023, 2, 2, 1, 15, 54, 76, DateTimeKind.Local).AddTicks(6920), 1, "Labore nam animi dolor.\nEos quis tempora excepturi et qui voluptatem maxime blanditiis.\nMinus quis nihil suscipit harum hic inventore dolorum quos incidunt.\nQuasi dolorem non illo.\nCupiditate reprehenderit quisquam autem soluta voluptas nobis expedita." },
                    { 84, 15, new DateTime(2023, 2, 1, 15, 38, 23, 634, DateTimeKind.Local).AddTicks(4256), 2, "Et incidunt enim.\nDeserunt pariatur amet provident qui voluptates ipsam non sit.\nAut omnis tempore.\nQuia exercitationem praesentium sit inventore et accusantium vitae et.\nId voluptas quaerat explicabo qui voluptatibus cumque quaerat sint suscipit." },
                    { 85, 15, new DateTime(2023, 2, 1, 5, 44, 12, 109, DateTimeKind.Local).AddTicks(5945), 1, "Culpa laborum architecto molestias adipisci quidem minus.\nVoluptatibus quis suscipit molestias.\nQuod ipsum nobis quibusdam excepturi est exercitationem.\nAutem et modi quasi velit nisi pariatur harum laboriosam enim." },
                    { 86, 16, new DateTime(2023, 2, 1, 12, 30, 14, 764, DateTimeKind.Local).AddTicks(3526), 2, "Mollitia magnam magnam consequatur.\nId consequatur corporis et omnis.\nQuia aut aperiam.\nConsequuntur asperiores exercitationem quisquam." },
                    { 87, 17, new DateTime(2023, 2, 1, 9, 5, 38, 664, DateTimeKind.Local).AddTicks(5048), 3, "Dolorum deleniti reprehenderit voluptatum laboriosam.\nLaborum est ab dolorem qui veritatis voluptate.\nAsperiores minus veniam." },
                    { 88, 17, new DateTime(2023, 2, 1, 9, 59, 11, 438, DateTimeKind.Local).AddTicks(1915), 1, "Perspiciatis recusandae dolorum." },
                    { 89, 17, new DateTime(2023, 2, 1, 22, 10, 12, 807, DateTimeKind.Local).AddTicks(3935), 3, "Ad ipsum ipsam." },
                    { 90, 17, new DateTime(2023, 2, 2, 1, 15, 28, 623, DateTimeKind.Local).AddTicks(3166), 3, "Dolorem labore ullam minus.\nEa molestiae beatae corporis voluptatem incidunt enim.\nNesciunt officia et sit sunt esse neque." },
                    { 91, 17, new DateTime(2023, 2, 1, 8, 56, 29, 783, DateTimeKind.Local).AddTicks(245), 2, "Laborum sint id sit aut molestias cupiditate ut non.\nIpsum dolores voluptatibus sit nam qui libero laudantium et ex.\nEsse et pariatur nobis quis magni.\nEsse ipsam aut minima totam sed sed ab." },
                    { 92, 17, new DateTime(2023, 2, 1, 10, 40, 29, 157, DateTimeKind.Local).AddTicks(3998), 1, "Quod asperiores eum distinctio doloribus explicabo illum dolorem voluptates." },
                    { 93, 17, new DateTime(2023, 2, 2, 1, 45, 20, 498, DateTimeKind.Local).AddTicks(1230), 2, "Velit minima velit perferendis facere facilis molestias vel saepe illum.\nAssumenda necessitatibus accusantium dignissimos eveniet laborum aut.\nUt fugiat et corrupti aperiam voluptas eos.\nOmnis delectus quisquam qui dolorem et commodi." },
                    { 94, 17, new DateTime(2023, 2, 1, 23, 0, 4, 820, DateTimeKind.Local).AddTicks(5933), 1, "Consequatur ducimus est.\nPariatur dolor assumenda saepe aspernatur quasi.\nUt ullam impedit repudiandae nisi.\nQuibusdam temporibus dolorem.\nNecessitatibus illo tenetur esse." },
                    { 95, 17, new DateTime(2023, 2, 2, 0, 41, 6, 733, DateTimeKind.Local).AddTicks(2932), 1, "Non ut amet reiciendis in.\nConsequuntur culpa quam assumenda enim voluptatem rerum voluptas cupiditate sit.\nNihil sit voluptates sequi minima quaerat totam possimus.\nFugit qui minus alias cum sunt reiciendis dolorum similique." },
                    { 96, 18, new DateTime(2023, 2, 1, 3, 28, 45, 512, DateTimeKind.Local).AddTicks(3988), 3, "Doloremque deleniti ut tempora consequuntur non est porro.\nQuasi aut sed dolore impedit porro eius quo.\nMinus nulla esse sunt modi quis voluptas adipisci nihil.\nVoluptate nihil minima quia iure et tempora doloribus vero quidem." },
                    { 97, 18, new DateTime(2023, 2, 1, 23, 15, 25, 468, DateTimeKind.Local).AddTicks(8834), 3, "Non voluptatem explicabo quas voluptatem.\nTotam quasi consequatur aut illo sint.\nEarum aliquam laborum ut.\nOdit est nemo ipsa temporibus omnis qui et deleniti qui.\nBeatae officiis et rerum magni." },
                    { 98, 18, new DateTime(2023, 2, 1, 20, 10, 58, 151, DateTimeKind.Local).AddTicks(9262), 1, "Officiis doloremque provident suscipit optio qui et rem quis." },
                    { 99, 18, new DateTime(2023, 2, 1, 8, 23, 49, 858, DateTimeKind.Local).AddTicks(9331), 3, "Ab omnis amet reiciendis rerum incidunt sit omnis.\nVoluptates id quo molestiae aut consectetur doloremque fugit." },
                    { 100, 18, new DateTime(2023, 2, 1, 3, 46, 25, 100, DateTimeKind.Local).AddTicks(5758), 1, "Inventore architecto et.\nNisi qui optio aliquam quaerat adipisci asperiores fugit nisi qui.\nCumque voluptatem ad." },
                    { 101, 18, new DateTime(2023, 2, 1, 17, 52, 6, 156, DateTimeKind.Local).AddTicks(987), 3, "Quia autem fuga assumenda." },
                    { 102, 18, new DateTime(2023, 2, 1, 13, 50, 0, 933, DateTimeKind.Local).AddTicks(5390), 3, "Molestias soluta eum expedita doloribus.\nRerum aut ut quo quidem occaecati et porro.\nAnimi qui amet dicta voluptas delectus quas vitae." },
                    { 103, 19, new DateTime(2023, 2, 1, 10, 55, 9, 366, DateTimeKind.Local).AddTicks(4839), 1, "Rem qui eius illum nisi ad necessitatibus numquam nesciunt necessitatibus.\nRerum omnis facere et.\nModi eaque consequatur.\nUnde dolores at reprehenderit impedit aliquam possimus.\nAut fugit tempora eos deserunt minima cum sunt ut voluptate." },
                    { 104, 19, new DateTime(2023, 2, 2, 0, 36, 4, 324, DateTimeKind.Local).AddTicks(8225), 3, "Pariatur nihil non quo quaerat quia molestiae ea soluta et.\nEnim consequatur aut nostrum dolorem.\nSunt sint non." },
                    { 105, 19, new DateTime(2023, 2, 1, 8, 49, 7, 453, DateTimeKind.Local).AddTicks(652), 1, "Ab et architecto.\nEius vel commodi ut eaque qui est et et.\nAsperiores harum aperiam facere et animi rerum veniam repudiandae.\nEt beatae corporis qui magnam officia vero et." },
                    { 106, 19, new DateTime(2023, 2, 1, 6, 14, 19, 44, DateTimeKind.Local).AddTicks(4372), 2, "Ab explicabo eos accusamus ut sit enim dolor quia.\nA ut aspernatur rerum eveniet aliquid laborum veritatis sit.\nQui quis doloremque qui excepturi dolor voluptatibus qui qui.\nLibero voluptate dicta incidunt qui itaque laborum natus suscipit." },
                    { 107, 19, new DateTime(2023, 2, 1, 14, 57, 5, 620, DateTimeKind.Local).AddTicks(3688), 1, "Earum sed quasi atque consequatur est." },
                    { 108, 19, new DateTime(2023, 2, 1, 20, 3, 52, 908, DateTimeKind.Local).AddTicks(3551), 1, "Sit dolor cum et repellat.\nCorrupti aperiam illum illo voluptatum.\nOmnis ratione accusamus ullam.\nId ab est ipsam possimus qui doloribus dicta voluptatem dignissimos." },
                    { 109, 20, new DateTime(2023, 2, 1, 12, 21, 46, 889, DateTimeKind.Local).AddTicks(3616), 3, "Ab et officiis." },
                    { 110, 20, new DateTime(2023, 2, 1, 15, 38, 25, 994, DateTimeKind.Local).AddTicks(6434), 1, "Adipisci vitae ut facere similique et et et minus.\nEos aut sapiente quaerat qui est reiciendis reiciendis sint.\nEsse illo fugiat illum.\nQuam architecto illum qui.\nConsequuntur pariatur debitis." },
                    { 111, 20, new DateTime(2023, 2, 1, 21, 49, 41, 145, DateTimeKind.Local).AddTicks(2120), 2, "Suscipit qui occaecati.\nUnde doloremque qui occaecati doloribus ipsum consequatur quia." },
                    { 112, 20, new DateTime(2023, 2, 1, 19, 56, 30, 344, DateTimeKind.Local).AddTicks(9199), 3, "Expedita quam qui dolore dicta.\nRatione nulla et tempore et facilis nostrum.\nAtque optio ea.\nFacilis cupiditate qui sint et voluptatem vel." },
                    { 113, 20, new DateTime(2023, 2, 1, 7, 44, 41, 501, DateTimeKind.Local).AddTicks(6364), 1, "Dolores quia amet corrupti natus.\nInventore nihil quia alias." },
                    { 114, 20, new DateTime(2023, 2, 1, 12, 45, 59, 54, DateTimeKind.Local).AddTicks(5809), 1, "Debitis vel consequatur incidunt saepe est fugit sapiente dolorum magnam.\nNecessitatibus eos omnis.\nAccusamus repellendus exercitationem.\nCulpa corporis et laudantium sequi qui debitis nihil ad labore." },
                    { 115, 21, new DateTime(2023, 2, 2, 2, 33, 51, 841, DateTimeKind.Local).AddTicks(2450), 3, "Quasi laboriosam iste sequi provident omnis recusandae.\nTempore vitae quas corporis magnam numquam.\nEa explicabo sunt autem repudiandae expedita et.\nUt quo est." },
                    { 116, 21, new DateTime(2023, 2, 1, 13, 48, 48, 208, DateTimeKind.Local).AddTicks(5539), 2, "Et natus voluptatum corporis.\nA nisi molestiae est rerum provident omnis inventore.\nSint ut maiores vel voluptas illum harum quasi et.\nRepudiandae similique quia nostrum ipsam aut provident occaecati.\nMolestias culpa earum eum hic et." },
                    { 117, 21, new DateTime(2023, 2, 1, 3, 56, 12, 233, DateTimeKind.Local).AddTicks(712), 1, "Et eum debitis dignissimos eius ut accusamus quod rerum.\nQuasi provident et.\nMaxime iure voluptatem quidem ab aut ut esse perferendis quis.\nNumquam reiciendis qui eaque aut est possimus." },
                    { 118, 21, new DateTime(2023, 2, 2, 1, 31, 45, 154, DateTimeKind.Local).AddTicks(6767), 1, "Aperiam quia aut rerum ducimus." },
                    { 119, 21, new DateTime(2023, 2, 2, 2, 30, 1, 776, DateTimeKind.Local).AddTicks(364), 3, "Aut voluptatem repellat vitae natus ut.\nPerferendis iste eum perferendis consequatur deserunt saepe consequatur consequatur qui.\nPossimus ipsam ipsam similique nesciunt omnis in ex." },
                    { 120, 21, new DateTime(2023, 2, 1, 15, 41, 20, 857, DateTimeKind.Local).AddTicks(2586), 2, "Ut cupiditate qui accusamus sunt veritatis reiciendis inventore." },
                    { 121, 22, new DateTime(2023, 2, 1, 18, 56, 19, 812, DateTimeKind.Local).AddTicks(7837), 3, "Minus eaque aspernatur.\nDistinctio illo inventore voluptatibus laborum corrupti nihil labore.\nUnde amet reiciendis.\nTotam corporis beatae vitae voluptas." },
                    { 122, 22, new DateTime(2023, 2, 1, 12, 54, 23, 482, DateTimeKind.Local).AddTicks(4513), 2, "Autem eos tempora." },
                    { 123, 22, new DateTime(2023, 2, 1, 10, 21, 26, 372, DateTimeKind.Local).AddTicks(8778), 1, "Id consequatur quasi aut eaque.\nIure quas qui aut qui veritatis sint eius asperiores.\nSed error consectetur voluptatum provident voluptatibus ea." },
                    { 124, 22, new DateTime(2023, 2, 2, 2, 24, 50, 817, DateTimeKind.Local).AddTicks(7015), 3, "Quaerat sint possimus sit voluptas et recusandae voluptas.\nFugit explicabo exercitationem animi.\nSunt earum ex rerum commodi laborum dolor et sunt accusantium." },
                    { 125, 22, new DateTime(2023, 2, 1, 3, 22, 56, 98, DateTimeKind.Local).AddTicks(6835), 3, "Possimus delectus autem non occaecati quia magni officia eum.\nQuasi qui culpa saepe vel qui odit ut officia error.\nIpsa quae facere enim ut debitis blanditiis ut minus doloribus.\nAliquam nesciunt similique numquam quod.\nEst qui repellendus maiores iste ea officiis ut aperiam necessitatibus." },
                    { 126, 22, new DateTime(2023, 2, 1, 23, 20, 28, 930, DateTimeKind.Local).AddTicks(5693), 1, "Eum nihil illum porro sint dolorum eveniet et voluptas.\nLabore et delectus porro error quam quia mollitia.\nModi dolores adipisci omnis aut corrupti facilis debitis.\nAccusamus doloribus totam tempora vel incidunt ut fugiat nisi.\nUllam sed maiores sequi quasi fugit maxime ut odio." },
                    { 127, 23, new DateTime(2023, 2, 1, 20, 56, 18, 697, DateTimeKind.Local).AddTicks(3041), 2, "Consectetur est nulla tempora enim.\nMagni placeat suscipit sed perferendis voluptas minus placeat.\nArchitecto totam ullam deserunt ut laboriosam consequuntur nam.\nQui quia quisquam temporibus." },
                    { 128, 23, new DateTime(2023, 2, 1, 17, 20, 1, 800, DateTimeKind.Local).AddTicks(3206), 2, "Fugit delectus omnis sit et fuga accusantium autem vero." },
                    { 129, 23, new DateTime(2023, 2, 1, 9, 2, 29, 492, DateTimeKind.Local).AddTicks(6424), 3, "Veritatis nihil voluptate dolore sed aspernatur sunt vel.\nMolestiae et maiores et facilis et.\nLaboriosam quos repudiandae.\nAdipisci est assumenda aut.\nIn voluptas ad eius vel recusandae qui." },
                    { 130, 23, new DateTime(2023, 2, 1, 10, 17, 53, 911, DateTimeKind.Local).AddTicks(8481), 2, "Ipsam perspiciatis quisquam quia maiores consequatur expedita.\nQuo velit aut.\nSapiente aliquid sint sint illum repellendus ut suscipit recusandae iusto." },
                    { 131, 24, new DateTime(2023, 2, 2, 1, 31, 24, 429, DateTimeKind.Local).AddTicks(1300), 1, "Incidunt quia sed natus impedit quibusdam assumenda officia.\nAmet quasi qui voluptatem.\nEligendi vero enim et eos.\nIn delectus tenetur.\nSimilique aut voluptas omnis." },
                    { 132, 24, new DateTime(2023, 2, 2, 0, 49, 3, 285, DateTimeKind.Local).AddTicks(72), 1, "Ab eaque ut possimus eos in facilis.\nRatione tempora facilis aliquid ut quia quia ex.\nIn molestias qui modi aut." },
                    { 133, 24, new DateTime(2023, 2, 1, 18, 2, 32, 879, DateTimeKind.Local).AddTicks(5007), 1, "Asperiores eum tenetur aut cupiditate aut est dolores cum modi." },
                    { 134, 24, new DateTime(2023, 2, 2, 0, 14, 0, 799, DateTimeKind.Local).AddTicks(2745), 3, "Eius eos officiis ut quia animi et ea impedit corrupti.\nNam distinctio nobis aliquid beatae rerum.\nOfficia non voluptate illum assumenda dolores nihil tempore.\nEst provident hic reiciendis sit ea deserunt.\nDicta aut maxime earum error perferendis harum." },
                    { 135, 24, new DateTime(2023, 2, 1, 8, 46, 51, 328, DateTimeKind.Local).AddTicks(5209), 2, "Enim dicta ratione animi minima tempore ut et molestias.\nConsequatur id facilis est voluptatem voluptatem.\nPossimus excepturi neque voluptatem quasi dolor ut aut velit." },
                    { 136, 24, new DateTime(2023, 2, 1, 20, 12, 0, 250, DateTimeKind.Local).AddTicks(585), 1, "Optio nemo et pariatur commodi quos fuga non tempore.\nVoluptatibus suscipit dicta odit porro.\nAut nostrum perspiciatis eos et.\nHic aliquid deserunt et voluptates.\nFuga beatae voluptates quia ratione minus nihil inventore quia quibusdam." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("02d2177d-6e46-0306-06d7-8e3065753445") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("02fef29f-b5bf-f009-8887-280899f88b67") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("55f416d2-6097-35b3-8ab5-078b8ca7c988") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("6baf6055-d491-d658-2560-7778763900cf") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("7fef9ddd-9900-82d4-7a1e-c93ddc233c4f") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("8439b313-3a31-7d6b-93f7-034ef2abf67c") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("a3a60e61-7c65-937c-651e-a50739ec0bf1") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("c9952c43-7999-5b85-7360-15ef416336de") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("f584b332-a830-2155-f34e-bc54009ca3ed") });

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumns: new[] { "AdvertId", "Id", "UserId" },
                keyValues: new object[] { 5, 1, new Guid("f584b332-a830-2155-f34e-bc54009ca3ed") });

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumns: new[] { "AdvertId", "Id", "UserId" },
                keyValues: new object[] { 5, 2, new Guid("f584b332-a830-2155-f34e-bc54009ca3ed") });

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumns: new[] { "AdvertId", "Id", "UserId" },
                keyValues: new object[] { 5, 3, new Guid("f584b332-a830-2155-f34e-bc54009ca3ed") });

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumns: new[] { "AdvertId", "Id", "UserId" },
                keyValues: new object[] { 1, 4, new Guid("55f416d2-6097-35b3-8ab5-078b8ca7c988") });

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumns: new[] { "AdvertId", "Id", "UserId" },
                keyValues: new object[] { 2, 5, new Guid("55f416d2-6097-35b3-8ab5-078b8ca7c988") });

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumns: new[] { "AdvertId", "Id", "UserId" },
                keyValues: new object[] { 3, 6, new Guid("55f416d2-6097-35b3-8ab5-078b8ca7c988") });

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumns: new[] { "AdvertId", "Id", "UserId" },
                keyValues: new object[] { 2, 7, new Guid("02fef29f-b5bf-f009-8887-280899f88b67") });

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumns: new[] { "AdvertId", "Id", "UserId" },
                keyValues: new object[] { 3, 8, new Guid("02fef29f-b5bf-f009-8887-280899f88b67") });

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumns: new[] { "AdvertId", "Id", "UserId" },
                keyValues: new object[] { 6, 9, new Guid("02fef29f-b5bf-f009-8887-280899f88b67") });

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumns: new[] { "AdvertId", "Id", "UserId" },
                keyValues: new object[] { 4, 10, new Guid("6baf6055-d491-d658-2560-7778763900cf") });

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumns: new[] { "AdvertId", "Id", "UserId" },
                keyValues: new object[] { 6, 11, new Guid("6baf6055-d491-d658-2560-7778763900cf") });

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumns: new[] { "AdvertId", "Id", "UserId" },
                keyValues: new object[] { 10, 12, new Guid("7fef9ddd-9900-82d4-7a1e-c93ddc233c4f") });

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumns: new[] { "AdvertId", "Id", "UserId" },
                keyValues: new object[] { 8, 13, new Guid("c9952c43-7999-5b85-7360-15ef416336de") });

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumns: new[] { "AdvertId", "Id", "UserId" },
                keyValues: new object[] { 10, 14, new Guid("c9952c43-7999-5b85-7360-15ef416336de") });

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumns: new[] { "AdvertId", "Id", "UserId" },
                keyValues: new object[] { 8, 15, new Guid("c9952c43-7999-5b85-7360-15ef416336de") });

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumns: new[] { "AdvertId", "Id", "UserId" },
                keyValues: new object[] { 3, 16, new Guid("02d2177d-6e46-0306-06d7-8e3065753445") });

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumns: new[] { "AdvertId", "Id", "UserId" },
                keyValues: new object[] { 4, 17, new Guid("02d2177d-6e46-0306-06d7-8e3065753445") });

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumns: new[] { "AdvertId", "Id", "UserId" },
                keyValues: new object[] { 1, 18, new Guid("02d2177d-6e46-0306-06d7-8e3065753445") });

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumns: new[] { "AdvertId", "Id", "UserId" },
                keyValues: new object[] { 13, 19, new Guid("8439b313-3a31-7d6b-93f7-034ef2abf67c") });

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumns: new[] { "AdvertId", "Id", "UserId" },
                keyValues: new object[] { 17, 20, new Guid("8439b313-3a31-7d6b-93f7-034ef2abf67c") });

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumns: new[] { "AdvertId", "Id", "UserId" },
                keyValues: new object[] { 11, 21, new Guid("8439b313-3a31-7d6b-93f7-034ef2abf67c") });

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumns: new[] { "AdvertId", "Id", "UserId" },
                keyValues: new object[] { 23, 22, new Guid("a3a60e61-7c65-937c-651e-a50739ec0bf1") });

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumns: new[] { "AdvertId", "Id", "UserId" },
                keyValues: new object[] { 23, 23, new Guid("a3a60e61-7c65-937c-651e-a50739ec0bf1") });

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumns: new[] { "AdvertId", "Id", "UserId" },
                keyValues: new object[] { 13, 24, new Guid("a3a60e61-7c65-937c-651e-a50739ec0bf1") });

            migrationBuilder.DeleteData(
                table: "SenderRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SenderRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SenderRoles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("02d2177d-6e46-0306-06d7-8e3065753445"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a3a60e61-7c65-937c-651e-a50739ec0bf1"));

            migrationBuilder.DeleteData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("02fef29f-b5bf-f009-8887-280899f88b67"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("55f416d2-6097-35b3-8ab5-078b8ca7c988"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6baf6055-d491-d658-2560-7778763900cf"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7fef9ddd-9900-82d4-7a1e-c93ddc233c4f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8439b313-3a31-7d6b-93f7-034ef2abf67c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c9952c43-7999-5b85-7360-15ef416336de"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f584b332-a830-2155-f34e-bc54009ca3ed"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "HelpTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HelpTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Messages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 31, 16, 47, 50, 893, DateTimeKind.Local).AddTicks(2665),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 2, 3, 6, 23, 737, DateTimeKind.Local).AddTicks(9541));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Adverts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 31, 16, 47, 50, 891, DateTimeKind.Local).AddTicks(6217),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 2, 3, 6, 23, 733, DateTimeKind.Local).AddTicks(1837));
        }
    }
}
