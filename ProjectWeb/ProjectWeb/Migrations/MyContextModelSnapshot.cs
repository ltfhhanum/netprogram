﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectWeb.Contexts;

#nullable disable

namespace ProjectWeb.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjectWeb.Models.Account", b =>
                {
                    b.Property<string>("EmployeeNik")
                        .HasColumnType("char(5)")
                        .HasColumnName("employee_nik");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("password");

                    b.HasKey("EmployeeNik");

                    b.ToTable("TB_M_Accounts");
                });

            modelBuilder.Entity("ProjectWeb.Models.AccountRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountNik")
                        .IsRequired()
                        .HasColumnType("char(5)")
                        .HasColumnName("account_nik");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    b.HasKey("Id");

                    b.HasIndex("AccountNik");

                    b.HasIndex("RoleId");

                    b.ToTable("TB_TR_AccountRoles");
                });

            modelBuilder.Entity("ProjectWeb.Models.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasColumnName("degree");

                    b.Property<decimal>("Gpa")
                        .HasColumnType("decimal(3,2)")
                        .HasColumnName("gpa");

                    b.Property<string>("Major")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("major");

                    b.Property<int>("UniversityId")
                        .HasColumnType("int")
                        .HasColumnName("university_id");

                    b.HasKey("Id");

                    b.HasIndex("UniversityId");

                    b.ToTable("TB_M_Educations");
                });

            modelBuilder.Entity("ProjectWeb.Models.Employee", b =>
                {
                    b.Property<string>("Nik")
                        .HasColumnType("char(5)")
                        .HasColumnName("nik");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime")
                        .HasColumnName("birthdate");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("first_name");

                    b.Property<int>("Gender")
                        .HasColumnType("int")
                        .HasColumnName("gender");

                    b.Property<DateTime>("HiringDate")
                        .HasColumnType("datetime")
                        .HasColumnName("hiring_date");

                    b.Property<string>("LastName")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("last_name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("phone_number");

                    b.HasKey("Nik");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("TB_M_Employees");
                });

            modelBuilder.Entity("ProjectWeb.Models.Profiling", b =>
                {
                    b.Property<string>("EmployeeNik")
                        .HasColumnType("char(5)")
                        .HasColumnName("employee_nik");

                    b.Property<int>("EducationId")
                        .HasColumnType("int")
                        .HasColumnName("education_id");

                    b.HasKey("EmployeeNik");

                    b.HasIndex("EducationId")
                        .IsUnique();

                    b.ToTable("TB_TR_Profilings");
                });

            modelBuilder.Entity("ProjectWeb.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("TB_M_Roles");
                });

            modelBuilder.Entity("ProjectWeb.Models.University", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("TB_M_Universities");
                });

            modelBuilder.Entity("ProjectWeb.Models.Account", b =>
                {
                    b.HasOne("ProjectWeb.Models.Employee", "Employees")
                        .WithOne("Accounts")
                        .HasForeignKey("ProjectWeb.Models.Account", "EmployeeNik")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("ProjectWeb.Models.AccountRole", b =>
                {
                    b.HasOne("ProjectWeb.Models.Account", "Accounts")
                        .WithMany("AccountRoles")
                        .HasForeignKey("AccountNik")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectWeb.Models.Role", "Roles")
                        .WithMany("AccountRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Accounts");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("ProjectWeb.Models.Education", b =>
                {
                    b.HasOne("ProjectWeb.Models.University", "Universities")
                        .WithMany("Educations")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Universities");
                });

            modelBuilder.Entity("ProjectWeb.Models.Profiling", b =>
                {
                    b.HasOne("ProjectWeb.Models.Education", "Educations")
                        .WithOne("Profilings")
                        .HasForeignKey("ProjectWeb.Models.Profiling", "EducationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectWeb.Models.Employee", "Employees")
                        .WithOne("Profilings")
                        .HasForeignKey("ProjectWeb.Models.Profiling", "EmployeeNik")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Educations");

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("ProjectWeb.Models.Account", b =>
                {
                    b.Navigation("AccountRoles");
                });

            modelBuilder.Entity("ProjectWeb.Models.Education", b =>
                {
                    b.Navigation("Profilings")
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectWeb.Models.Employee", b =>
                {
                    b.Navigation("Accounts")
                        .IsRequired();

                    b.Navigation("Profilings")
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectWeb.Models.Role", b =>
                {
                    b.Navigation("AccountRoles");
                });

            modelBuilder.Entity("ProjectWeb.Models.University", b =>
                {
                    b.Navigation("Educations");
                });
#pragma warning restore 612, 618
        }
    }
}
