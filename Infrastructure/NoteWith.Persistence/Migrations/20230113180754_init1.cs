using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoteWith.Persistence.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Content = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Color = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreadedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UpdatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreadedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ObjectStatus = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Notices",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Content = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreadedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UpdatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreadedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ObjectStatus = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notices", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Surname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmeToken = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsEmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ProfileImage = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FireBaseConnectionID = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreadedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UpdatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreadedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ObjectStatus = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WorkEvents",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Content = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreadedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UpdatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreadedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ObjectStatus = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkEvents", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WorkGroups",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Color = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GroupFirebaseConnctionID = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreadedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UpdatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreadedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ObjectStatus = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkGroups", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WorkLists",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Desc = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Color = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreadedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UpdatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreadedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ObjectStatus = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkLists", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NoteExcludedUsers",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NoteID = table.Column<int>(type: "int", nullable: false),
                    NoteID1 = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    UserID1 = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Desc = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreadedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UpdatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreadedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ObjectStatus = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteExcludedUsers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NoteExcludedUsers_Notes_NoteID1",
                        column: x => x.NoteID1,
                        principalTable: "Notes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoteExcludedUsers_Users_UserID1",
                        column: x => x.UserID1,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NoteNotifiedMes",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NoteID = table.Column<int>(type: "int", nullable: false),
                    NoteID1 = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserID1 = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    CreadedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UpdatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreadedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ObjectStatus = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteNotifiedMes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NoteNotifiedMes_Notes_NoteID1",
                        column: x => x.NoteID1,
                        principalTable: "Notes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoteNotifiedMes_Users_UserID1",
                        column: x => x.UserID1,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NoticeSeenUsers",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NoticeID = table.Column<int>(type: "int", nullable: false),
                    NoticeID1 = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    UserID1 = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreadedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UpdatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreadedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ObjectStatus = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoticeSeenUsers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NoticeSeenUsers_Notices_NoticeID1",
                        column: x => x.NoticeID1,
                        principalTable: "Notices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoticeSeenUsers_Users_UserID1",
                        column: x => x.UserID1,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PersonelMessageModels",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SenderID = table.Column<int>(type: "int", nullable: false),
                    SenderID1 = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ReceiverID = table.Column<int>(type: "int", nullable: false),
                    ReceiverID1 = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Message = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreadedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UpdatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreadedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ObjectStatus = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonelMessageModels", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PersonelMessageModels_Users_ReceiverID1",
                        column: x => x.ReceiverID1,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonelMessageModels_Users_SenderID1",
                        column: x => x.SenderID1,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WorkEventExcludedUsers",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EventID = table.Column<int>(type: "int", nullable: false),
                    EventID1 = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    UserID1 = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Desc = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreadedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UpdatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreadedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ObjectStatus = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkEventExcludedUsers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WorkEventExcludedUsers_Users_UserID1",
                        column: x => x.UserID1,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkEventExcludedUsers_WorkEvents_EventID1",
                        column: x => x.EventID1,
                        principalTable: "WorkEvents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WorkEventNotifiedMes",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EventID = table.Column<int>(type: "int", nullable: false),
                    EventID1 = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    UserID1 = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NotificatonID = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreadedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UpdatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreadedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ObjectStatus = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkEventNotifiedMes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WorkEventNotifiedMes_Users_UserID1",
                        column: x => x.UserID1,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkEventNotifiedMes_WorkEvents_EventID1",
                        column: x => x.EventID1,
                        principalTable: "WorkEvents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NoteGroups",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NoteID = table.Column<int>(type: "int", nullable: false),
                    NoteID1 = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    WorkGroupID = table.Column<int>(type: "int", nullable: false),
                    WorkGroupID1 = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreadedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UpdatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreadedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ObjectStatus = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteGroups", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NoteGroups_Notes_NoteID1",
                        column: x => x.NoteID1,
                        principalTable: "Notes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoteGroups_WorkGroups_WorkGroupID1",
                        column: x => x.WorkGroupID1,
                        principalTable: "WorkGroups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WorkEventGroups",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EventID = table.Column<int>(type: "int", nullable: false),
                    EventID1 = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    WorkGroupID = table.Column<int>(type: "int", nullable: false),
                    WorkGroupID1 = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreadedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UpdatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreadedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ObjectStatus = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkEventGroups", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WorkEventGroups_WorkEvents_EventID1",
                        column: x => x.EventID1,
                        principalTable: "WorkEvents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkEventGroups_WorkGroups_WorkGroupID1",
                        column: x => x.WorkGroupID1,
                        principalTable: "WorkGroups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WorkFilesFolders",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkGroupID = table.Column<int>(type: "int", nullable: false),
                    WorkGroupID1 = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreadedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UpdatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreadedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ObjectStatus = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkFilesFolders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WorkFilesFolders_WorkGroups_WorkGroupID1",
                        column: x => x.WorkGroupID1,
                        principalTable: "WorkGroups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WorkGroupAlbums",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkGroupID = table.Column<int>(type: "int", nullable: false),
                    WorkGroupID1 = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreadedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UpdatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreadedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ObjectStatus = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkGroupAlbums", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WorkGroupAlbums_WorkGroups_WorkGroupID1",
                        column: x => x.WorkGroupID1,
                        principalTable: "WorkGroups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WorkGroupMessages",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    WorkGroupID = table.Column<int>(type: "int", nullable: false),
                    WorkGroupID1 = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SenderID = table.Column<int>(type: "int", nullable: false),
                    SenderID1 = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Message = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreadedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UpdatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreadedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ObjectStatus = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkGroupMessages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WorkGroupMessages_Users_SenderID1",
                        column: x => x.SenderID1,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkGroupMessages_WorkGroups_WorkGroupID1",
                        column: x => x.WorkGroupID1,
                        principalTable: "WorkGroups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WorkGroupNotices",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NoticeID = table.Column<int>(type: "int", nullable: false),
                    NoticeID1 = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    WorkGroupID = table.Column<int>(type: "int", nullable: false),
                    WorkGroupID1 = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreadedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UpdatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreadedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ObjectStatus = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkGroupNotices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WorkGroupNotices_Notices_NoticeID1",
                        column: x => x.NoticeID1,
                        principalTable: "Notices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkGroupNotices_WorkGroups_WorkGroupID1",
                        column: x => x.WorkGroupID1,
                        principalTable: "WorkGroups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WorkGroupUsers",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    WorkGroupID1 = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    WorkGroupID = table.Column<int>(type: "int", nullable: false),
                    UserID1 = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    IsManager = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsNute = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreadedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UpdatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreadedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ObjectStatus = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkGroupUsers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WorkGroupUsers_Users_UserID1",
                        column: x => x.UserID1,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkGroupUsers_WorkGroups_WorkGroupID1",
                        column: x => x.WorkGroupID1,
                        principalTable: "WorkGroups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ListWorkGroups",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    WorkListID = table.Column<int>(type: "int", nullable: false),
                    WorkListID1 = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    WorkGroupID = table.Column<int>(type: "int", nullable: false),
                    WorkGroupID1 = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreadedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UpdatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreadedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ObjectStatus = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListWorkGroups", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ListWorkGroups_WorkGroups_WorkGroupID1",
                        column: x => x.WorkGroupID1,
                        principalTable: "WorkGroups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListWorkGroups_WorkLists_WorkListID1",
                        column: x => x.WorkListID1,
                        principalTable: "WorkLists",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WorkListExcludedUsers",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    WorkListID = table.Column<int>(type: "int", nullable: false),
                    WorkListID1 = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    UserID1 = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Desc = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreadedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UpdatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreadedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ObjectStatus = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkListExcludedUsers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WorkListExcludedUsers_Users_UserID1",
                        column: x => x.UserID1,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkListExcludedUsers_WorkLists_WorkListID1",
                        column: x => x.WorkListID1,
                        principalTable: "WorkLists",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WorkListItems",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    WorkListID = table.Column<int>(type: "int", nullable: false),
                    WorkListID1 = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Content = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsCoplated = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Color = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ComplaterUserID = table.Column<int>(type: "int", nullable: false),
                    ComplaterUserID1 = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreadedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UpdatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreadedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ObjectStatus = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkListItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WorkListItems_Users_ComplaterUserID1",
                        column: x => x.ComplaterUserID1,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkListItems_WorkLists_WorkListID1",
                        column: x => x.WorkListID1,
                        principalTable: "WorkLists",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WorkListNotifiedMes",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    WorkListID = table.Column<int>(type: "int", nullable: false),
                    WorkListID1 = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    UserID1 = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreadedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UpdatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreadedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ObjectStatus = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkListNotifiedMes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WorkListNotifiedMes_Users_UserID1",
                        column: x => x.UserID1,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkListNotifiedMes_WorkLists_WorkListID1",
                        column: x => x.WorkListID1,
                        principalTable: "WorkLists",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WorkFiles",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    WorkFilesFolderID = table.Column<int>(type: "int", nullable: false),
                    WorkFilesFolderID1 = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Url = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreadedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UpdatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreadedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ObjectStatus = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkFiles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WorkFiles_WorkFilesFolders_WorkFilesFolderID1",
                        column: x => x.WorkFilesFolderID1,
                        principalTable: "WorkFilesFolders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WorkPhotos",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AlbumID = table.Column<int>(type: "int", nullable: false),
                    AlbumID1 = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UrlSmallImage = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UrlMediumImage = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UrlOrgin = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreadedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UpdatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreadedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ObjectStatus = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkPhotos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WorkPhotos_WorkGroupAlbums_AlbumID1",
                        column: x => x.AlbumID1,
                        principalTable: "WorkGroupAlbums",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ListWorkGroups_WorkGroupID1",
                table: "ListWorkGroups",
                column: "WorkGroupID1");

            migrationBuilder.CreateIndex(
                name: "IX_ListWorkGroups_WorkListID1",
                table: "ListWorkGroups",
                column: "WorkListID1");

            migrationBuilder.CreateIndex(
                name: "IX_NoteExcludedUsers_NoteID1",
                table: "NoteExcludedUsers",
                column: "NoteID1");

            migrationBuilder.CreateIndex(
                name: "IX_NoteExcludedUsers_UserID1",
                table: "NoteExcludedUsers",
                column: "UserID1");

            migrationBuilder.CreateIndex(
                name: "IX_NoteGroups_NoteID1",
                table: "NoteGroups",
                column: "NoteID1");

            migrationBuilder.CreateIndex(
                name: "IX_NoteGroups_WorkGroupID1",
                table: "NoteGroups",
                column: "WorkGroupID1");

            migrationBuilder.CreateIndex(
                name: "IX_NoteNotifiedMes_NoteID1",
                table: "NoteNotifiedMes",
                column: "NoteID1");

            migrationBuilder.CreateIndex(
                name: "IX_NoteNotifiedMes_UserID1",
                table: "NoteNotifiedMes",
                column: "UserID1");

            migrationBuilder.CreateIndex(
                name: "IX_NoticeSeenUsers_NoticeID1",
                table: "NoticeSeenUsers",
                column: "NoticeID1");

            migrationBuilder.CreateIndex(
                name: "IX_NoticeSeenUsers_UserID1",
                table: "NoticeSeenUsers",
                column: "UserID1");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelMessageModels_ReceiverID1",
                table: "PersonelMessageModels",
                column: "ReceiverID1");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelMessageModels_SenderID1",
                table: "PersonelMessageModels",
                column: "SenderID1");

            migrationBuilder.CreateIndex(
                name: "IX_WorkEventExcludedUsers_EventID1",
                table: "WorkEventExcludedUsers",
                column: "EventID1");

            migrationBuilder.CreateIndex(
                name: "IX_WorkEventExcludedUsers_UserID1",
                table: "WorkEventExcludedUsers",
                column: "UserID1");

            migrationBuilder.CreateIndex(
                name: "IX_WorkEventGroups_EventID1",
                table: "WorkEventGroups",
                column: "EventID1");

            migrationBuilder.CreateIndex(
                name: "IX_WorkEventGroups_WorkGroupID1",
                table: "WorkEventGroups",
                column: "WorkGroupID1");

            migrationBuilder.CreateIndex(
                name: "IX_WorkEventNotifiedMes_EventID1",
                table: "WorkEventNotifiedMes",
                column: "EventID1");

            migrationBuilder.CreateIndex(
                name: "IX_WorkEventNotifiedMes_UserID1",
                table: "WorkEventNotifiedMes",
                column: "UserID1");

            migrationBuilder.CreateIndex(
                name: "IX_WorkFiles_WorkFilesFolderID1",
                table: "WorkFiles",
                column: "WorkFilesFolderID1");

            migrationBuilder.CreateIndex(
                name: "IX_WorkFilesFolders_WorkGroupID1",
                table: "WorkFilesFolders",
                column: "WorkGroupID1");

            migrationBuilder.CreateIndex(
                name: "IX_WorkGroupAlbums_WorkGroupID1",
                table: "WorkGroupAlbums",
                column: "WorkGroupID1");

            migrationBuilder.CreateIndex(
                name: "IX_WorkGroupMessages_SenderID1",
                table: "WorkGroupMessages",
                column: "SenderID1");

            migrationBuilder.CreateIndex(
                name: "IX_WorkGroupMessages_WorkGroupID1",
                table: "WorkGroupMessages",
                column: "WorkGroupID1");

            migrationBuilder.CreateIndex(
                name: "IX_WorkGroupNotices_NoticeID1",
                table: "WorkGroupNotices",
                column: "NoticeID1");

            migrationBuilder.CreateIndex(
                name: "IX_WorkGroupNotices_WorkGroupID1",
                table: "WorkGroupNotices",
                column: "WorkGroupID1");

            migrationBuilder.CreateIndex(
                name: "IX_WorkGroupUsers_UserID1",
                table: "WorkGroupUsers",
                column: "UserID1");

            migrationBuilder.CreateIndex(
                name: "IX_WorkGroupUsers_WorkGroupID1",
                table: "WorkGroupUsers",
                column: "WorkGroupID1");

            migrationBuilder.CreateIndex(
                name: "IX_WorkListExcludedUsers_UserID1",
                table: "WorkListExcludedUsers",
                column: "UserID1");

            migrationBuilder.CreateIndex(
                name: "IX_WorkListExcludedUsers_WorkListID1",
                table: "WorkListExcludedUsers",
                column: "WorkListID1");

            migrationBuilder.CreateIndex(
                name: "IX_WorkListItems_ComplaterUserID1",
                table: "WorkListItems",
                column: "ComplaterUserID1");

            migrationBuilder.CreateIndex(
                name: "IX_WorkListItems_WorkListID1",
                table: "WorkListItems",
                column: "WorkListID1");

            migrationBuilder.CreateIndex(
                name: "IX_WorkListNotifiedMes_UserID1",
                table: "WorkListNotifiedMes",
                column: "UserID1");

            migrationBuilder.CreateIndex(
                name: "IX_WorkListNotifiedMes_WorkListID1",
                table: "WorkListNotifiedMes",
                column: "WorkListID1");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPhotos_AlbumID1",
                table: "WorkPhotos",
                column: "AlbumID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListWorkGroups");

            migrationBuilder.DropTable(
                name: "NoteExcludedUsers");

            migrationBuilder.DropTable(
                name: "NoteGroups");

            migrationBuilder.DropTable(
                name: "NoteNotifiedMes");

            migrationBuilder.DropTable(
                name: "NoticeSeenUsers");

            migrationBuilder.DropTable(
                name: "PersonelMessageModels");

            migrationBuilder.DropTable(
                name: "WorkEventExcludedUsers");

            migrationBuilder.DropTable(
                name: "WorkEventGroups");

            migrationBuilder.DropTable(
                name: "WorkEventNotifiedMes");

            migrationBuilder.DropTable(
                name: "WorkFiles");

            migrationBuilder.DropTable(
                name: "WorkGroupMessages");

            migrationBuilder.DropTable(
                name: "WorkGroupNotices");

            migrationBuilder.DropTable(
                name: "WorkGroupUsers");

            migrationBuilder.DropTable(
                name: "WorkListExcludedUsers");

            migrationBuilder.DropTable(
                name: "WorkListItems");

            migrationBuilder.DropTable(
                name: "WorkListNotifiedMes");

            migrationBuilder.DropTable(
                name: "WorkPhotos");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "WorkEvents");

            migrationBuilder.DropTable(
                name: "WorkFilesFolders");

            migrationBuilder.DropTable(
                name: "Notices");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "WorkLists");

            migrationBuilder.DropTable(
                name: "WorkGroupAlbums");

            migrationBuilder.DropTable(
                name: "WorkGroups");
        }
    }
}
