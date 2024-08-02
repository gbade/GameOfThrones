﻿// <auto-generated />
using System;
using System.Collections.Generic;
using GameOfThrones.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GameOfThrones.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240801195710_UpdatedColumnsToLowerCase")]
    partial class UpdatedColumnsToLowerCase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GameOfThrones.Domain.Entities.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ActorLink")
                        .HasColumnType("text")
                        .HasColumnName("actorlink");

                    b.Property<string>("ActorName")
                        .HasColumnType("text")
                        .HasColumnName("actorname");

                    b.Property<string>("CharacterImageFull")
                        .HasColumnType("text")
                        .HasColumnName("characterimagefull");

                    b.Property<string>("CharacterImageThumb")
                        .HasColumnType("text")
                        .HasColumnName("characterimagethumb");

                    b.Property<string>("CharacterLink")
                        .HasColumnType("text")
                        .HasColumnName("characterlink");

                    b.Property<string>("CharacterName")
                        .HasColumnType("text")
                        .HasColumnName("charactername");

                    b.Property<string>("HouseName")
                        .HasColumnType("text")
                        .HasColumnName("housename");

                    b.Property<List<string>>("Killed")
                        .HasColumnType("text[]")
                        .HasColumnName("killed");

                    b.Property<List<string>>("KilledBy")
                        .HasColumnType("text[]")
                        .HasColumnName("killedby");

                    b.Property<string>("Nickname")
                        .HasColumnType("text")
                        .HasColumnName("nickname");

                    b.Property<List<string>>("Parents")
                        .HasColumnType("text[]")
                        .HasColumnName("parents");

                    b.Property<bool?>("Royal")
                        .HasColumnType("boolean")
                        .HasColumnName("royal");

                    b.Property<List<string>>("Siblings")
                        .HasColumnType("text[]")
                        .HasColumnName("siblings");

                    b.HasKey("Id");

                    b.ToTable("character", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}