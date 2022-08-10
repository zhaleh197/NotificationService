using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notification.Persistance.Migrations
{
    public partial class hg : Migration
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
                name: "EmailClients",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdClient = table.Column<long>(type: "bigint", nullable: false),
                    Resiver = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateSend = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateDelivere = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailClients", x => x.Id);
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
                name: "NotificationClients",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdClient = table.Column<long>(type: "bigint", nullable: false),
                    Resiver = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateSend = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateDelivere = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationClients", x => x.Id);
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
                name: "PackageSMS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitlePackage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePackage = table.Column<long>(type: "bigint", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageSMS", x => x.Id);
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
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleProject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUser = table.Column<long>(type: "bigint", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QEmailClients",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdClient = table.Column<long>(type: "bigint", nullable: false),
                    Resiver = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateSendStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Periority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QEmailClients", x => x.Id);
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
                name: "QNotificationClient",
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
                    table.PrimaryKey("PK_QNotificationClient", x => x.Id);
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
                name: "SarKhats",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Spacial = table.Column<bool>(type: "bit", nullable: false),
                    SarKhatNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "SMSClients",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdClient = table.Column<long>(type: "bigint", nullable: false),
                    Resiver = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateSend = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateDelivere = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMSClients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usertype",
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
                    table.PrimaryKey("PK_Usertype", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PackageTariff",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPackageSMS = table.Column<long>(type: "bigint", nullable: false),
                    IdSarKhat = table.Column<long>(type: "bigint", nullable: false),
                    FarsiTariff = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnglishTariff = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageTariff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageTariff_PackageSMS_IdPackageSMS",
                        column: x => x.IdPackageSMS,
                        principalTable: "PackageSMS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KhatSMS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSarKhat = table.Column<long>(type: "bigint", nullable: false),
                    LineNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Statuse = table.Column<bool>(type: "bit", nullable: false),
                    IdProjects = table.Column<long>(type: "bigint", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhatSMS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KhatSMS_Projects_IdProjects",
                        column: x => x.IdProjects,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KhatSMS_SarKhats_IdSarKhat",
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
                    IdUSerType = table.Column<long>(type: "bigint", nullable: false),
                    IdPackageTariff = table.Column<long>(type: "bigint", nullable: false),
                    DeadlinePackage = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                name: "QeueofSMs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<long>(type: "bigint", nullable: false),
                    txt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    to = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeofResiver = table.Column<bool>(type: "bit", nullable: false),
                    dateOfsend = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    timeOfsend = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateofLimitet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    periority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    periodSendly = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                name: "QSMSClient",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<long>(type: "bigint", nullable: false),
                    Resiver = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateSendStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Periority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QSMSClient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QSMSClient_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SMSUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<long>(type: "bigint", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMSUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SMSUsers_Users_IdUser",
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
                name: "QSMSUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSMS = table.Column<long>(type: "bigint", nullable: false),
                    DateSendStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Periority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QSMSUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QSMSUsers_SMSUsers_IdSMS",
                        column: x => x.IdSMS,
                        principalTable: "SMSUsers",
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
                    DateSend = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateDelivere = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SendStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMS_Resivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SMS_Resivers_SMSUsers_IdSMS",
                        column: x => x.IdSMS,
                        principalTable: "SMSUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PackageSMS",
                columns: new[] { "Id", "InsertTime", "IsRemoved", "PricePackage", "RemoveTime", "TitlePackage", "UpdateTime" },
                values: new object[,]
                {
                    { 1L, new DateTime(2022, 8, 2, 15, 49, 57, 467, DateTimeKind.Local).AddTicks(9484), false, 100000L, null, "Golden", null },
                    { 2L, new DateTime(2022, 8, 2, 15, 49, 57, 467, DateTimeKind.Local).AddTicks(9494), false, 75000L, null, "Silver", null },
                    { 3L, new DateTime(2022, 8, 2, 15, 49, 57, 467, DateTimeKind.Local).AddTicks(9498), false, 50000L, null, "Bronze", null }
                });

            migrationBuilder.InsertData(
                table: "SarKhats",
                columns: new[] { "Id", "InsertTime", "IsRemoved", "RemoveTime", "SarKhatNumber", "Spacial", "UpdateTime" },
                values: new object[,]
                {
                    { 1L, new DateTime(2022, 8, 2, 15, 49, 57, 467, DateTimeKind.Local).AddTicks(9532), false, null, "1000", true, null },
                    { 2L, new DateTime(2022, 8, 2, 15, 49, 57, 467, DateTimeKind.Local).AddTicks(9536), false, null, "2000", false, null },
                    { 3L, new DateTime(2022, 8, 2, 15, 49, 57, 467, DateTimeKind.Local).AddTicks(9540), false, null, "3000", false, null }
                });

            migrationBuilder.InsertData(
                table: "Usertype",
                columns: new[] { "Id", "InsertTime", "IsRemoved", "RemoveTime", "Title", "UpdateTime" },
                values: new object[,]
                {
                    { 1L, new DateTime(2022, 8, 2, 15, 49, 57, 467, DateTimeKind.Local).AddTicks(9575), false, null, "Real", null },
                    { 2L, new DateTime(2022, 8, 2, 15, 49, 57, 467, DateTimeKind.Local).AddTicks(9579), false, null, "Legal", null }
                });

            migrationBuilder.InsertData(
                table: "PackageTariff",
                columns: new[] { "Id", "EnglishTariff", "FarsiTariff", "IdPackageSMS", "IdSarKhat", "InsertTime", "IsRemoved", "RemoveTime", "UpdateTime" },
                values: new object[] { 1L, "25", "30", 1L, 1L, new DateTime(2022, 8, 2, 15, 49, 57, 467, DateTimeKind.Local).AddTicks(9190), false, null, null });

            migrationBuilder.InsertData(
                table: "PackageTariff",
                columns: new[] { "Id", "EnglishTariff", "FarsiTariff", "IdPackageSMS", "IdSarKhat", "InsertTime", "IsRemoved", "RemoveTime", "UpdateTime" },
                values: new object[] { 2L, "35", "40", 2L, 2L, new DateTime(2022, 8, 2, 15, 49, 57, 467, DateTimeKind.Local).AddTicks(9197), false, null, null });

            migrationBuilder.InsertData(
                table: "PackageTariff",
                columns: new[] { "Id", "EnglishTariff", "FarsiTariff", "IdPackageSMS", "IdSarKhat", "InsertTime", "IsRemoved", "RemoveTime", "UpdateTime" },
                values: new object[] { 3L, "45", "50", 3L, 3L, new DateTime(2022, 8, 2, 15, 49, 57, 467, DateTimeKind.Local).AddTicks(9202), false, null, null });

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
                name: "IX_KhatSMS_IdProjects",
                table: "KhatSMS",
                column: "IdProjects");

            migrationBuilder.CreateIndex(
                name: "IX_KhatSMS_IdSarKhat",
                table: "KhatSMS",
                column: "IdSarKhat");

            migrationBuilder.CreateIndex(
                name: "IX_PackageTariff_IdPackageSMS",
                table: "PackageTariff",
                column: "IdPackageSMS");

            migrationBuilder.CreateIndex(
                name: "IX_QeueofSMs_IdUser",
                table: "QeueofSMs",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_QSMSClient_IdUser",
                table: "QSMSClient",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_QSMSUsers_IdSMS",
                table: "QSMSUsers",
                column: "IdSMS");

            migrationBuilder.CreateIndex(
                name: "IX_SMS_Resivers_IdSMS",
                table: "SMS_Resivers",
                column: "IdSMS");

            migrationBuilder.CreateIndex(
                name: "IX_SMSUsers_IdUser",
                table: "SMSUsers",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_StockSMs_IdUser",
                table: "StockSMs",
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
                name: "EmailClients");

            migrationBuilder.DropTable(
                name: "EmailUsers");

            migrationBuilder.DropTable(
                name: "GroupFrindsPhonebook");

            migrationBuilder.DropTable(
                name: "KhatSMS");

            migrationBuilder.DropTable(
                name: "NotificationClients");

            migrationBuilder.DropTable(
                name: "NotificationUsers");

            migrationBuilder.DropTable(
                name: "QEmailClients");

            migrationBuilder.DropTable(
                name: "QEmailUsers");

            migrationBuilder.DropTable(
                name: "QeueofSMs");

            migrationBuilder.DropTable(
                name: "QNotificationClient");

            migrationBuilder.DropTable(
                name: "QNotificationUsers");

            migrationBuilder.DropTable(
                name: "QSMSClient");

            migrationBuilder.DropTable(
                name: "QSMSUsers");

            migrationBuilder.DropTable(
                name: "SMS_Resivers");

            migrationBuilder.DropTable(
                name: "SMSClients");

            migrationBuilder.DropTable(
                name: "StockSMs");

            migrationBuilder.DropTable(
                name: "DocumentType");

            migrationBuilder.DropTable(
                name: "GroupFrinds");

            migrationBuilder.DropTable(
                name: "Phonebooks");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "SarKhats");

            migrationBuilder.DropTable(
                name: "SMSUsers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "PackageTariff");

            migrationBuilder.DropTable(
                name: "Usertype");

            migrationBuilder.DropTable(
                name: "PackageSMS");
        }
    }
}
