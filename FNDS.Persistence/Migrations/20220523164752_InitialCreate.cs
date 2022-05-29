using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FNDS.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountBalance = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nchar(2)", fixedLength: true, maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Domains",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(127)", maxLength: 127, nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAutoRenew = table.Column<bool>(type: "bit", nullable: false),
                    IsDomainPrivacy = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Domains_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserContacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DefaultYN = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Specifies whether this particular set of contacts should be set as PRIMARY for the account"),
                    EmailAddress = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Organization = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    City = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    StateProvince = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    StateProvinceChoice = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Zip = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Phone number in the format +NNN.NNNNNNNNNN"),
                    PhoneExt = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "Fax number in the format +NNN.NNNNNNNNNN"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserContacts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserContacts_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DomainContacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    JobTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StateProvince = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StateProvinceChoice = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Phone number in the format +NNN.NNNNNNNNNN"),
                    PhoneExt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Fax number in the format +NNN.NNNNNNNNNN"),
                    EmailAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ContactsType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    DomainId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DomainContacts_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DomainContacts_Domains_DomainId",
                        column: x => x.DomainId,
                        principalTable: "Domains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "FullName" },
                values: new object[,]
                {
                    { 1, "AF", "Afghanistan" },
                    { 2, "AL", "Albania" },
                    { 3, "DZ", "Algeria" },
                    { 4, "AS", "American Samoa" },
                    { 5, "AD", "Andorra" },
                    { 6, "AO", "Angola" },
                    { 7, "AI", "Anguilla" },
                    { 8, "AQ", "Antarctica" },
                    { 9, "AG", "Antigua and Barbuda" },
                    { 10, "AR", "Argentina" },
                    { 11, "AM", "Armenia" },
                    { 12, "AW", "Aruba" },
                    { 13, "AU", "Australia" },
                    { 14, "AT", "Austria" },
                    { 15, "AZ", "Azerbaijan" },
                    { 16, "BS", "Bahamas" },
                    { 17, "BH", "Bahrain" },
                    { 18, "BD", "Bangladesh" },
                    { 19, "BB", "Barbados" },
                    { 20, "BY", "Belarus" },
                    { 21, "BE", "Belgium" },
                    { 22, "BZ", "Belize" },
                    { 23, "BJ", "Benin" },
                    { 24, "BM", "Bermuda" },
                    { 25, "BT", "Bhutan" },
                    { 26, "BO", "Bolivia" },
                    { 27, "BA", "Bosnia and Herzegovina" },
                    { 28, "BW", "Botswana" },
                    { 29, "BV", "Bouvet Island" },
                    { 30, "BR", "Brazil" },
                    { 31, "BN", "Brunei Darussalam" },
                    { 32, "BG", "Bulgaria" },
                    { 33, "BF", "Burkina Faso" },
                    { 34, "BI", "Burundi" },
                    { 35, "KH", "Cambodia" },
                    { 36, "CM", "Cameroon" },
                    { 37, "CA", "Canada" },
                    { 38, "CV", "Cape Verde" },
                    { 39, "KY", "Cayman Islands" },
                    { 40, "CF", "Central African Republic" },
                    { 41, "TD", "Chad" },
                    { 42, "CL", "Chile" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "FullName" },
                values: new object[,]
                {
                    { 43, "CN", "China" },
                    { 44, "CX", "Christmas Island" },
                    { 45, "CC", "Cocos Islands" },
                    { 46, "CO", "Colombia" },
                    { 47, "KM", "Comoros" },
                    { 48, "CD", "Congo" },
                    { 49, "CK", "Cook Islands" },
                    { 50, "CR", "Costa Rica" },
                    { 51, "CI", "Cote D'Ivoire" },
                    { 52, "HR", "Croatia" },
                    { 53, "CW", "Curacao" },
                    { 54, "CY", "Cyprus" },
                    { 55, "CZ", "Czech Republic" },
                    { 56, "DK", "Denmark" },
                    { 57, "DJ", "Djibouti" },
                    { 58, "DM", "Dominica" },
                    { 59, "DO", "Dominican Republic" },
                    { 60, "TL", "East Timor" },
                    { 61, "EC", "Ecuador" },
                    { 62, "EG", "Egypt" },
                    { 63, "SV", "El Salvador" },
                    { 64, "CQ", "Equatorial Guinea" },
                    { 65, "ER", "Eritrea" },
                    { 66, "EE", "Estonia" },
                    { 67, "ET", "Ethiopia" },
                    { 68, "FK", "Falkland Islands" },
                    { 69, "FO", "Faroe Islands" },
                    { 70, "FJ", "Fiji" },
                    { 71, "FI", "Finland" },
                    { 72, "FR", "France" },
                    { 73, "GF", "French Guiana" },
                    { 74, "PF", "French Polynesia" },
                    { 75, "GA", "Gabon" },
                    { 76, "GM", "Gambia" },
                    { 77, "GE", "Georgia" },
                    { 78, "DE", "Germany" },
                    { 79, "GH", "Ghana" },
                    { 80, "GI", "Gibraltar" },
                    { 81, "GR", "Greece" },
                    { 82, "GL", "Greenland" },
                    { 83, "GD", "Grenada" },
                    { 84, "GP", "Guadeloupe" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "FullName" },
                values: new object[,]
                {
                    { 85, "GU", "Guam" },
                    { 86, "GT", "Guatemala" },
                    { 87, "GG", "Guernsey" },
                    { 88, "GN", "Guinea" },
                    { 89, "GW", "Guinea-Bissau" },
                    { 90, "GY", "Guyana" },
                    { 91, "HT", "Haiti" },
                    { 92, "HN", "Honduras" },
                    { 93, "HK", "Hong Kong" },
                    { 94, "HU", "Hungary" },
                    { 95, "IS", "Iceland" },
                    { 96, "IN", "India" },
                    { 97, "ID", "Indonesia" },
                    { 98, "IR", "Iraq" },
                    { 99, "IE", "Ireland" },
                    { 100, "IM", "Isle of Man" },
                    { 101, "IL", "Israel" },
                    { 102, "IT", "Italy" },
                    { 103, "JP", "Japan" },
                    { 104, "JE", "Jersey" },
                    { 105, "JO", "Jordan" },
                    { 106, "KZ", "Kazakhstan" },
                    { 107, "KE", "Kenya" },
                    { 108, "KI", "Kiribati" },
                    { 109, "KW", "Kuwait" },
                    { 110, "KG", "Kyrgyzstan" },
                    { 111, "LA", "Laos" },
                    { 112, "LV", "Latvia" },
                    { 113, "LB", "Lebanon" },
                    { 114, "LS", "Lesotho" },
                    { 115, "LR", "Liberia" },
                    { 116, "LY", "Libya" },
                    { 117, "LI", "Liechtenstein" },
                    { 118, "LT", "Lithuania" },
                    { 119, "LU", "Luxembourg" },
                    { 120, "MO", "Macau" },
                    { 121, "MK", "Macedonia" },
                    { 122, "MG", "Madagascar" },
                    { 123, "MW", "Malawi" },
                    { 124, "MY", "Malaysia" },
                    { 125, "MV", "Maldives" },
                    { 126, "ML", "Mali" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "FullName" },
                values: new object[,]
                {
                    { 127, "MT", "Malta" },
                    { 128, "MH", "Marshall Islands" },
                    { 129, "MQ", "Martinique" },
                    { 130, "MR", "Mauritania" },
                    { 131, "MU", "Mauritius" },
                    { 132, "YT", "Mayotte" },
                    { 133, "MX", "Mexico" },
                    { 134, "FM", "Micronesia" },
                    { 135, "MD", "Moldova" },
                    { 136, "MC", "Monaco" },
                    { 137, "MN", "Mongolia" },
                    { 138, "ME", "Montenegro" },
                    { 139, "MS", "Montserrat" },
                    { 140, "MA", "Morocco" },
                    { 141, "MZ", "Mozambique" },
                    { 142, "MM", "Myanmar" },
                    { 143, "NA", "Namibia" },
                    { 144, "NR", "Nauru" },
                    { 145, "NP", "Nepal" },
                    { 146, "NL", "Netherlands" },
                    { 147, "AN", "Netherlands Antilles" },
                    { 148, "NC", "New Caledonia" },
                    { 149, "NZ", "New Zealand" },
                    { 150, "NI", "Nicaragua" },
                    { 151, "NE", "Niger" },
                    { 152, "NG", "Nigeria" },
                    { 153, "NU", "Niue" },
                    { 154, "NF", "Norfolk Island" },
                    { 155, "MP", "Northern Mariana Isls" },
                    { 156, "NO", "Norway" },
                    { 157, "OM", "Oman" },
                    { 158, "PK", "Pakistan" },
                    { 159, "PW", "Palau" },
                    { 160, "PG", "Papua New Guinea" },
                    { 161, "PY", "Paraguay" },
                    { 162, "PE", "Peru" },
                    { 163, "PH", "Philippines" },
                    { 164, "PN", "Pitcairn" },
                    { 165, "PL", "Poland" },
                    { 166, "PT", "Portugal" },
                    { 167, "PR", "Puerto Rico" },
                    { 168, "QA", "Qatar" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "FullName" },
                values: new object[,]
                {
                    { 169, "RE", "Reunion" },
                    { 170, "RO", "Romania" },
                    { 171, "RW", "Rwanda" },
                    { 172, "KN", "Saint Kitts and Nevis" },
                    { 173, "LC", "Saint Lucia" },
                    { 174, "WS", "Samoa" },
                    { 175, "SM", "San Marino" },
                    { 176, "ST", "Sao Tome and Principe" },
                    { 177, "SA", "Saudi Arabia" },
                    { 178, "SN", "Senegal" },
                    { 179, "RS", "Serbia" },
                    { 180, "SC", "Seychelles" },
                    { 181, "SL", "Sierra Leone" },
                    { 182, "SG", "Singapore" },
                    { 183, "SK", "Slovak Republic" },
                    { 184, "SI", "Slovenia" },
                    { 185, "SB", "Solomon Islands" },
                    { 186, "SO", "Somalia" },
                    { 187, "ZA", "South Africa" },
                    { 188, "KR", "South Korea" },
                    { 189, "ES", "Spain" },
                    { 190, "LK", "Sri Lanka" },
                    { 191, "VC", "St. Vincent" },
                    { 192, "SH", "St. Helena" },
                    { 193, "PM", "St. Pierre and Miquelon" },
                    { 194, "SR", "Suriname" },
                    { 195, "SZ", "Swaziland" },
                    { 196, "SE", "Sweden" },
                    { 197, "CH", "Switzerland" },
                    { 198, "TW", "Taiwan" },
                    { 199, "TJ", "Tajikistan" },
                    { 200, "TZ", "Tanzania" },
                    { 201, "TH", "Thailand" },
                    { 202, "TG", "Togo" },
                    { 203, "TK", "Tokelau" },
                    { 204, "TO", "Tonga" },
                    { 205, "TT", "Trinidad and Tobago" },
                    { 206, "TN", "Tunisia" },
                    { 207, "TR", "Turkey" },
                    { 208, "TM", "Turkmenistan" },
                    { 209, "TC", "Turks and Caicos Islands" },
                    { 210, "TV", "Tuvalu" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "FullName" },
                values: new object[,]
                {
                    { 211, "UG", "Uganda" },
                    { 212, "UA", "Ukraine" },
                    { 213, "AE", "United Arab Emirates" },
                    { 214, "GB", "United Kingdom" },
                    { 215, "US", "United States" },
                    { 216, "UY", "Uruguay" },
                    { 217, "UZ", "Uzbekistan" },
                    { 218, "VU", "Vanuatu" },
                    { 219, "VA", "Vatican" },
                    { 220, "VE", "Venezuela" },
                    { 221, "VN", "Vietnam" },
                    { 222, "WF", "Wallis and Futuna Isls" },
                    { 223, "EH", "Western Sahara" },
                    { 224, "YE", "Yemen" },
                    { 225, "ZR", "Zaire" },
                    { 226, "ZM", "Zambia" },
                    { 227, "ZW", "Zimbabwe" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Code",
                table: "Countries",
                column: "Code",
                unique: true)
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_FullName",
                table: "Countries",
                column: "FullName")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_DomainContacts_CountryId",
                table: "DomainContacts",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_DomainContacts_DomainId",
                table: "DomainContacts",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_Domains_UserId",
                table: "Domains",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserContacts_CountryId",
                table: "UserContacts",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserContacts_UserId",
                table: "UserContacts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DomainContacts");

            migrationBuilder.DropTable(
                name: "UserContacts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Domains");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
