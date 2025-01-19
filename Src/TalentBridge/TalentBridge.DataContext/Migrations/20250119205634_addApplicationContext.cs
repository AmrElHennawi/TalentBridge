using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TalentBridge.DataContext.Migrations
{
    /// <inheritdoc />
    public partial class addApplicationContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_AspNetUsers_JobSeekerId",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Application_Jobs_JobId",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_ExtraData_Application_ApplicationId",
                table: "ExtraData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Application",
                table: "Application");

            migrationBuilder.RenameTable(
                name: "Application",
                newName: "Applications");

            migrationBuilder.RenameIndex(
                name: "IX_Application_JobSeekerId",
                table: "Applications",
                newName: "IX_Applications_JobSeekerId");

            migrationBuilder.RenameIndex(
                name: "IX_Application_JobId",
                table: "Applications",
                newName: "IX_Applications_JobId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applications",
                table: "Applications",
                column: "ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_AspNetUsers_JobSeekerId",
                table: "Applications",
                column: "JobSeekerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Jobs_JobId",
                table: "Applications",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExtraData_Applications_ApplicationId",
                table: "ExtraData",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "ApplicationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_AspNetUsers_JobSeekerId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Jobs_JobId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_ExtraData_Applications_ApplicationId",
                table: "ExtraData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Applications",
                table: "Applications");

            migrationBuilder.RenameTable(
                name: "Applications",
                newName: "Application");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_JobSeekerId",
                table: "Application",
                newName: "IX_Application_JobSeekerId");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_JobId",
                table: "Application",
                newName: "IX_Application_JobId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Application",
                table: "Application",
                column: "ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_AspNetUsers_JobSeekerId",
                table: "Application",
                column: "JobSeekerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Application_Jobs_JobId",
                table: "Application",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExtraData_Application_ApplicationId",
                table: "ExtraData",
                column: "ApplicationId",
                principalTable: "Application",
                principalColumn: "ApplicationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
