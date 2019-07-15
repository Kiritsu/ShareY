﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ShareY.Database;

namespace ShareY.Database.Migrations
{
    [DbContext(typeof(ShareYContext))]
    partial class ShareYContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ShareY.Database.Models.Token", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("guid")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnName("user_id");

                    b.HasKey("Guid")
                        .HasName("key_token_guid");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasName("index_user_id");

                    b.ToTable("tokens");
                });

            modelBuilder.Entity("ShareY.Database.Models.Upload", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("AuthorId")
                        .IsRequired()
                        .HasColumnName("author_id");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnName("content_type");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<long>("DownloadCount")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("download_count")
                        .HasDefaultValue(0L);

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnName("file_name");

                    b.Property<bool>("Removed")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("removed")
                        .HasDefaultValue(false);

                    b.Property<bool>("Visible")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("visible")
                        .HasDefaultValue(true);

                    b.HasKey("Id")
                        .HasName("key_upload_id");

                    b.HasIndex("AuthorId");

                    b.ToTable("uploads");
                });

            modelBuilder.Entity("ShareY.Database.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<bool>("Disabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("disabled")
                        .HasDefaultValue(false);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email");

                    b.HasKey("Id")
                        .HasName("pk_user_id");

                    b.HasAlternateKey("Email")
                        .HasName("ak_user_email");

                    b.ToTable("users");
                });

            modelBuilder.Entity("ShareY.Database.Models.Token", b =>
                {
                    b.HasOne("ShareY.Database.Models.User", "User")
                        .WithOne("Token")
                        .HasForeignKey("ShareY.Database.Models.Token", "UserId")
                        .HasConstraintName("fkey_token_userid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShareY.Database.Models.Upload", b =>
                {
                    b.HasOne("ShareY.Database.Models.User", "Author")
                        .WithMany("Uploads")
                        .HasForeignKey("AuthorId")
                        .HasConstraintName("fkey_upload_authorid")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
