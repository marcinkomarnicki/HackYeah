﻿// <auto-generated />
using System;
using HackYeah.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HackYeah.Migrations
{
    [DbContext(typeof(HackYeahDbContext))]
    [Migration("20230930221215_isSearchable")]
    partial class isSearchable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HackYeah.DAL.Models.Demo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("value");

                    b.HasKey("Id")
                        .HasName("pk_demos");

                    b.ToTable("demos", (string)null);
                });

            modelBuilder.Entity("HackYeah.DAL.Models.Encounter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("EncounterTypeId")
                        .HasColumnType("uuid")
                        .HasColumnName("encounter_type_id");

                    b.Property<bool>("IsWild")
                        .HasColumnType("boolean")
                        .HasColumnName("is_wild");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("numeric")
                        .HasColumnName("latitude");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("numeric")
                        .HasColumnName("longitude");

                    b.Property<DateTime>("TimeUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("time_utc");

                    b.HasKey("Id")
                        .HasName("pk_encounters");

                    b.HasIndex("EncounterTypeId")
                        .HasDatabaseName("ix_encounters_encounter_type_id");

                    b.ToTable("encounters", (string)null);
                });

            modelBuilder.Entity("HackYeah.DAL.Models.EncounterType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("code");

                    b.Property<bool>("IsSearchable")
                        .HasColumnType("boolean")
                        .HasColumnName("is_searchable");

                    b.HasKey("Id")
                        .HasName("pk_encounter_type");

                    b.ToTable("encounter_type", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("d7e923a8-6781-41b0-9929-005d8b0f01d5"),
                            Code = "Kot",
                            IsSearchable = true
                        },
                        new
                        {
                            Id = new Guid("13c2ca92-6a13-482a-8e0e-62bd6682127b"),
                            Code = "Pies",
                            IsSearchable = true
                        },
                        new
                        {
                            Id = new Guid("cdca0436-2ca1-4cde-8581-b6917333b84f"),
                            Code = "Dzik",
                            IsSearchable = false
                        });
                });

            modelBuilder.Entity("HackYeah.DAL.Models.EncounterTypeProperty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("ValueType")
                        .HasColumnType("integer")
                        .HasColumnName("value_type");

                    b.HasKey("Id")
                        .HasName("pk_encounter_type_property");

                    b.ToTable("encounter_type_property", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("6e81da60-5186-4983-a180-a0a357fb41f3"),
                            Name = "Zachowanie",
                            ValueType = 6
                        },
                        new
                        {
                            Id = new Guid("db69c2dd-da68-43b8-9194-19176be90b62"),
                            Name = "Rasa",
                            ValueType = 0
                        },
                        new
                        {
                            Id = new Guid("bb8bcc84-164b-4978-a183-05ff505d096e"),
                            Name = "Obroża",
                            ValueType = 1
                        },
                        new
                        {
                            Id = new Guid("275e942d-8b0a-4c35-8fcf-88649ad67586"),
                            Name = "Kolor",
                            ValueType = 2
                        },
                        new
                        {
                            Id = new Guid("5b1c7bf6-93eb-4ecb-8d3d-5b588d931750"),
                            Name = "Czy jest w stadzie",
                            ValueType = 4
                        },
                        new
                        {
                            Id = new Guid("8d5ac209-3639-485d-8432-e01ffea199cb"),
                            Name = "Wielkość",
                            ValueType = 3
                        },
                        new
                        {
                            Id = new Guid("cb02f908-881a-47cc-85ab-1428d1816a43"),
                            Name = "Czy jest z młodymi",
                            ValueType = 5
                        });
                });

            modelBuilder.Entity("HackYeah.DAL.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer")
                        .HasColumnName("access_failed_count");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text")
                        .HasColumnName("concurrency_stamp");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("email");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean")
                        .HasColumnName("email_confirmed");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean")
                        .HasColumnName("lockout_enabled");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("lockout_end");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalized_email");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalized_user_name");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean")
                        .HasColumnName("phone_number_confirmed");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text")
                        .HasColumnName("security_stamp");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean")
                        .HasColumnName("two_factor_enabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("user_name");

                    b.HasKey("Id")
                        .HasName("pk_asp_net_users");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text")
                        .HasColumnName("concurrency_stamp");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("name");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalized_name");

                    b.HasKey("Id")
                        .HasName("pk_asp_net_roles");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text")
                        .HasColumnName("claim_value");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("role_id");

                    b.HasKey("Id")
                        .HasName("pk_asp_net_role_claims");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_asp_net_role_claims_role_id");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text")
                        .HasColumnName("claim_value");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_asp_net_user_claims");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_asp_net_user_claims_user_id");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text")
                        .HasColumnName("login_provider");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text")
                        .HasColumnName("provider_key");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text")
                        .HasColumnName("provider_display_name");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.HasKey("LoginProvider", "ProviderKey")
                        .HasName("pk_asp_net_user_logins");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_asp_net_user_logins_user_id");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.Property<string>("RoleId")
                        .HasColumnType("text")
                        .HasColumnName("role_id");

                    b.HasKey("UserId", "RoleId")
                        .HasName("pk_asp_net_user_roles");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_asp_net_user_roles_role_id");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text")
                        .HasColumnName("login_provider");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Value")
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.HasKey("UserId", "LoginProvider", "Name")
                        .HasName("pk_asp_net_user_tokens");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("encounter_type_properties_encounter_types", b =>
                {
                    b.Property<Guid>("encounter_type_id")
                        .HasColumnType("uuid")
                        .HasColumnName("encounter_type_id");

                    b.Property<Guid>("encounter_type_property_id")
                        .HasColumnType("uuid")
                        .HasColumnName("encounter_type_property_id");

                    b.HasKey("encounter_type_id", "encounter_type_property_id")
                        .HasName("pk_encounter_type_properties_encounter_types");

                    b.HasIndex("encounter_type_property_id")
                        .HasDatabaseName("ix_encounter_type_properties_encounter_types_encounter_type_pr");

                    b.ToTable("encounter_type_properties_encounter_types", (string)null);

                    b.HasData(
                        new
                        {
                            encounter_type_id = new Guid("d7e923a8-6781-41b0-9929-005d8b0f01d5"),
                            encounter_type_property_id = new Guid("bb8bcc84-164b-4978-a183-05ff505d096e")
                        },
                        new
                        {
                            encounter_type_id = new Guid("d7e923a8-6781-41b0-9929-005d8b0f01d5"),
                            encounter_type_property_id = new Guid("db69c2dd-da68-43b8-9194-19176be90b62")
                        },
                        new
                        {
                            encounter_type_id = new Guid("d7e923a8-6781-41b0-9929-005d8b0f01d5"),
                            encounter_type_property_id = new Guid("275e942d-8b0a-4c35-8fcf-88649ad67586")
                        },
                        new
                        {
                            encounter_type_id = new Guid("d7e923a8-6781-41b0-9929-005d8b0f01d5"),
                            encounter_type_property_id = new Guid("6e81da60-5186-4983-a180-a0a357fb41f3")
                        },
                        new
                        {
                            encounter_type_id = new Guid("13c2ca92-6a13-482a-8e0e-62bd6682127b"),
                            encounter_type_property_id = new Guid("bb8bcc84-164b-4978-a183-05ff505d096e")
                        },
                        new
                        {
                            encounter_type_id = new Guid("13c2ca92-6a13-482a-8e0e-62bd6682127b"),
                            encounter_type_property_id = new Guid("db69c2dd-da68-43b8-9194-19176be90b62")
                        },
                        new
                        {
                            encounter_type_id = new Guid("13c2ca92-6a13-482a-8e0e-62bd6682127b"),
                            encounter_type_property_id = new Guid("275e942d-8b0a-4c35-8fcf-88649ad67586")
                        },
                        new
                        {
                            encounter_type_id = new Guid("13c2ca92-6a13-482a-8e0e-62bd6682127b"),
                            encounter_type_property_id = new Guid("6e81da60-5186-4983-a180-a0a357fb41f3")
                        },
                        new
                        {
                            encounter_type_id = new Guid("13c2ca92-6a13-482a-8e0e-62bd6682127b"),
                            encounter_type_property_id = new Guid("8d5ac209-3639-485d-8432-e01ffea199cb")
                        },
                        new
                        {
                            encounter_type_id = new Guid("cdca0436-2ca1-4cde-8581-b6917333b84f"),
                            encounter_type_property_id = new Guid("5b1c7bf6-93eb-4ecb-8d3d-5b588d931750")
                        },
                        new
                        {
                            encounter_type_id = new Guid("cdca0436-2ca1-4cde-8581-b6917333b84f"),
                            encounter_type_property_id = new Guid("cb02f908-881a-47cc-85ab-1428d1816a43")
                        },
                        new
                        {
                            encounter_type_id = new Guid("cdca0436-2ca1-4cde-8581-b6917333b84f"),
                            encounter_type_property_id = new Guid("6e81da60-5186-4983-a180-a0a357fb41f3")
                        });
                });

            modelBuilder.Entity("HackYeah.DAL.Models.Encounter", b =>
                {
                    b.HasOne("HackYeah.DAL.Models.EncounterType", "EncounterType")
                        .WithMany()
                        .HasForeignKey("EncounterTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_encounters_encounter_type_encounter_type_id");

                    b.Navigation("EncounterType");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_role_claims_asp_net_roles_role_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("HackYeah.DAL.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_user_claims_asp_net_users_user_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("HackYeah.DAL.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_user_logins_asp_net_users_user_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_user_roles_asp_net_roles_role_id");

                    b.HasOne("HackYeah.DAL.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_user_roles_asp_net_users_user_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("HackYeah.DAL.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_user_tokens_asp_net_users_user_id");
                });

            modelBuilder.Entity("encounter_type_properties_encounter_types", b =>
                {
                    b.HasOne("HackYeah.DAL.Models.EncounterType", null)
                        .WithMany()
                        .HasForeignKey("encounter_type_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_encounter_type_properties_encounter_types_encounter_type_en");

                    b.HasOne("HackYeah.DAL.Models.EncounterTypeProperty", null)
                        .WithMany()
                        .HasForeignKey("encounter_type_property_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_encounter_type_properties_encounter_types_encounter_type_pr");
                });
#pragma warning restore 612, 618
        }
    }
}
