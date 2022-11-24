using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestJob.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CancelDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommentType = table.Column<byte>(type: "tinyint", nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskComments_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreateDate", "ProjectName", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("24f49fa2-a80f-4471-b8c8-ea2e0e6b1f2e"), new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Local), "Project 2", new DateTime(2022, 11, 24, 12, 26, 46, 655, DateTimeKind.Local).AddTicks(858) },
                    { new Guid("c868fb18-23f9-4db0-baf1-5ef9d658b97f"), new DateTime(2022, 11, 22, 0, 0, 0, 0, DateTimeKind.Local), "Project 3", new DateTime(2022, 11, 24, 11, 26, 46, 655, DateTimeKind.Local).AddTicks(861) },
                    { new Guid("d672157a-9b75-4ba0-9ec1-3284bb8480dc"), new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), "Project 1", new DateTime(2022, 11, 24, 13, 26, 46, 655, DateTimeKind.Local).AddTicks(847) }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CancelDate", "CreateDate", "ProjectId", "StartDate", "TaskName", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("1f1f8d2f-f684-4bd0-a126-2f59856c8efe"), new DateTime(2022, 11, 24, 5, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 11, 24, 1, 0, 0, 0, DateTimeKind.Local), new Guid("d672157a-9b75-4ba0-9ec1-3284bb8480dc"), new DateTime(2022, 11, 24, 2, 0, 0, 0, DateTimeKind.Local), "Task 4", new DateTime(2022, 11, 24, 3, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("37e270f2-0d92-4148-90e0-24ad465c4b87"), new DateTime(2022, 11, 23, 5, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 11, 23, 1, 0, 0, 0, DateTimeKind.Local), new Guid("24f49fa2-a80f-4471-b8c8-ea2e0e6b1f2e"), new DateTime(2022, 11, 23, 2, 0, 0, 0, DateTimeKind.Local), "Task 3", new DateTime(2022, 11, 23, 3, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("40e6fb67-bc64-4c73-880d-9eccac4e691b"), new DateTime(2022, 11, 22, 5, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 11, 22, 1, 0, 0, 0, DateTimeKind.Local), new Guid("c868fb18-23f9-4db0-baf1-5ef9d658b97f"), new DateTime(2022, 11, 22, 2, 0, 0, 0, DateTimeKind.Local), "Task 7", new DateTime(2022, 11, 22, 3, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("8d733e85-a506-471f-aa60-1d6414e22d53"), new DateTime(2022, 11, 24, 5, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 11, 24, 1, 0, 0, 0, DateTimeKind.Local), new Guid("d672157a-9b75-4ba0-9ec1-3284bb8480dc"), new DateTime(2022, 11, 24, 2, 0, 0, 0, DateTimeKind.Local), "Task 8", new DateTime(2022, 11, 24, 3, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("bb7fcec9-9190-4a55-a9ec-bb692a9006b1"), new DateTime(2022, 11, 24, 5, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 11, 24, 1, 0, 0, 0, DateTimeKind.Local), new Guid("d672157a-9b75-4ba0-9ec1-3284bb8480dc"), new DateTime(2022, 11, 24, 2, 0, 0, 0, DateTimeKind.Local), "Task 1", new DateTime(2022, 11, 24, 3, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("cb23a37c-7b81-4a33-82bd-e58888224e51"), new DateTime(2022, 11, 23, 5, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 11, 23, 1, 0, 0, 0, DateTimeKind.Local), new Guid("24f49fa2-a80f-4471-b8c8-ea2e0e6b1f2e"), new DateTime(2022, 11, 23, 2, 0, 0, 0, DateTimeKind.Local), "Task 5", new DateTime(2022, 11, 23, 3, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("d7667adf-3155-49b1-80b4-d586b31a5aae"), new DateTime(2022, 11, 23, 5, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 11, 23, 1, 0, 0, 0, DateTimeKind.Local), new Guid("24f49fa2-a80f-4471-b8c8-ea2e0e6b1f2e"), new DateTime(2022, 11, 23, 2, 0, 0, 0, DateTimeKind.Local), "Task 6", new DateTime(2022, 11, 23, 3, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("eb99502a-d91f-4858-bb96-232fcb0a3f86"), new DateTime(2022, 11, 22, 5, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 11, 22, 1, 0, 0, 0, DateTimeKind.Local), new Guid("c868fb18-23f9-4db0-baf1-5ef9d658b97f"), new DateTime(2022, 11, 22, 2, 0, 0, 0, DateTimeKind.Local), "Task 2", new DateTime(2022, 11, 22, 3, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "TaskComments",
                columns: new[] { "Id", "CommentType", "Content", "TaskId" },
                values: new object[,]
                {
                    { new Guid("0392ced5-9e92-4a67-b58b-2ee11ef03c46"), (byte)1, new byte[] { 65, 100, 100, 32, 100, 101, 115, 99, 114, 105, 112, 116, 105, 111, 110 }, new Guid("eb99502a-d91f-4858-bb96-232fcb0a3f86") },
                    { new Guid("08f5a218-0608-43c1-98ef-311387bd77cd"), (byte)1, new byte[] { 68, 66, 32, 73, 110, 100, 101, 120, 101, 115, 32, 40, 77, 121, 83, 81, 76, 41 }, new Guid("8d733e85-a506-471f-aa60-1d6414e22d53") },
                    { new Guid("164cbd88-0bd9-4c01-938b-09dab24804cd"), (byte)1, new byte[] { 65, 83, 80, 46, 78, 69, 84, 32, 67, 111, 114, 101, 32, 55 }, new Guid("40e6fb67-bc64-4c73-880d-9eccac4e691b") },
                    { new Guid("3f237ecc-8441-4b58-8b18-f13933a8b54a"), (byte)1, new byte[] { 69, 120, 112, 108, 111, 114, 101, 32, 68, 73, 44, 32, 73, 111, 67, 32, 97, 110, 100, 32, 109, 105, 100, 100, 108, 101, 119, 97, 114, 101 }, new Guid("cb23a37c-7b81-4a33-82bd-e58888224e51") },
                    { new Guid("3fa8d8d8-04a9-4d95-8513-5f96a549800f"), (byte)1, new byte[] { 69, 120, 112, 108, 111, 114, 101, 32, 82, 97, 98, 98, 105, 116, 77, 81 }, new Guid("1f1f8d2f-f684-4bd0-a126-2f59856c8efe") },
                    { new Guid("40ad3b73-55f1-4676-bf3b-f43c134178f5"), (byte)1, new byte[] { 69, 120, 112, 108, 111, 114, 101, 32, 75, 97, 102, 107, 97 }, new Guid("d7667adf-3155-49b1-80b4-d586b31a5aae") },
                    { new Guid("a25ce494-8637-4020-a1bc-b0880c20d01a"), (byte)1, new byte[] { 69, 120, 112, 108, 111, 114, 101, 32, 71, 114, 97, 112, 104, 81, 76 }, new Guid("37e270f2-0d92-4148-90e0-24ad465c4b87") },
                    { new Guid("a651f1aa-f1d2-40b2-9c75-bccb92cd80ef"), (byte)1, new byte[] { 68, 66, 32, 73, 110, 100, 101, 120, 101, 115, 32, 40, 80, 111, 115, 116, 103, 114, 101, 83, 81, 76, 41 }, new Guid("8d733e85-a506-471f-aa60-1d6414e22d53") },
                    { new Guid("cabac605-e821-4b6f-9651-f2260c8c5aaa"), (byte)1, new byte[] { 46, 78, 69, 84, 32, 77, 65, 85, 73, 63, 63, 63 }, new Guid("40e6fb67-bc64-4c73-880d-9eccac4e691b") },
                    { new Guid("cad59826-b319-4ae2-9978-7ef7b1ef883e"), (byte)1, new byte[] { 68, 66, 32, 73, 110, 100, 101, 120, 101, 115, 32, 40, 83, 81, 76, 32, 83, 101, 114, 118, 101, 114, 41 }, new Guid("8d733e85-a506-471f-aa60-1d6414e22d53") },
                    { new Guid("fac39cfb-f171-42b9-ab0a-07550782d4f1"), (byte)1, new byte[] { 84, 101, 115, 116, 32, 99, 111, 109, 109, 101, 110, 116 }, new Guid("bb7fcec9-9190-4a55-a9ec-bb692a9006b1") },
                    { new Guid("fffb3703-ef7a-410f-8e28-af11c7f42c30"), (byte)1, new byte[] { 72, 101, 108, 108, 111, 32, 119, 111, 114, 108, 100, 33 }, new Guid("bb7fcec9-9190-4a55-a9ec-bb692a9006b1") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskComments_TaskId",
                table: "TaskComments",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectId",
                table: "Tasks",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskComments");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
