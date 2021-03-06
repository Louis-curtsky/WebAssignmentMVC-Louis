// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAssignmentMVC.Models.Person.Data;

namespace WebAssignmentMVC.Migrations
{
    [DbContext(typeof(PersonDBContext))]
    [Migration("20220607155837_CreateInitial")]
    partial class CreateInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "30c9d4cc-0e4c-49dc-bac2-07f5b75efc21",
                            ConcurrencyStamp = "30c9d4cc-0e4c-49dc-bac2-07f5b75efc21",
                            Name = "SuperAdmin",
                            NormalizedName = "SuperAdmin"
                        },
                        new
                        {
                            Id = "3f14719d-9036-40e7-b305-c6175c1b06a4",
                            ConcurrencyStamp = "3f14719d-9036-40e7-b305-c6175c1b06a4",
                            Name = "Admin",
                            NormalizedName = "Admin"
                        },
                        new
                        {
                            Id = "08ef6793-5b5d-441a-badf-d4e0d13d0499",
                            ConcurrencyStamp = "08ef6793-5b5d-441a-badf-d4e0d13d0499",
                            Name = "User",
                            NormalizedName = "User"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "697c154b-04a9-4885-aabe-99cfae2c88b4",
                            RoleId = "30c9d4cc-0e4c-49dc-bac2-07f5b75efc21"
                        },
                        new
                        {
                            UserId = "42e39f6e-e934-4f4e-90c7-c00838270c54",
                            RoleId = "3f14719d-9036-40e7-b305-c6175c1b06a4"
                        },
                        new
                        {
                            UserId = "f2e4b216-f563-4daa-9dc7-55c9986e1de0",
                            RoleId = "08ef6793-5b5d-441a-badf-d4e0d13d0499"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("WebAssignmentMVC.Models.Identity.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("UserRolesId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "697c154b-04a9-4885-aabe-99cfae2c88b4",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "186f7754-342a-4176-a351-0440bd348d11",
                            DateOfBirth = new DateTime(2022, 6, 7, 17, 58, 37, 646, DateTimeKind.Local).AddTicks(1559),
                            Email = "superadmin@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Louis",
                            LastName = "Lim",
                            LockoutEnabled = false,
                            NormalizedUserName = "SUPERADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEFZFsRP3lTB38x2vO0P6tVew2IqDCuP5OFFhKQM+n+2LLyaUTu+dtfmYL2rVT4EZtw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "d65fe6a5-2c33-45cb-97e6-5efbd2accb1b",
                            TwoFactorEnabled = false,
                            UserName = "SuperAdmin",
                            UserRolesId = "30c9d4cc-0e4c-49dc-bac2-07f5b75efc21"
                        },
                        new
                        {
                            Id = "42e39f6e-e934-4f4e-90c7-c00838270c54",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "10e034ca-fcdb-4595-8877-3f9906c9ffa0",
                            DateOfBirth = new DateTime(2022, 6, 7, 17, 58, 37, 649, DateTimeKind.Local).AddTicks(1048),
                            Email = "admin@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Vicient",
                            LastName = "Hook",
                            LockoutEnabled = false,
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEGjKX4kHm7Z14wb9hLuyppuFH4liLuVJlcUx+tntFB5mK509G/MW2oTtoiM1CF3Tdw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "fa8bf5e1-bdb6-44c8-96f0-7320995e854e",
                            TwoFactorEnabled = false,
                            UserName = "Admin",
                            UserRolesId = "3f14719d-9036-40e7-b305-c6175c1b06a4"
                        },
                        new
                        {
                            Id = "f2e4b216-f563-4daa-9dc7-55c9986e1de0",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "099cb883-f879-4f5d-a759-35882cd2d7ad",
                            DateOfBirth = new DateTime(2022, 6, 7, 17, 58, 37, 650, DateTimeKind.Local).AddTicks(5729),
                            Email = "user1@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Vicient",
                            LastName = "Kent",
                            LockoutEnabled = false,
                            NormalizedUserName = "USER1",
                            PasswordHash = "AQAAAAEAACcQAAAAEHxwkj+Fi5Zz/Rb6sLhWqfHfJ0OeopRrOrVQ4eZyCluF5ORPlTI6Y8Of2UB4m0Pfcg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "41114678-f72e-4fda-a209-a282c2c15ded",
                            TwoFactorEnabled = false,
                            UserName = "User1",
                            UserRolesId = "08ef6793-5b5d-441a-badf-d4e0d13d0499"
                        });
                });

            modelBuilder.Entity("WebAssignmentMVC.Models.Person.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryFiD")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryFiD");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryFiD = 1,
                            Name = "Stockholm"
                        },
                        new
                        {
                            Id = 2,
                            CountryFiD = 1,
                            Name = "Helsingborg"
                        },
                        new
                        {
                            Id = 3,
                            CountryFiD = 1,
                            Name = "Växjö"
                        },
                        new
                        {
                            Id = 4,
                            CountryFiD = 1,
                            Name = "Gävle"
                        },
                        new
                        {
                            Id = 5,
                            CountryFiD = 1,
                            Name = "Trollhättan"
                        },
                        new
                        {
                            Id = 6,
                            CountryFiD = 3,
                            Name = "Berlin"
                        },
                        new
                        {
                            Id = 7,
                            CountryFiD = 3,
                            Name = "Hamburg"
                        },
                        new
                        {
                            Id = 8,
                            CountryFiD = 3,
                            Name = "Munich"
                        });
                });

            modelBuilder.Entity("WebAssignmentMVC.Models.Person.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cname = "Sweden"
                        },
                        new
                        {
                            Id = 2,
                            Cname = "France"
                        },
                        new
                        {
                            Id = 3,
                            Cname = "Germany"
                        });
                });

            modelBuilder.Entity("WebAssignmentMVC.Models.Person.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LangName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Language");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LangName = "Swedish"
                        },
                        new
                        {
                            Id = 2,
                            LangName = "English"
                        },
                        new
                        {
                            Id = 3,
                            LangName = "Chinese"
                        });
                });

            modelBuilder.Entity("WebAssignmentMVC.Models.Person.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<int>("CtyId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            CtyId = 1,
                            FirstName = "Louis",
                            LastName = "Lim",
                            Phone = "0765551111"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 1,
                            CtyId = 2,
                            FirstName = "Michael",
                            LastName = "Kent",
                            Phone = "0733338888"
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 1,
                            CtyId = 3,
                            FirstName = "Åsa",
                            LastName = "Jason",
                            Phone = "0721231234"
                        },
                        new
                        {
                            Id = 4,
                            CountryId = 2,
                            CtyId = 0,
                            FirstName = "Andy",
                            LastName = "Birch",
                            Phone = "0744448888"
                        },
                        new
                        {
                            Id = 5,
                            CountryId = 2,
                            CtyId = 0,
                            FirstName = "Johnny",
                            LastName = "Walker",
                            Phone = "0751244674"
                        });
                });

            modelBuilder.Entity("WebAssignmentMVC.Models.Person.PersonLanguage", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.HasKey("PersonId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.ToTable("PersonLanguage");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WebAssignmentMVC.Models.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WebAssignmentMVC.Models.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAssignmentMVC.Models.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("WebAssignmentMVC.Models.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebAssignmentMVC.Models.Person.City", b =>
                {
                    b.HasOne("WebAssignmentMVC.Models.Person.Country", "Countries")
                        .WithMany("Cities")
                        .HasForeignKey("CountryFiD")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebAssignmentMVC.Models.Person.Person", b =>
                {
                    b.HasOne("WebAssignmentMVC.Models.Person.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebAssignmentMVC.Models.Person.PersonLanguage", b =>
                {
                    b.HasOne("WebAssignmentMVC.Models.Person.Language", "Language")
                        .WithMany("personLanguage")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAssignmentMVC.Models.Person.Person", "Person")
                        .WithMany("languageSpoken")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
