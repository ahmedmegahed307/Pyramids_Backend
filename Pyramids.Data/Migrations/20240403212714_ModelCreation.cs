using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Pyramids.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModelCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AIUserInputAccuracyTrackings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessedByUserId = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    UserInput = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserInputIntent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserInputIntentConfidenceScore = table.Column<int>(type: "int", nullable: true),
                    Accuracy = table.Column<bool>(type: "bit", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AIUserInputAccuracyTrackings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssetManufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetManufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssetModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssetTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimaryContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryFinancialName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryFinancialEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VatRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VatNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VatValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    SiteType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobActionStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobActionStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobActionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobActionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    JobId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameOnDisk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SizeInBytes = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UploadedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobSessionId = table.Column<int>(type: "int", nullable: true),
                    LocalId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobSessionStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusCode = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSessionStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobSurveys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(type: "int", nullable: true),
                    Other = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponseTime = table.Column<int>(type: "int", nullable: true),
                    Punctuality = table.Column<int>(type: "int", nullable: true),
                    Quality = table.Column<int>(type: "int", nullable: true),
                    Courtesy = table.Column<int>(type: "int", nullable: true),
                    Overall = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSurveys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Priorities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priorities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StandardPrice = table.Column<double>(type: "float", nullable: false),
                    JobPrice = table.Column<double>(type: "float", nullable: false),
                    SerialControlled = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkDockets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkdocketCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkDockets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    AssetModelId = table.Column<int>(type: "int", nullable: false),
                    AssetManufacturerId = table.Column<int>(type: "int", nullable: false),
                    AssetTypeId = table.Column<int>(type: "int", nullable: false),
                    SiteId = table.Column<int>(type: "int", nullable: true),
                    TagNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assets_AssetManufacturers_AssetManufacturerId",
                        column: x => x.AssetManufacturerId,
                        principalTable: "AssetManufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assets_AssetModels_AssetModelId",
                        column: x => x.AssetModelId,
                        principalTable: "AssetModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assets_AssetTypes_AssetTypeId",
                        column: x => x.AssetTypeId,
                        principalTable: "AssetTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assets_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JobSubTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobTypeId = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSubTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobSubTypes_JobTypes_JobTypeId",
                        column: x => x.JobTypeId,
                        principalTable: "JobTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressLine1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    IsSendPostWorkSurvey = table.Column<bool>(type: "bit", nullable: true),
                    IsSignatureRequired = table.Column<bool>(type: "bit", nullable: true),
                    IsResolutionRequired = table.Column<bool>(type: "bit", nullable: true),
                    ClientPortalUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryIndustry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TermsAndConditions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VatNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTerm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Taxable = table.Column<bool>(type: "bit", nullable: true),
                    NormalWorkingHours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalHourlyRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OverTimeWorkingHours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OvertimeHourlyRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SchedulerEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    EventType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    EmployeesId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchedulerEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchedulerEvents_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sites_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sites_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Initials = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeneratedPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserRoleId = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PasswordChangedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResetPasswordKey = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ResetPasswordKeyValidToDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CultureInfoCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: true),
                    ConfirmationKey = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ConfirmationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SessionToken = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SessionTokenDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProfileLogoFilename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastDomainName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFirstLogin = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_UserRoles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    SiteId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contacts_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    JobTypeId = table.Column<int>(type: "int", nullable: true),
                    JobSubTypeId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultEngineerId = table.Column<int>(type: "int", nullable: true),
                    FrequencyType = table.Column<int>(type: "int", nullable: true),
                    FrequencyCount = table.Column<int>(type: "int", nullable: true),
                    BillingType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NextVisitDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstimatedDurationMinutes = table.Column<int>(type: "int", nullable: true),
                    ContractCharge = table.Column<double>(type: "float", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contracts_JobSubTypes_JobSubTypeId",
                        column: x => x.JobSubTypeId,
                        principalTable: "JobSubTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contracts_JobTypes_JobTypeId",
                        column: x => x.JobTypeId,
                        principalTable: "JobTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contracts_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contracts_Users_DefaultEngineerId",
                        column: x => x.DefaultEngineerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    ContactId = table.Column<int>(type: "int", nullable: true),
                    JobStatusId = table.Column<int>(type: "int", nullable: true),
                    JobTypeId = table.Column<int>(type: "int", nullable: true),
                    JobDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstimatedDuration = table.Column<int>(type: "int", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    CancelReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriorityId = table.Column<int>(type: "int", nullable: true),
                    ScheduleDateEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NotifyClient = table.Column<bool>(type: "bit", nullable: true),
                    CashOnDelivery = table.Column<bool>(type: "bit", nullable: true),
                    UniqueCode = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GetSurveySignature = table.Column<bool>(type: "bit", nullable: true),
                    IsGenerated = table.Column<bool>(type: "bit", nullable: true),
                    Instruction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    SiteId = table.Column<int>(type: "int", nullable: true),
                    EngineerId = table.Column<int>(type: "int", nullable: true),
                    TechComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobSubTypeId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Jobs_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Jobs_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Jobs_JobStatuses_JobStatusId",
                        column: x => x.JobStatusId,
                        principalTable: "JobStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Jobs_JobSubTypes_JobSubTypeId",
                        column: x => x.JobSubTypeId,
                        principalTable: "JobSubTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Jobs_JobTypes_JobTypeId",
                        column: x => x.JobTypeId,
                        principalTable: "JobTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Jobs_Priorities_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "Priorities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Jobs_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Jobs_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Jobs_Users_EngineerId",
                        column: x => x.EngineerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JobAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobAttachments_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobIssues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    JobSessionId = table.Column<int>(type: "int", nullable: true),
                    AssetId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Resolved = table.Column<bool>(type: "bit", nullable: true),
                    Resolution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobIssuePriority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobIssues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobIssues_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobIssues_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobParts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobParts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobParts_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobParts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JobSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    SiteId = table.Column<int>(type: "int", nullable: true),
                    JobId = table.Column<int>(type: "int", nullable: true),
                    SessionStatusId = table.Column<int>(type: "int", nullable: true),
                    EngineerAssignedId = table.Column<int>(type: "int", nullable: true),
                    ScheduleDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TravelStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TravelEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WorkStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WorkEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScheduleDateOrigin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TravelStartOrigin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TravelEndOrigin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WorkStartOrigin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WorkEndOrigin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsTraveling = table.Column<bool>(type: "bit", nullable: true),
                    IsWorking = table.Column<bool>(type: "bit", nullable: true),
                    LocalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TravelBackStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TravelBackEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobSessions_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobSessions_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobSessions_Users_EngineerAssignedId",
                        column: x => x.EngineerAssignedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractId = table.Column<int>(type: "int", nullable: true),
                    IsGenerated = table.Column<bool>(type: "bit", nullable: true),
                    VisitDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Invoiced = table.Column<bool>(type: "bit", nullable: true),
                    JobId = table.Column<int>(type: "int", nullable: true),
                    GeneratedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GeneratedByUserId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visits_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Visits_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Visits_Users_GeneratedByUserId",
                        column: x => x.GeneratedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JobActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobId = table.Column<int>(type: "int", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    JobActionTypeId = table.Column<int>(type: "int", nullable: true),
                    JobSessionId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobActions_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobActions_JobActionTypes_JobActionTypeId",
                        column: x => x.JobActionTypeId,
                        principalTable: "JobActionTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobActions_JobSessions_JobSessionId",
                        column: x => x.JobSessionId,
                        principalTable: "JobSessions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobActions_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobActions_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reminders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReminderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReminderType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngineerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReminderDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractId = table.Column<int>(type: "int", nullable: true),
                    JobId = table.Column<int>(type: "int", nullable: true),
                    VisitId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reminders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reminders_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reminders_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reminders_Visits_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Visits",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReminderSeens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReminderId = table.Column<int>(type: "int", nullable: true),
                    SeenByUserId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReminderSeens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReminderSeens_Reminders_ReminderId",
                        column: x => x.ReminderId,
                        principalTable: "Reminders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReminderSeens_Users_SeenByUserId",
                        column: x => x.SeenByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "AddressId", "ClientPortalUrl", "CreatedAt", "CreatedByUserId", "Currency", "Email", "Fax", "IsActive", "IsDeleted", "IsResolutionRequired", "IsSendPostWorkSurvey", "IsSignatureRequired", "LogoFileName", "LogoUrl", "Name", "NormalHourlyRate", "NormalWorkingHours", "OverTimeWorkingHours", "OvertimeHourlyRate", "PaymentTerm", "Phone", "PrimaryIndustry", "Taxable", "TermsAndConditions", "VatNumber", "WebsiteUrl" },
                values: new object[] { 1, null, null, new DateTimeOffset(new DateTime(2024, 4, 4, 0, 27, 14, 760, DateTimeKind.Unspecified).AddTicks(8017), new TimeSpan(0, 3, 0, 0, 0)), null, null, "support@pyramids.com", null, true, false, false, false, false, null, null, "Pyramids", null, null, null, null, null, null, null, false, null, null, null });

            migrationBuilder.InsertData(
                table: "JobActionStatuses",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "IsActive", "IsDeleted", "Status", "StatusCode" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2024, 4, 4, 0, 27, 14, 760, DateTimeKind.Unspecified).AddTicks(8391), new TimeSpan(0, 3, 0, 0, 0)), null, true, false, "Created via admin", "CREATED" },
                    { 2, new DateTimeOffset(new DateTime(2024, 4, 4, 0, 27, 14, 760, DateTimeKind.Unspecified).AddTicks(8397), new TimeSpan(0, 3, 0, 0, 0)), null, true, false, "Cancelled", "CANCELLED" },
                    { 3, new DateTimeOffset(new DateTime(2024, 4, 4, 0, 27, 14, 760, DateTimeKind.Unspecified).AddTicks(8398), new TimeSpan(0, 3, 0, 0, 0)), null, true, false, "Assigned", "ASSIGNED" },
                    { 4, new DateTimeOffset(new DateTime(2024, 4, 4, 0, 27, 14, 760, DateTimeKind.Unspecified).AddTicks(8400), new TimeSpan(0, 3, 0, 0, 0)), null, true, false, "Closed via admin", "CLOSED_ADMIN" },
                    { 5, new DateTimeOffset(new DateTime(2024, 4, 4, 0, 27, 14, 760, DateTimeKind.Unspecified).AddTicks(8401), new TimeSpan(0, 3, 0, 0, 0)), null, true, false, "Resolved via mobile", "RESOLVED_MOBILE" },
                    { 6, new DateTimeOffset(new DateTime(2024, 4, 4, 0, 27, 14, 760, DateTimeKind.Unspecified).AddTicks(8402), new TimeSpan(0, 3, 0, 0, 0)), null, true, false, "Travel started on mobile", "TRAVEL_STARTED" },
                    { 7, new DateTimeOffset(new DateTime(2024, 4, 4, 0, 27, 14, 760, DateTimeKind.Unspecified).AddTicks(8404), new TimeSpan(0, 3, 0, 0, 0)), null, true, false, "Travel cancelled on mobile", "TRAVEL_CANCELLED" },
                    { 8, new DateTimeOffset(new DateTime(2024, 4, 4, 0, 27, 14, 760, DateTimeKind.Unspecified).AddTicks(8405), new TimeSpan(0, 3, 0, 0, 0)), null, true, false, "Travel finished on mobile", "TRAVEL_FINISHED" },
                    { 9, new DateTimeOffset(new DateTime(2024, 4, 4, 0, 27, 14, 760, DateTimeKind.Unspecified).AddTicks(8406), new TimeSpan(0, 3, 0, 0, 0)), null, true, false, "Work started on mobile", "WORK_STARTED" },
                    { 10, new DateTimeOffset(new DateTime(2024, 4, 4, 0, 27, 14, 760, DateTimeKind.Unspecified).AddTicks(8407), new TimeSpan(0, 3, 0, 0, 0)), null, true, false, "Work stopped on mobile", "WORK_STOPPED" },
                    { 11, new DateTimeOffset(new DateTime(2024, 4, 4, 0, 27, 14, 760, DateTimeKind.Unspecified).AddTicks(8409), new TimeSpan(0, 3, 0, 0, 0)), null, true, false, "Travel started on mobile", "TRAVELBACK_STARTED" },
                    { 12, new DateTimeOffset(new DateTime(2024, 4, 4, 0, 27, 14, 760, DateTimeKind.Unspecified).AddTicks(8411), new TimeSpan(0, 3, 0, 0, 0)), null, true, false, "Travel cancelled on mobile", "TRAVELBACK_CANCELLED" },
                    { 13, new DateTimeOffset(new DateTime(2024, 4, 4, 0, 27, 14, 760, DateTimeKind.Unspecified).AddTicks(8412), new TimeSpan(0, 3, 0, 0, 0)), null, true, false, "Travel finished on mobile", "TRAVELBACK_FINISHED" },
                    { 15, new DateTimeOffset(new DateTime(2024, 4, 4, 0, 27, 14, 760, DateTimeKind.Unspecified).AddTicks(8414), new TimeSpan(0, 3, 0, 0, 0)), null, true, false, "Photo deleted", "PHOTO_DELETED" },
                    { 16, new DateTimeOffset(new DateTime(2024, 4, 4, 0, 27, 14, 760, DateTimeKind.Unspecified).AddTicks(8415), new TimeSpan(0, 3, 0, 0, 0)), null, true, false, "Client signature added", "SIGN_CLIENT_ADDED" },
                    { 17, new DateTimeOffset(new DateTime(2024, 4, 4, 0, 27, 14, 760, DateTimeKind.Unspecified).AddTicks(8416), new TimeSpan(0, 3, 0, 0, 0)), null, true, false, "Engineer signature added", "SIGN_ENG_ADDED" },
                    { 18, new DateTimeOffset(new DateTime(2024, 4, 4, 0, 27, 14, 760, DateTimeKind.Unspecified).AddTicks(8417), new TimeSpan(0, 3, 0, 0, 0)), null, true, false, "Client signature deleted", "SIGN_CLIENT_DELETED" },
                    { 19, new DateTimeOffset(new DateTime(2024, 4, 4, 0, 27, 14, 760, DateTimeKind.Unspecified).AddTicks(8418), new TimeSpan(0, 3, 0, 0, 0)), null, true, false, "Engineer signature deleted", "SIGN_ENG_DELETED" },
                    { 20, new DateTimeOffset(new DateTime(2024, 4, 4, 0, 27, 14, 760, DateTimeKind.Unspecified).AddTicks(8420), new TimeSpan(0, 3, 0, 0, 0)), null, true, false, "Part added", "PART_ADDED" },
                    { 21, new DateTimeOffset(new DateTime(2024, 4, 4, 0, 27, 14, 760, DateTimeKind.Unspecified).AddTicks(8421), new TimeSpan(0, 3, 0, 0, 0)), null, true, false, "Part deleted", "PART_DELETED" },
                    { 22, new DateTimeOffset(new DateTime(2024, 4, 4, 0, 27, 14, 760, DateTimeKind.Unspecified).AddTicks(8422), new TimeSpan(0, 3, 0, 0, 0)), null, true, false, "Edited and saved", "SAVED" },
                    { 23, new DateTimeOffset(new DateTime(2024, 4, 4, 0, 27, 14, 760, DateTimeKind.Unspecified).AddTicks(8423), new TimeSpan(0, 3, 0, 0, 0)), null, true, false, "Send Back To Assigned", "SEND_BACK_TO_ASSIGN" },
                    { 24, new DateTimeOffset(new DateTime(2024, 4, 4, 0, 27, 14, 760, DateTimeKind.Unspecified).AddTicks(8424), new TimeSpan(0, 3, 0, 0, 0)), null, true, false, "Send Back To Open", "SEND_BACK_TO_OPEN" },
                    { 25, new DateTimeOffset(new DateTime(2024, 4, 4, 0, 27, 14, 760, DateTimeKind.Unspecified).AddTicks(8425), new TimeSpan(0, 3, 0, 0, 0)), null, true, false, "Resolved via admin", "RESOLVED_ADMIN" },
                    { 26, new DateTimeOffset(new DateTime(2024, 4, 4, 0, 27, 14, 760, DateTimeKind.Unspecified).AddTicks(8427), new TimeSpan(0, 3, 0, 0, 0)), null, true, false, "Job edited", "EDIT_JOB" },
                    { 27, new DateTimeOffset(new DateTime(2024, 4, 4, 0, 27, 14, 760, DateTimeKind.Unspecified).AddTicks(8428), new TimeSpan(0, 3, 0, 0, 0)), null, true, false, "Attachment added", "ATTACHMENT_ADDED" },
                    { 28, new DateTimeOffset(new DateTime(2024, 4, 4, 0, 27, 14, 760, DateTimeKind.Unspecified).AddTicks(8429), new TimeSpan(0, 3, 0, 0, 0)), null, true, false, "Attachment deleted", "ATTACHMENT_DELETED" },
                    { 29, new DateTimeOffset(new DateTime(2024, 4, 4, 0, 27, 14, 760, DateTimeKind.Unspecified).AddTicks(8430), new TimeSpan(0, 3, 0, 0, 0)), null, true, false, "Job saved on mobile", "SAVED_ON_MOBILE" },
                    { 30, new DateTimeOffset(new DateTime(2024, 4, 4, 0, 27, 14, 760, DateTimeKind.Unspecified).AddTicks(8431), new TimeSpan(0, 3, 0, 0, 0)), null, true, false, "Created via mobile", "CREATED_MOBILE" },
                    { 31, new DateTimeOffset(new DateTime(2024, 4, 4, 0, 27, 14, 760, DateTimeKind.Unspecified).AddTicks(8432), new TimeSpan(0, 3, 0, 0, 0)), null, true, false, "Assigned via mobile", "ASSIGNED_MOBILE" },
                    { 33, new DateTimeOffset(new DateTime(2024, 4, 4, 0, 27, 14, 760, DateTimeKind.Unspecified).AddTicks(8434), new TimeSpan(0, 3, 0, 0, 0)), null, true, false, "Added Payment", "ADD_PAYMENT" },
                    { 34, new DateTimeOffset(new DateTime(2024, 4, 4, 0, 27, 14, 760, DateTimeKind.Unspecified).AddTicks(8435), new TimeSpan(0, 3, 0, 0, 0)), null, true, false, "Updated Payment", "UPDATE_PAYMENT" },
                    { 35, new DateTimeOffset(new DateTime(2024, 4, 4, 0, 27, 14, 760, DateTimeKind.Unspecified).AddTicks(8436), new TimeSpan(0, 3, 0, 0, 0)), null, true, false, "Pending Requested by Client", "PENDING_REQUEST" },
                    { 36, new DateTimeOffset(new DateTime(2024, 4, 4, 0, 27, 14, 760, DateTimeKind.Unspecified).AddTicks(8437), new TimeSpan(0, 3, 0, 0, 0)), null, true, false, "Work remote started", "WORK_REMOTE" },
                    { 37, new DateTimeOffset(new DateTime(2024, 4, 4, 0, 27, 14, 760, DateTimeKind.Unspecified).AddTicks(8438), new TimeSpan(0, 3, 0, 0, 0)), null, true, false, "Stop remote work", "STOP_REMOTE" },
                    { 38, new DateTimeOffset(new DateTime(2024, 4, 4, 0, 27, 14, 760, DateTimeKind.Unspecified).AddTicks(8439), new TimeSpan(0, 3, 0, 0, 0)), null, true, false, "Close remote work", "CLOSE_REMOTE" }
                });

            migrationBuilder.InsertData(
                table: "JobSessionStatuses",
                columns: new[] { "Id", "Status", "StatusCode" },
                values: new object[,]
                {
                    { 1, "NotStarted", "N" },
                    { 2, "Traveling", "T" },
                    { 3, "Working", "W" },
                    { 4, "StopWorking", "S" },
                    { 5, "Closed", "C" }
                });

            migrationBuilder.InsertData(
                table: "JobStatuses",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "A", "Assigned" },
                    { 2, "F", "Closed" },
                    { 3, "O", "Open" },
                    { 4, "P", "Pending" },
                    { 5, "R", "Resolved" },
                    { 6, "X", "Cancelled" }
                });

            migrationBuilder.InsertData(
                table: "JobTypes",
                columns: new[] { "Id", "CompanyId", "CreatedAt", "CreatedByUserId", "IsActive", "IsDeleted", "Name" },
                values: new object[] { 1, 0, new DateTimeOffset(new DateTime(2024, 4, 4, 0, 27, 14, 760, DateTimeKind.Unspecified).AddTicks(9214), new TimeSpan(0, 3, 0, 0, 0)), null, true, false, "Commissioning" });

            migrationBuilder.InsertData(
                table: "Priorities",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "h", "high" },
                    { 2, "m", "medium" },
                    { 3, "l", "low" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "IsActive", "IsDeleted", "Role" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2024, 4, 4, 0, 27, 14, 760, DateTimeKind.Unspecified).AddTicks(9393), new TimeSpan(0, 3, 0, 0, 0)), null, true, false, "Admin" },
                    { 2, new DateTimeOffset(new DateTime(2024, 4, 4, 0, 27, 14, 760, DateTimeKind.Unspecified).AddTicks(9398), new TimeSpan(0, 3, 0, 0, 0)), null, true, false, "Engineer" },
                    { 3, new DateTimeOffset(new DateTime(2024, 4, 4, 0, 27, 14, 760, DateTimeKind.Unspecified).AddTicks(9399), new TimeSpan(0, 3, 0, 0, 0)), null, true, false, "Client" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CreatedByUserId",
                table: "Address",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_AssetManufacturerId",
                table: "Assets",
                column: "AssetManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_AssetModelId",
                table: "Assets",
                column: "AssetModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_AssetTypeId",
                table: "Assets",
                column: "AssetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_ClientId",
                table: "Assets",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_AddressId",
                table: "Companies",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ClientId",
                table: "Contacts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_SiteId",
                table: "Contacts",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ClientId",
                table: "Contracts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_CreatedByUserId",
                table: "Contracts",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_DefaultEngineerId",
                table: "Contracts",
                column: "DefaultEngineerId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_JobSubTypeId",
                table: "Contracts",
                column: "JobSubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_JobTypeId",
                table: "Contracts",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobActions_ClientId",
                table: "JobActions",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_JobActions_CreatedByUserId",
                table: "JobActions",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_JobActions_JobActionTypeId",
                table: "JobActions",
                column: "JobActionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobActions_JobId",
                table: "JobActions",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobActions_JobSessionId",
                table: "JobActions",
                column: "JobSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_JobAttachments_JobId",
                table: "JobAttachments",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobIssues_AssetId",
                table: "JobIssues",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_JobIssues_JobId",
                table: "JobIssues",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobParts_JobId",
                table: "JobParts",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobParts_ProductId",
                table: "JobParts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_AddressId",
                table: "Jobs",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ClientId",
                table: "Jobs",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CompanyId",
                table: "Jobs",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ContactId",
                table: "Jobs",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CreatedByUserId",
                table: "Jobs",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_EngineerId",
                table: "Jobs",
                column: "EngineerId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_JobStatusId",
                table: "Jobs",
                column: "JobStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_JobSubTypeId",
                table: "Jobs",
                column: "JobSubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_JobTypeId",
                table: "Jobs",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_PriorityId",
                table: "Jobs",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_SiteId",
                table: "Jobs",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSessions_CreatedByUserId",
                table: "JobSessions",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSessions_EngineerAssignedId",
                table: "JobSessions",
                column: "EngineerAssignedId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSessions_JobId",
                table: "JobSessions",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSubTypes_JobTypeId",
                table: "JobSubTypes",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_CompanyId",
                table: "Notifications",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_CreatedByUserId",
                table: "Notifications",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reminders_ContractId",
                table: "Reminders",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Reminders_JobId",
                table: "Reminders",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Reminders_VisitId",
                table: "Reminders",
                column: "VisitId");

            migrationBuilder.CreateIndex(
                name: "IX_ReminderSeens_ReminderId",
                table: "ReminderSeens",
                column: "ReminderId");

            migrationBuilder.CreateIndex(
                name: "IX_ReminderSeens_SeenByUserId",
                table: "ReminderSeens",
                column: "SeenByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SchedulerEvents_CompanyId",
                table: "SchedulerEvents",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Sites_ClientId",
                table: "Sites",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Sites_CompanyId",
                table: "Sites",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddressId",
                table: "Users",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompanyId",
                table: "Users",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserId",
                table: "Users",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRoleId",
                table: "Users",
                column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_ContractId",
                table: "Visits",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_GeneratedByUserId",
                table: "Visits",
                column: "GeneratedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_JobId",
                table: "Visits",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Users_CreatedByUserId",
                table: "Address",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Users_CreatedByUserId",
                table: "Address");

            migrationBuilder.DropTable(
                name: "AIUserInputAccuracyTrackings");

            migrationBuilder.DropTable(
                name: "JobActions");

            migrationBuilder.DropTable(
                name: "JobActionStatuses");

            migrationBuilder.DropTable(
                name: "JobAttachments");

            migrationBuilder.DropTable(
                name: "JobFiles");

            migrationBuilder.DropTable(
                name: "JobIssues");

            migrationBuilder.DropTable(
                name: "JobParts");

            migrationBuilder.DropTable(
                name: "JobSessionStatuses");

            migrationBuilder.DropTable(
                name: "JobSurveys");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "ReminderSeens");

            migrationBuilder.DropTable(
                name: "SchedulerEvents");

            migrationBuilder.DropTable(
                name: "WorkDockets");

            migrationBuilder.DropTable(
                name: "JobActionTypes");

            migrationBuilder.DropTable(
                name: "JobSessions");

            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Reminders");

            migrationBuilder.DropTable(
                name: "AssetManufacturers");

            migrationBuilder.DropTable(
                name: "AssetModels");

            migrationBuilder.DropTable(
                name: "AssetTypes");

            migrationBuilder.DropTable(
                name: "Visits");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "JobStatuses");

            migrationBuilder.DropTable(
                name: "JobSubTypes");

            migrationBuilder.DropTable(
                name: "Priorities");

            migrationBuilder.DropTable(
                name: "Sites");

            migrationBuilder.DropTable(
                name: "JobTypes");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
