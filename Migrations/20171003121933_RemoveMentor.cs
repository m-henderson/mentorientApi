using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace mentorientapi.Migrations
{
    public partial class RemoveMentor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Mentors_MentorId",
                table: "Videos");

            migrationBuilder.DropTable(
                name: "Mentors");

            migrationBuilder.DropIndex(
                name: "IX_Videos_MentorId",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "MentorId",
                table: "Videos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MentorId",
                table: "Videos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Mentors",
                columns: table => new
                {
                    MentorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FristName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mentors", x => x.MentorId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Videos_MentorId",
                table: "Videos",
                column: "MentorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Mentors_MentorId",
                table: "Videos",
                column: "MentorId",
                principalTable: "Mentors",
                principalColumn: "MentorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
