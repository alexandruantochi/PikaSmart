﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Persistence.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20171212064152_AddedBaseDatabaseStructure")]
    partial class AddedBaseDatabaseStructure
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.TemperatureRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Time");

                    b.Property<Guid>("UserId");

                    b.Property<double>("Value");

                    b.HasKey("Id");

                    b.ToTable("TemperatureRecords");
                });
#pragma warning restore 612, 618
        }
    }
}
