// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Serep.Uno.Model;

namespace Serep.Uno.Model.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20220705133039_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("Serep.Uno.Model.Reports", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("date");

                    b.Property<string>("note");

                    b.Property<int>("pp");

                    b.Property<int>("publications");

                    b.Property<int>("studys");

                    b.Property<TimeSpan>("time");

                    b.Property<int>("videos");

                    b.HasKey("id");

                    b.ToTable("reports");
                });
#pragma warning restore 612, 618
        }
    }
}
