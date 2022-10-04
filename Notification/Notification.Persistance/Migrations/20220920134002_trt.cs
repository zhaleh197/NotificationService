using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notification.Persistance.Migrations
{
    public partial class trt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<long>(type: "bigint", nullable: false),
                    Resiver = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateSend = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateDelivere = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotificationUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<long>(type: "bigint", nullable: false),
                    Resiver = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateSend = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateDelivere = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PackageTariff",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitlePackage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePackage = table.Column<long>(type: "bigint", nullable: false),
                    ZaridTakhfifPaciTareeffe = table.Column<double>(type: "float", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageTariff", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatternSMs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitlePattern = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextPatern = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberofVariable = table.Column<int>(type: "int", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatternSMs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PeriodSend",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodSend", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Phonebooks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phonebooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pishshomareh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pishshomare = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Operator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idOperator = table.Column<int>(type: "int", nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pishshomareh", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QEmailUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<long>(type: "bigint", nullable: false),
                    Resiver = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateSendStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Periority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QEmailUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QNotificationUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdClient = table.Column<long>(type: "bigint", nullable: false),
                    Resiver = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateSendStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Periority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QNotificationUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SarKhats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Spacial = table.Column<int>(type: "int", nullable: false),
                    SarKhatNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasePrice = table.Column<double>(type: "float", nullable: false),
                    PersianZarib = table.Column<double>(type: "float", nullable: false),
                    EnglishZarib = table.Column<double>(type: "float", nullable: false),
                    IranselZarib = table.Column<double>(type: "float", nullable: false),
                    HamrahAvalZarib = table.Column<double>(type: "float", nullable: false),
                    RaytelZarib = table.Column<double>(type: "float", nullable: false),
                    TejasriLinkZarib = table.Column<double>(type: "float", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SarKhats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpamWords",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Word = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpamWords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeSMS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Periority = table.Column<int>(type: "int", nullable: false),
                    Confirm = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeSMS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usertype",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usertype", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PublicKhotots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LengthofNumber = table.Column<int>(type: "int", nullable: false),
                    LineNumber = table.Column<long>(type: "bigint", nullable: false),
                    IdSarKhat = table.Column<int>(type: "int", nullable: false),
                    Statue = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicKhotots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicKhotots_SarKhats_IdSarKhat",
                        column: x => x.IdSarKhat,
                        principalTable: "SarKhats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpacitalKhotots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LengthofNumber = table.Column<int>(type: "int", nullable: false),
                    IdSarKhat = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpacitalKhotots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpacitalKhotots_SarKhats_IdSarKhat",
                        column: x => x.IdSarKhat,
                        principalTable: "SarKhats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<long>(type: "bigint", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdRole = table.Column<long>(type: "bigint", nullable: false),
                    CreditFinance = table.Column<long>(type: "bigint", nullable: false),
                    CridetMeaasage = table.Column<long>(type: "bigint", nullable: false),
                    IdUSerType = table.Column<int>(type: "int", nullable: false),
                    IdPackageTariff = table.Column<long>(type: "bigint", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_PackageTariff_IdPackageTariff",
                        column: x => x.IdPackageTariff,
                        principalTable: "PackageTariff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Usertype_IdUSerType",
                        column: x => x.IdUSerType,
                        principalTable: "Usertype",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<long>(type: "bigint", nullable: false),
                    TxtAnnouncement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateStartshow = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEndtshow = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Announcements_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CodeSMs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<long>(type: "bigint", nullable: false),
                    IdSarKhat = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReplyMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeSMs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CodeSMs_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentsUser",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<long>(type: "bigint", nullable: false),
                    IdDocumentType = table.Column<long>(type: "bigint", nullable: false),
                    PathofSave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Confirmcheck = table.Column<bool>(type: "bit", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentsUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentsUser_DocumentType_IdDocumentType",
                        column: x => x.IdDocumentType,
                        principalTable: "DocumentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentsUser_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupFrinds",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<long>(type: "bigint", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupFrinds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupFrinds_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KhototUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<long>(type: "bigint", nullable: false),
                    KhatNumber = table.Column<long>(type: "bigint", nullable: false),
                    IdSarKhat = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<bool>(type: "bit", nullable: false),
                    Statuse = table.Column<bool>(type: "bit", nullable: false),
                    DedlineKhat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhototUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KhototUsers_SarKhats_IdSarKhat",
                        column: x => x.IdSarKhat,
                        principalTable: "SarKhats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KhototUsers_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatternSMSUsers",
                columns: table => new
                {
                    PatternSMsId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatternSMSUsers", x => new { x.PatternSMsId, x.UserId });
                    table.ForeignKey(
                        name: "FK_PatternSMSUsers_PatternSMs_PatternSMsId",
                        column: x => x.PatternSMsId,
                        principalTable: "PatternSMs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatternSMSUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QeueofSMs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<long>(type: "bigint", nullable: false),
                    txt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    to = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeofResiver = table.Column<bool>(type: "bit", nullable: false),
                    CountSms = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    DateOfsend = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeOfsend = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateofLimitet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PeriodSendly = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTypeSMS = table.Column<long>(type: "bigint", nullable: false),
                    KhatSend = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QeueofSMs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QeueofSMs_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockSMs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<long>(type: "bigint", nullable: false),
                    TitleStockMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockSMs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockSMs_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<long>(type: "bigint", nullable: false),
                    TitleQuestion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdOperator = table.Column<long>(type: "bigint", nullable: false),
                    Statuse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<long>(type: "bigint", nullable: false),
                    TitleTransaction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<long>(type: "bigint", nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false),
                    CodeRahgiriPardakht = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewCriditUser = table.Column<long>(type: "bigint", nullable: false),
                    TimeTransaction = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupFrindsPhonebook",
                columns: table => new
                {
                    GroupFrindsId = table.Column<long>(type: "bigint", nullable: false),
                    PhonebooksId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupFrindsPhonebook", x => new { x.GroupFrindsId, x.PhonebooksId });
                    table.ForeignKey(
                        name: "FK_GroupFrindsPhonebook_GroupFrinds_GroupFrindsId",
                        column: x => x.GroupFrindsId,
                        principalTable: "GroupFrinds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupFrindsPhonebook_Phonebooks_PhonebooksId",
                        column: x => x.PhonebooksId,
                        principalTable: "Phonebooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleProject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdKhototUser = table.Column<long>(type: "bigint", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_KhototUsers_IdKhototUser",
                        column: x => x.IdKhototUser,
                        principalTable: "KhototUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SMessageS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<long>(type: "bigint", nullable: false),
                    Txt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountSms = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    IdTypeSMS = table.Column<long>(type: "bigint", nullable: false),
                    DateOfsend = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeOfsend = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateofLimitet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PeriodSendly = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KhatSend = table.Column<long>(type: "bigint", nullable: false),
                    KhototUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMessageS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SMessageS_KhototUsers_KhototUserId",
                        column: x => x.KhototUserId,
                        principalTable: "KhototUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SMessageS_TypeSMS_IdTypeSMS",
                        column: x => x.IdTypeSMS,
                        principalTable: "TypeSMS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SMessageS_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SMS_Resivers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSMS = table.Column<long>(type: "bigint", nullable: false),
                    Resiver = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeofResiver = table.Column<int>(type: "int", nullable: false),
                    DateSended = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateDelivered = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deliverd = table.Column<int>(type: "int", nullable: false),
                    SendStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMS_Resivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SMS_Resivers_SMessageS_IdSMS",
                        column: x => x.IdSMS,
                        principalTable: "SMessageS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DocumentType",
                columns: new[] { "Id", "InsertTime", "IsRemoved", "RemoveTime", "Title", "UpdateTime" },
                values: new object[,]
                {
                    { 1L, new DateTime(2022, 9, 20, 18, 10, 1, 727, DateTimeKind.Local).AddTicks(9372), false, null, "مدارک احراز هویت", null },
                    { 2L, new DateTime(2022, 9, 20, 18, 10, 1, 727, DateTimeKind.Local).AddTicks(9379), false, null, "شناسنامه", null },
                    { 3L, new DateTime(2022, 9, 20, 18, 10, 1, 727, DateTimeKind.Local).AddTicks(9381), false, null, "کارت ملی", null },
                    { 4L, new DateTime(2022, 9, 20, 18, 10, 1, 727, DateTimeKind.Local).AddTicks(9383), false, null, "فیش پرداختی", null },
                    { 5L, new DateTime(2022, 9, 20, 18, 10, 1, 727, DateTimeKind.Local).AddTicks(9386), false, null, "جواز", null },
                    { 6L, new DateTime(2022, 9, 20, 18, 10, 1, 727, DateTimeKind.Local).AddTicks(9388), false, null, "خرید خط", null }
                });

            migrationBuilder.InsertData(
                table: "PackageTariff",
                columns: new[] { "Id", "InsertTime", "IsRemoved", "PricePackage", "RemoveTime", "TitlePackage", "UpdateTime", "ZaridTakhfifPaciTareeffe" },
                values: new object[,]
                {
                    { 1L, new DateTime(2022, 9, 20, 18, 10, 1, 727, DateTimeKind.Local).AddTicks(9672), false, 100000L, null, "Golden", null, 0.80000000000000004 },
                    { 2L, new DateTime(2022, 9, 20, 18, 10, 1, 727, DateTimeKind.Local).AddTicks(9681), false, 75000L, null, "Silver", null, 0.90000000000000002 },
                    { 3L, new DateTime(2022, 9, 20, 18, 10, 1, 727, DateTimeKind.Local).AddTicks(9684), false, 50000L, null, "Bronze", null, 0.94999999999999996 },
                    { 4L, new DateTime(2022, 9, 20, 18, 10, 1, 727, DateTimeKind.Local).AddTicks(9686), false, 0L, null, "Ziro", null, 1.0 }
                });

            migrationBuilder.InsertData(
                table: "PatternSMs",
                columns: new[] { "Id", "InsertTime", "IsRemoved", "NumberofVariable", "RemoveTime", "TextPatern", "TitlePattern", "UpdateTime" },
                values: new object[,]
                {
                    { 1L, new DateTime(2022, 9, 20, 18, 10, 1, 727, DateTimeKind.Local).AddTicks(9428), false, 1, null, "  کد تایید شما = %1% است.", "وریفای", null },
                    { 2L, new DateTime(2022, 9, 20, 18, 10, 1, 727, DateTimeKind.Local).AddTicks(9434), false, 1, null, " به اپلیکیشن %1% خوش امدید.", "خوش امد گویی", null },
                    { 3L, new DateTime(2022, 9, 20, 18, 10, 1, 727, DateTimeKind.Local).AddTicks(9438), false, 2, null, "  سلام. %1% عزیز به اپلیکیشن %2% خوش آمدید.", "خوش امد گویی  کاربر خاص", null }
                });

            migrationBuilder.InsertData(
                table: "PeriodSend",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Once" },
                    { 2L, "Hourly" },
                    { 3L, "Daily" },
                    { 4L, "Weekly" },
                    { 5L, "Mounthly" },
                    { 6L, "Annoual" }
                });

            migrationBuilder.InsertData(
                table: "Pishshomareh",
                columns: new[] { "Id", "Discription", "Operator", "Pishshomare", "idOperator" },
                values: new object[,]
                {
                    { 1, null, "همراه اول", "918", 1 },
                    { 2, null, "همراه اول", "917", 1 },
                    { 3, null, "همراه اول", "916", 1 },
                    { 4, null, "همراه اول", "915", 1 },
                    { 5, null, "همراه اول", "914", 1 },
                    { 6, null, "همراه اول", "913", 1 },
                    { 7, null, "همراه اول", "912", 1 },
                    { 8, null, "همراه اول", "911", 1 },
                    { 9, null, "همراه اول", "910", 1 },
                    { 10, null, "همراه اول", "990", 1 },
                    { 11, null, "همراه اول", "991", 1 },
                    { 12, null, "همراه اول", "992", 1 },
                    { 13, null, "همراه اول", "993", 1 },
                    { 14, null, "همراه اول", "994", 1 },
                    { 15, null, "ایرانسل", "901", 2 },
                    { 16, null, "ایرانسل", "902", 2 },
                    { 17, null, "ایرانسل", "903", 2 },
                    { 18, null, "ایرانسل", "904", 2 },
                    { 19, null, "ایرانسل", "905", 2 },
                    { 20, null, "ایرانسل", "933", 2 },
                    { 21, null, "ایرانسل", "935", 2 },
                    { 22, null, "ایرانسل", "936", 2 },
                    { 23, null, "ایرانسل", "937", 2 }
                });

            migrationBuilder.InsertData(
                table: "Pishshomareh",
                columns: new[] { "Id", "Discription", "Operator", "Pishshomare", "idOperator" },
                values: new object[,]
                {
                    { 24, null, "ایرانسل", "938", 2 },
                    { 25, null, "ایرانسل", "939", 2 },
                    { 26, null, "ایرانسل", "930", 2 },
                    { 27, null, "شاتل", "922", 3 },
                    { 28, null, "شاتل", "921", 3 },
                    { 29, null, "شاتل", "920", 3 },
                    { 30, null, "سایر", "904", 4 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "InsertTime", "IsRemoved", "RemoveTime", "Title", "UpdateTime" },
                values: new object[,]
                {
                    { 1L, new DateTime(2022, 9, 20, 18, 10, 1, 727, DateTimeKind.Local).AddTicks(9059), false, null, "مدیر", null },
                    { 2L, new DateTime(2022, 9, 20, 18, 10, 1, 727, DateTimeKind.Local).AddTicks(9112), false, null, "کاربر", null },
                    { 3L, new DateTime(2022, 9, 20, 18, 10, 1, 727, DateTimeKind.Local).AddTicks(9115), false, null, "اپراتور", null }
                });

            migrationBuilder.InsertData(
                table: "SarKhats",
                columns: new[] { "Id", "BasePrice", "EnglishZarib", "HamrahAvalZarib", "InsertTime", "IranselZarib", "IsRemoved", "PersianZarib", "RaytelZarib", "RemoveTime", "SarKhatNumber", "Spacial", "TejasriLinkZarib", "UpdateTime" },
                values: new object[,]
                {
                    { 1, 77.0, 1.2, 1.0, new DateTime(2022, 9, 20, 18, 10, 1, 727, DateTimeKind.Local).AddTicks(9715), 1.2, false, 1.0, 1.5, null, "1000", 1, 1.8999999999999999, null },
                    { 2, 82.0, 1.2, 1.0, new DateTime(2022, 9, 20, 18, 10, 1, 727, DateTimeKind.Local).AddTicks(9724), 1.2, false, 1.0, 1.5, null, "2000", 2, 1.8999999999999999, null },
                    { 3, 77.599999999999994, 1.2, 1.0, new DateTime(2022, 9, 20, 18, 10, 1, 727, DateTimeKind.Local).AddTicks(9728), 1.2, false, 1.0, 1.5, null, "3000", 2, 1.8999999999999999, null },
                    { 4, 77.599999999999994, 1.2, 1.0, new DateTime(2022, 9, 20, 18, 10, 1, 727, DateTimeKind.Local).AddTicks(9731), 1.2, false, 1.0, 1.5, null, "5000", 3, 1.8999999999999999, null }
                });

            migrationBuilder.InsertData(
                table: "SpamWords",
                columns: new[] { "Id", "Word" },
                values: new object[,]
                {
                    { 1L, "Daesh" },
                    { 2L, "داعش" },
                    { 3L, "جنبش" },
                    { 4L, "دموکرات" },
                    { 5L, "اوجالان" },
                    { 6L, "قاضی" },
                    { 7L, "Demokrat" },
                    { 8L, "Ghazi" },
                    { 9L, "Komala" },
                    { 10L, "Dolat" }
                });

            migrationBuilder.InsertData(
                table: "TypeSMS",
                columns: new[] { "Id", "Confirm", "Name", "Periority" },
                values: new object[,]
                {
                    { 1L, true, "رمز پویا", 1 },
                    { 2L, true, "لاگین", 1 },
                    { 3L, true, "فراموشی رمز", 1 },
                    { 4L, true, "اطلاع رسانی", 3 },
                    { 5L, false, "پیام خیلی ضروری", 1 },
                    { 6L, true, "سایر-عادی", 3 }
                });

            migrationBuilder.InsertData(
                table: "Usertype",
                columns: new[] { "Id", "InsertTime", "IsRemoved", "RemoveTime", "Title", "UpdateTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 9, 20, 18, 10, 1, 727, DateTimeKind.Local).AddTicks(9767), false, null, "Real", null },
                    { 2, new DateTime(2022, 9, 20, 18, 10, 1, 727, DateTimeKind.Local).AddTicks(9772), false, null, "Legal", null }
                });

            migrationBuilder.InsertData(
                table: "PublicKhotots",
                columns: new[] { "Id", "IdSarKhat", "LengthofNumber", "LineNumber", "Statue" },
                values: new object[,]
                {
                    { 1, 1, 10, 1000123456L, true },
                    { 2, 2, 12, 200012345678L, true },
                    { 3, 2, 14, 30001234567890L, true }
                });

            migrationBuilder.InsertData(
                table: "SpacitalKhotots",
                columns: new[] { "Id", "IdSarKhat", "LengthofNumber", "Price" },
                values: new object[,]
                {
                    { 1, 1, 10, 8000000L },
                    { 2, 1, 12, 400000L },
                    { 3, 1, 14, 200000L },
                    { 4, 2, 10, 8000000L },
                    { 5, 2, 12, 400000L },
                    { 6, 2, 14, 200000L },
                    { 7, 3, 10, 8000000L },
                    { 8, 3, 12, 400000L },
                    { 9, 3, 14, 200000L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_IdUser",
                table: "Announcements",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_CodeSMs_IdUser",
                table: "CodeSMs",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentsUser_IdDocumentType",
                table: "DocumentsUser",
                column: "IdDocumentType");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentsUser_IdUser",
                table: "DocumentsUser",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_GroupFrinds_IdUser",
                table: "GroupFrinds",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_GroupFrindsPhonebook_PhonebooksId",
                table: "GroupFrindsPhonebook",
                column: "PhonebooksId");

            migrationBuilder.CreateIndex(
                name: "IX_KhototUsers_IdSarKhat",
                table: "KhototUsers",
                column: "IdSarKhat");

            migrationBuilder.CreateIndex(
                name: "IX_KhototUsers_IdUser",
                table: "KhototUsers",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_PatternSMSUsers_UserId",
                table: "PatternSMSUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_IdKhototUser",
                table: "Projects",
                column: "IdKhototUser");

            migrationBuilder.CreateIndex(
                name: "IX_PublicKhotots_IdSarKhat",
                table: "PublicKhotots",
                column: "IdSarKhat");

            migrationBuilder.CreateIndex(
                name: "IX_QeueofSMs_IdUser",
                table: "QeueofSMs",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_SMessageS_IdTypeSMS",
                table: "SMessageS",
                column: "IdTypeSMS");

            migrationBuilder.CreateIndex(
                name: "IX_SMessageS_IdUser",
                table: "SMessageS",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_SMessageS_KhototUserId",
                table: "SMessageS",
                column: "KhototUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SMS_Resivers_IdSMS",
                table: "SMS_Resivers",
                column: "IdSMS");

            migrationBuilder.CreateIndex(
                name: "IX_SpacitalKhotots_IdSarKhat",
                table: "SpacitalKhotots",
                column: "IdSarKhat");

            migrationBuilder.CreateIndex(
                name: "IX_StockSMs_IdUser",
                table: "StockSMs",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_IdUser",
                table: "Ticket",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_IdUser",
                table: "Transactions",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdPackageTariff",
                table: "Users",
                column: "IdPackageTariff");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdUSerType",
                table: "Users",
                column: "IdUSerType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "CodeSMs");

            migrationBuilder.DropTable(
                name: "DocumentsUser");

            migrationBuilder.DropTable(
                name: "EmailUsers");

            migrationBuilder.DropTable(
                name: "GroupFrindsPhonebook");

            migrationBuilder.DropTable(
                name: "NotificationUsers");

            migrationBuilder.DropTable(
                name: "PatternSMSUsers");

            migrationBuilder.DropTable(
                name: "PeriodSend");

            migrationBuilder.DropTable(
                name: "Pishshomareh");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "PublicKhotots");

            migrationBuilder.DropTable(
                name: "QEmailUsers");

            migrationBuilder.DropTable(
                name: "QeueofSMs");

            migrationBuilder.DropTable(
                name: "QNotificationUsers");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "SMS_Resivers");

            migrationBuilder.DropTable(
                name: "SpacitalKhotots");

            migrationBuilder.DropTable(
                name: "SpamWords");

            migrationBuilder.DropTable(
                name: "StockSMs");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "DocumentType");

            migrationBuilder.DropTable(
                name: "GroupFrinds");

            migrationBuilder.DropTable(
                name: "Phonebooks");

            migrationBuilder.DropTable(
                name: "PatternSMs");

            migrationBuilder.DropTable(
                name: "SMessageS");

            migrationBuilder.DropTable(
                name: "KhototUsers");

            migrationBuilder.DropTable(
                name: "TypeSMS");

            migrationBuilder.DropTable(
                name: "SarKhats");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "PackageTariff");

            migrationBuilder.DropTable(
                name: "Usertype");
        }
    }
}
