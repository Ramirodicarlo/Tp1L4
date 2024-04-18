using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TODOLIST.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    State = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ToDo",
                columns: table => new
                {
                    ToDoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    State = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDo", x => x.ToDoId);
                    table.ForeignKey(
                        name: "FK_ToDo_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.InsertData(
                table: "ToDo",
                columns: new[] { "ToDoId", "Description", "State", "Title", "UserId" },
                values: new object[] { 1, "Es la descripcion", true, "Controlers", null });

            migrationBuilder.InsertData(
                table: "ToDo",
                columns: new[] { "ToDoId", "Description", "State", "Title", "UserId" },
                values: new object[] { 2, "Es la descripcion", true, "Controlers2", null });

            migrationBuilder.InsertData(
                table: "ToDo",
                columns: new[] { "ToDoId", "Description", "State", "Title", "UserId" },
                values: new object[] { 3, "Es la descripcion", true, "Controlers3", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "Email", "State", "UserName" },
                values: new object[] { 1, "Membrives 8911", "ramirodicarlo2@gmail.com", true, "rdic" });

            migrationBuilder.CreateIndex(
                name: "IX_ToDo_UserId",
                table: "ToDo",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDo");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
