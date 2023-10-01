using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HackYeah.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: true),
                    security_stamp = table.Column<string>(type: "text", nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    phone_number_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    two_factor_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    lockout_end = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    lockout_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    access_failed_count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "demos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    value = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_demos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "encounter_type",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_searchable = table.Column<bool>(type: "boolean", nullable: false),
                    code = table.Column<string>(type: "text", nullable: false),
                    ai_label_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_encounter_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "encounter_type_property",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    value_type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_encounter_type_property", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role_id = table.Column<string>(type: "text", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_role_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_asp_net_role_claims_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "AspNetRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_asp_net_user_claims_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    provider_key = table.Column<string>(type: "text", nullable: false),
                    provider_display_name = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_logins", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "fk_asp_net_user_logins_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "text", nullable: false),
                    role_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_roles", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "fk_asp_net_user_roles_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "AspNetRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_asp_net_user_roles_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "text", nullable: false),
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_tokens", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "fk_asp_net_user_tokens_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "encounters",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    longitude = table.Column<decimal>(type: "numeric", nullable: false),
                    latitude = table.Column<decimal>(type: "numeric", nullable: false),
                    time_utc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    encounter_type_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_encounters", x => x.id);
                    table.ForeignKey(
                        name: "fk_encounters_encounter_type_encounter_type_id",
                        column: x => x.encounter_type_id,
                        principalTable: "encounter_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "missing_pets_reports",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    encounter_type_id = table.Column<Guid>(type: "uuid", nullable: false),
                    rase = table.Column<string>(type: "text", nullable: false),
                    pet_name = table.Column<string>(type: "text", nullable: false),
                    reporter_name = table.Column<string>(type: "text", nullable: false),
                    telephone_number = table.Column<string>(type: "text", nullable: false),
                    longitude_report = table.Column<decimal>(type: "numeric", nullable: false),
                    latitude_report = table.Column<decimal>(type: "numeric", nullable: false),
                    has_collar = table.Column<bool>(type: "boolean", nullable: false),
                    special_features = table.Column<string>(type: "text", nullable: false),
                    color = table.Column<string>(type: "text", nullable: false),
                    pet_size = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_missing_pets_reports", x => x.id);
                    table.ForeignKey(
                        name: "fk_missing_pets_reports_encounter_type_encounter_type_id",
                        column: x => x.encounter_type_id,
                        principalTable: "encounter_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "encounter_type_properties_encounter_types",
                columns: table => new
                {
                    encounter_type_id = table.Column<Guid>(type: "uuid", nullable: false),
                    encounter_type_property_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_encounter_type_properties_encounter_types", x => new { x.encounter_type_id, x.encounter_type_property_id });
                    table.ForeignKey(
                        name: "fk_encounter_type_properties_encounter_types_encounter_type_en",
                        column: x => x.encounter_type_id,
                        principalTable: "encounter_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_encounter_type_properties_encounter_types_encounter_type_pr",
                        column: x => x.encounter_type_property_id,
                        principalTable: "encounter_type_property",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "encounter_property",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    encounter_type_property_id = table.Column<Guid>(type: "uuid", nullable: false),
                    value = table.Column<string>(type: "text", nullable: false),
                    encounter_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_encounter_property", x => x.id);
                    table.ForeignKey(
                        name: "fk_encounter_property_encounter_type_property_encounter_type_p",
                        column: x => x.encounter_type_property_id,
                        principalTable: "encounter_type_property",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_encounter_property_encounters_encounter_id",
                        column: x => x.encounter_id,
                        principalTable: "encounters",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "missing_pets_report_images",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    mime_type = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    missing_pet_report_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_missing_pets_report_images", x => x.id);
                    table.ForeignKey(
                        name: "fk_missing_pets_report_images_missing_pets_reports_missing_pet",
                        column: x => x.missing_pet_report_id,
                        principalTable: "missing_pets_reports",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "encounter_type",
                columns: new[] { "id", "ai_label_id", "code", "is_searchable" },
                values: new object[,]
                {
                    { new Guid("13c2ca92-6a13-482a-8e0e-62bd6682127b"), 18, "Pies", true },
                    { new Guid("cdca0436-2ca1-4cde-8581-b6917333b84f"), 7, "Dzik", false },
                    { new Guid("d7e923a8-6781-41b0-9929-005d8b0f01d5"), 9, "Kot", true }
                });

            migrationBuilder.InsertData(
                table: "encounter_type_property",
                columns: new[] { "id", "name", "value_type" },
                values: new object[,]
                {
                    { new Guid("275e942d-8b0a-4c35-8fcf-88649ad67586"), "Kolor", 2 },
                    { new Guid("5b1c7bf6-93eb-4ecb-8d3d-5b588d931750"), "Czy jest w stadzie", 4 },
                    { new Guid("6e81da60-5186-4983-a180-a0a357fb41f3"), "Zachowanie", 6 },
                    { new Guid("8d5ac209-3639-485d-8432-e01ffea199cb"), "Wielkość", 3 },
                    { new Guid("bb8bcc84-164b-4978-a183-05ff505d096e"), "Obroża", 1 },
                    { new Guid("cb02f908-881a-47cc-85ab-1428d1816a43"), "Czy jest z młodymi", 5 },
                    { new Guid("db69c2dd-da68-43b8-9194-19176be90b62"), "Rasa", 0 }
                });

            migrationBuilder.InsertData(
                table: "encounter_type_properties_encounter_types",
                columns: new[] { "encounter_type_id", "encounter_type_property_id" },
                values: new object[,]
                {
                    { new Guid("13c2ca92-6a13-482a-8e0e-62bd6682127b"), new Guid("275e942d-8b0a-4c35-8fcf-88649ad67586") },
                    { new Guid("13c2ca92-6a13-482a-8e0e-62bd6682127b"), new Guid("6e81da60-5186-4983-a180-a0a357fb41f3") },
                    { new Guid("13c2ca92-6a13-482a-8e0e-62bd6682127b"), new Guid("8d5ac209-3639-485d-8432-e01ffea199cb") },
                    { new Guid("13c2ca92-6a13-482a-8e0e-62bd6682127b"), new Guid("bb8bcc84-164b-4978-a183-05ff505d096e") },
                    { new Guid("13c2ca92-6a13-482a-8e0e-62bd6682127b"), new Guid("db69c2dd-da68-43b8-9194-19176be90b62") },
                    { new Guid("cdca0436-2ca1-4cde-8581-b6917333b84f"), new Guid("5b1c7bf6-93eb-4ecb-8d3d-5b588d931750") },
                    { new Guid("cdca0436-2ca1-4cde-8581-b6917333b84f"), new Guid("6e81da60-5186-4983-a180-a0a357fb41f3") },
                    { new Guid("cdca0436-2ca1-4cde-8581-b6917333b84f"), new Guid("cb02f908-881a-47cc-85ab-1428d1816a43") },
                    { new Guid("d7e923a8-6781-41b0-9929-005d8b0f01d5"), new Guid("275e942d-8b0a-4c35-8fcf-88649ad67586") },
                    { new Guid("d7e923a8-6781-41b0-9929-005d8b0f01d5"), new Guid("6e81da60-5186-4983-a180-a0a357fb41f3") },
                    { new Guid("d7e923a8-6781-41b0-9929-005d8b0f01d5"), new Guid("bb8bcc84-164b-4978-a183-05ff505d096e") },
                    { new Guid("d7e923a8-6781-41b0-9929-005d8b0f01d5"), new Guid("db69c2dd-da68-43b8-9194-19176be90b62") }
                });

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_role_claims_role_id",
                table: "AspNetRoleClaims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "normalized_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_claims_user_id",
                table: "AspNetUserClaims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_logins_user_id",
                table: "AspNetUserLogins",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_roles_role_id",
                table: "AspNetUserRoles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "normalized_user_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_encounter_property_encounter_id",
                table: "encounter_property",
                column: "encounter_id");

            migrationBuilder.CreateIndex(
                name: "ix_encounter_property_encounter_type_property_id",
                table: "encounter_property",
                column: "encounter_type_property_id");

            migrationBuilder.CreateIndex(
                name: "ix_encounter_type_properties_encounter_types_encounter_type_pr",
                table: "encounter_type_properties_encounter_types",
                column: "encounter_type_property_id");

            migrationBuilder.CreateIndex(
                name: "ix_encounters_encounter_type_id",
                table: "encounters",
                column: "encounter_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_missing_pets_report_images_missing_pet_report_id",
                table: "missing_pets_report_images",
                column: "missing_pet_report_id");

            migrationBuilder.CreateIndex(
                name: "ix_missing_pets_reports_encounter_type_id",
                table: "missing_pets_reports",
                column: "encounter_type_id");
        }

        /// <inheritdoc />
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
                name: "demos");

            migrationBuilder.DropTable(
                name: "encounter_property");

            migrationBuilder.DropTable(
                name: "encounter_type_properties_encounter_types");

            migrationBuilder.DropTable(
                name: "missing_pets_report_images");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "encounters");

            migrationBuilder.DropTable(
                name: "encounter_type_property");

            migrationBuilder.DropTable(
                name: "missing_pets_reports");

            migrationBuilder.DropTable(
                name: "encounter_type");
        }
    }
}
