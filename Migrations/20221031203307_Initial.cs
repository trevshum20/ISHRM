using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ISHRM.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alerts",
                columns: table => new
                {
                    AlertID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AlertName = table.Column<string>(nullable: false),
                    Completed = table.Column<bool>(nullable: false),
                    StartAlert = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerts", x => x.AlertID);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseCode = table.Column<string>(nullable: true),
                    CourseName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseID);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    PositionID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PositionName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.PositionID);
                });

            migrationBuilder.CreateTable(
                name: "ProgramYears",
                columns: table => new
                {
                    ProgramID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProgramName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramYears", x => x.ProgramID);
                });

            migrationBuilder.CreateTable(
                name: "SemesterYears",
                columns: table => new
                {
                    SemesterYearID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SemesterName = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SemesterYears", x => x.SemesterYearID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    BYUID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NetID = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    International = table.Column<bool>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NameChange = table.Column<bool>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    BYUName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.BYUID);
                });

            migrationBuilder.CreateTable(
                name: "Supervisors",
                columns: table => new
                {
                    SupervisorID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SupervisorFirstName = table.Column<string>(nullable: false),
                    SupervisorLastName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supervisors", x => x.SupervisorID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    StudentEmploymentID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BYUID = table.Column<int>(nullable: false),
                    ExpectedHours = table.Column<int>(nullable: false),
                    SemesterYearID = table.Column<int>(nullable: false),
                    Semester_YearSemesterYearID = table.Column<int>(nullable: true),
                    PositionID = table.Column<int>(nullable: false),
                    CourseID = table.Column<int>(nullable: false),
                    EmplRecord = table.Column<int>(nullable: false),
                    SupervisorID = table.Column<int>(nullable: false),
                    HireDate = table.Column<DateTime>(nullable: false),
                    PayRate = table.Column<double>(nullable: false),
                    LastPayInc = table.Column<DateTime>(nullable: true),
                    LastPayIncAmount = table.Column<double>(nullable: true),
                    PayIncDate = table.Column<DateTime>(nullable: true),
                    ProgramID = table.Column<int>(nullable: false),
                    ProgramYearProgramID = table.Column<int>(nullable: true),
                    PayGradTuition = table.Column<bool>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    Terminated = table.Column<bool>(nullable: false),
                    TerminationStart = table.Column<DateTime>(nullable: true),
                    QualtricsSent = table.Column<DateTime>(nullable: true),
                    SubmittedEForm = table.Column<DateTime>(nullable: true),
                    AuthorizationToWorkRec = table.Column<DateTime>(nullable: true),
                    AuthorizationEmailSentDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.StudentEmploymentID);
                    table.ForeignKey(
                        name: "FK_Employees_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Positions_PositionID",
                        column: x => x.PositionID,
                        principalTable: "Positions",
                        principalColumn: "PositionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_ProgramYears_ProgramYearProgramID",
                        column: x => x.ProgramYearProgramID,
                        principalTable: "ProgramYears",
                        principalColumn: "ProgramID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_SemesterYears_Semester_YearSemesterYearID",
                        column: x => x.Semester_YearSemesterYearID,
                        principalTable: "SemesterYears",
                        principalColumn: "SemesterYearID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Supervisors_SupervisorID",
                        column: x => x.SupervisorID,
                        principalTable: "Supervisors",
                        principalColumn: "SupervisorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseID", "CourseCode", "CourseName" },
                values: new object[] { 1, "IS201", "Intro to IS Course" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseID", "CourseCode", "CourseName" },
                values: new object[] { 2, "IS303", "Javascript Programming" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseID", "CourseCode", "CourseName" },
                values: new object[] { 3, "IS110", "Excel Spreadsheets" });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "PositionID", "PositionName" },
                values: new object[] { 1, "RA" });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "PositionID", "PositionName" },
                values: new object[] { 2, "TA" });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "PositionID", "PositionName" },
                values: new object[] { 3, "Office" });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "PositionID", "PositionName" },
                values: new object[] { 4, "Student Instructor" });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "PositionID", "PositionName" },
                values: new object[] { 5, "Other" });

            migrationBuilder.InsertData(
                table: "ProgramYears",
                columns: new[] { "ProgramID", "ProgramName" },
                values: new object[] { 6, "Other" });

            migrationBuilder.InsertData(
                table: "ProgramYears",
                columns: new[] { "ProgramID", "ProgramName" },
                values: new object[] { 5, "MACC" });

            migrationBuilder.InsertData(
                table: "ProgramYears",
                columns: new[] { "ProgramID", "ProgramName" },
                values: new object[] { 4, "MPA" });

            migrationBuilder.InsertData(
                table: "ProgramYears",
                columns: new[] { "ProgramID", "ProgramName" },
                values: new object[] { 2, "MISM" });

            migrationBuilder.InsertData(
                table: "ProgramYears",
                columns: new[] { "ProgramID", "ProgramName" },
                values: new object[] { 1, "MSB Core" });

            migrationBuilder.InsertData(
                table: "ProgramYears",
                columns: new[] { "ProgramID", "ProgramName" },
                values: new object[] { 3, "MBA" });

            migrationBuilder.InsertData(
                table: "SemesterYears",
                columns: new[] { "SemesterYearID", "SemesterName", "Year" },
                values: new object[] { 4, "Summer", 2022 });

            migrationBuilder.InsertData(
                table: "SemesterYears",
                columns: new[] { "SemesterYearID", "SemesterName", "Year" },
                values: new object[] { 1, "Fall", 2021 });

            migrationBuilder.InsertData(
                table: "SemesterYears",
                columns: new[] { "SemesterYearID", "SemesterName", "Year" },
                values: new object[] { 2, "Winter", 2022 });

            migrationBuilder.InsertData(
                table: "SemesterYears",
                columns: new[] { "SemesterYearID", "SemesterName", "Year" },
                values: new object[] { 3, "Spring", 2022 });

            migrationBuilder.InsertData(
                table: "SemesterYears",
                columns: new[] { "SemesterYearID", "SemesterName", "Year" },
                values: new object[] { 5, "Fall", 2022 });

            migrationBuilder.InsertData(
                table: "Supervisors",
                columns: new[] { "SupervisorID", "SupervisorFirstName", "SupervisorLastName" },
                values: new object[] { 1, "Greg", "Anderson" });

            migrationBuilder.InsertData(
                table: "Supervisors",
                columns: new[] { "SupervisorID", "SupervisorFirstName", "SupervisorLastName" },
                values: new object[] { 2, "Gove", "Allen" });

            migrationBuilder.InsertData(
                table: "Supervisors",
                columns: new[] { "SupervisorID", "SupervisorFirstName", "SupervisorLastName" },
                values: new object[] { 3, "Jeff", "Jenkins" });

            migrationBuilder.InsertData(
                table: "Supervisors",
                columns: new[] { "SupervisorID", "SupervisorFirstName", "SupervisorLastName" },
                values: new object[] { 4, "Degan", "Kettles" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CourseID",
                table: "Employees",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionID",
                table: "Employees",
                column: "PositionID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ProgramYearProgramID",
                table: "Employees",
                column: "ProgramYearProgramID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Semester_YearSemesterYearID",
                table: "Employees",
                column: "Semester_YearSemesterYearID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SupervisorID",
                table: "Employees",
                column: "SupervisorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alerts");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "ProgramYears");

            migrationBuilder.DropTable(
                name: "SemesterYears");

            migrationBuilder.DropTable(
                name: "Supervisors");
        }
    }
}
