using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetEnterprise.Infrastruture.Migrations
{
    /// <inheritdoc />
    public partial class PrimerEntidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Management");

            migrationBuilder.EnsureSchema(
                name: "Global");

            migrationBuilder.EnsureSchema(
                name: "Catalog");

            migrationBuilder.EnsureSchema(
                name: "Security");

            migrationBuilder.CreateTable(
                name: "Country",
                schema: "Global",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryCode = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    UTCdiff = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DateCreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreateUser = table.Column<int>(type: "int", nullable: false),
                    DateUpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdateUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "IndustryTypes",
                schema: "Global",
                columns: table => new
                {
                    IndustryTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndustryCode = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DateCreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreateUser = table.Column<int>(type: "int", nullable: false),
                    DateUpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdateUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndustryTypes", x => x.IndustryTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                schema: "Management",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessName = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    Street = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    ExteriorNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    InteriorNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Neighborhood = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    Locality = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    Municipality = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    State = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    ZipCode = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Country = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    TaxId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    PrimaryPhone = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    SecondaryPhone = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    ErpSystemCode = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    IndustryTypeId = table.Column<int>(type: "int", nullable: true),
                    CompanyTitle = table.Column<string>(type: "varchar(280)", unicode: false, maxLength: 280, nullable: true),
                    LegacyRecordId = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DateCreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreateUser = table.Column<int>(type: "int", nullable: false),
                    DateUpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdateUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                    table.ForeignKey(
                        name: "FK_Companies_IndustryTypes_IndustryTypeId",
                        column: x => x.IndustryTypeId,
                        principalSchema: "Global",
                        principalTable: "IndustryTypes",
                        principalColumn: "IndustryTypeId");
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                schema: "Management",
                columns: table => new
                {
                    BranchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false, defaultValue: ""),
                    CommercialName = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    BranchTypeId = table.Column<int>(type: "int", nullable: true),
                    AddressLine1 = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false, defaultValue: ""),
                    AddressLine2 = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    AddressSuburb = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false, defaultValue: ""),
                    AddressCity = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false, defaultValue: ""),
                    AddressMunicipality = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false, defaultValue: ""),
                    AddressState = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false, defaultValue: ""),
                    AddressPostalCode = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, defaultValue: ""),
                    AddressCountry = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false, defaultValue: "México"),
                    TaxIdentificationNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, defaultValue: ""),
                    PhoneNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, defaultValue: ""),
                    SecondaryPhoneNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    EmailAddress = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false, defaultValue: ""),
                    Website = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DateCreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreateUser = table.Column<int>(type: "int", nullable: false),
                    DateUpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdateUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.BranchId);
                    table.ForeignKey(
                        name: "FK_Branches_Companies",
                        column: x => x.CompanyId,
                        principalSchema: "Management",
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                schema: "Catalog",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DateCreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreateUser = table.Column<int>(type: "int", nullable: false),
                    DateUpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdateUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupId);
                    table.ForeignKey(
                        name: "FK_Group_Branch",
                        column: x => x.BranchId,
                        principalSchema: "Management",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "Security",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    RoleCode = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DateCreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreateUser = table.Column<int>(type: "int", nullable: false),
                    DateUpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdateUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                    table.ForeignKey(
                        name: "FK_Role_Branch",
                        column: x => x.BranchId,
                        principalSchema: "Management",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubGroups",
                schema: "Catalog",
                columns: table => new
                {
                    SubGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DateCreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreateUser = table.Column<int>(type: "int", nullable: false),
                    DateUpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdateUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubGroups", x => x.SubGroupId);
                    table.ForeignKey(
                        name: "FK_SubGroups_Branch",
                        column: x => x.BranchId,
                        principalSchema: "Management",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubGroups_Groups_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "Catalog",
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Security",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    UserAccount = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    PhoneNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    PrivacyAccepted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    AcceptanceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChangePasswordRequest = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    PrivacyPolicyId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    RefreshToken = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PasswordRecoveryToken = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IncorrectPasswordAttempts = table.Column<int>(type: "int", nullable: true),
                    BlockedToDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DateCreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreateUser = table.Column<int>(type: "int", nullable: false),
                    DateUpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdateUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_Branch",
                        column: x => x.BranchId,
                        principalSchema: "Management",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Country_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Global",
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Role",
                        column: x => x.RoleId,
                        principalSchema: "Security",
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branches_BranchUid",
                schema: "Management",
                table: "Branches",
                column: "BranchUid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Branches_CompanyId",
                schema: "Management",
                table: "Branches",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CompanyUid",
                schema: "Management",
                table: "Companies",
                column: "CompanyUid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_IndustryTypeId",
                schema: "Management",
                table: "Companies",
                column: "IndustryTypeId");

            migrationBuilder.CreateIndex(
                name: "UQ_Companies_BusinessName",
                schema: "Management",
                table: "Companies",
                column: "BusinessName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Companies_TaxId",
                schema: "Management",
                table: "Companies",
                column: "TaxId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Country_CountryCode",
                schema: "Global",
                table: "Country",
                column: "CountryCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Group_Name",
                schema: "Catalog",
                table: "Groups",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_BranchId",
                schema: "Catalog",
                table: "Groups",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_BranchId",
                schema: "Security",
                table: "Role",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleCode",
                schema: "Security",
                table: "Role",
                column: "RoleCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Group_Name",
                schema: "Catalog",
                table: "SubGroups",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubGroups_BranchId",
                schema: "Catalog",
                table: "SubGroups",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_SubGroups_GroupId",
                schema: "Catalog",
                table: "SubGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_User_BranchId",
                schema: "Security",
                table: "User",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CountryId",
                schema: "Security",
                table: "User",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                schema: "Security",
                table: "User",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserAccount",
                schema: "Security",
                table: "User",
                column: "UserAccount",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubGroups",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "Groups",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Country",
                schema: "Global");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "Branches",
                schema: "Management");

            migrationBuilder.DropTable(
                name: "Companies",
                schema: "Management");

            migrationBuilder.DropTable(
                name: "IndustryTypes",
                schema: "Global");
        }
    }
}
