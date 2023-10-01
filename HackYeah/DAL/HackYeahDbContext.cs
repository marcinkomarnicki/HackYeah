using HackYeah.Application.Enums;
using HackYeah.DAL.Models;
using HackYeah.Infrastructure.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace HackYeah.DAL
{
    public class HackYeahDbContext : IdentityDbContext<User>
    {
        private readonly string _connectionString;

        public HackYeahDbContext(DbContextOptions<HackYeahDbContext> options,
            IOptions<ConnectionStringsSection> connectionStringsOptions)
            : base(options)
        {
            _connectionString = connectionStringsOptions.Value.HackYeah;
        }

        public DbSet<Encounter> Encounters { get; set; }

        public DbSet<EncounterImage> EncounterImages { get; set; }

        public DbSet<EncounterType> EncounterType { get; set; }
        
        public DbSet<MissingPetReport> MissingPetsReports { get; set; }

        public DbSet<MissingPetReportImage> MissingPetsReportImages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString)
                .UseSnakeCaseNamingConvention();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Encounter>()
                .HasOne(x => x.EncounterType)
                .WithMany().HasForeignKey(x => x.EncounterTypeId);

            modelBuilder.Entity<EncounterType>()
                .HasMany(x => x.EncounterTypeProperties)
                .WithMany(x => x.EncounterTypes);
            
            modelBuilder.Entity<MissingPetReport>()
                .HasOne(x => x.EncounterType)
                .WithMany().HasForeignKey(x => x.EncounterTypeId);


            var encounterTypeKotId = new Guid("D7E923A8-6781-41B0-9929-005D8B0F01D5");
            var encounterTypePiesId = new Guid("13C2CA92-6A13-482A-8E0E-62BD6682127B");
            var encounterTypeDzikId = new Guid("CDCA0436-2CA1-4CDE-8581-B6917333B84F");
            
            var kot = new EncounterType
            {
                Id = encounterTypeKotId,
                Code = "Kot",
                IsSearchable = true,
                AiLabelId = 9
            };

            var pies = new EncounterType
            {
                Id = encounterTypePiesId,
                Code = "Pies",
                IsSearchable = true,
                AiLabelId = 18
            };
            
            var dzik = new EncounterType
            {
                Id = encounterTypeDzikId,
                Code = "Dzik",
                IsSearchable = false,
                AiLabelId = 7
            };
            //SEED
            modelBuilder.Entity<EncounterType>().HasData(
                kot,
                pies,
                dzik);


            var encounterTypePropertyAttitudeId = new Guid("6E81DA60-5186-4983-A180-A0A357FB41F3");
            var encounterTypePropertyBreedId = new Guid("DB69C2DD-DA68-43B8-9194-19176BE90B62");
            var encounterTypePropertyCollarId = new Guid("BB8BCC84-164B-4978-A183-05FF505D096E");
            var encounterTypePropertyColorId = new Guid("275E942D-8B0A-4C35-8FCF-88649AD67586");
            var encounterTypePropertyPackId = new Guid("5B1C7BF6-93EB-4ECB-8D3D-5B588D931750");
            var encounterTypePropertySizeId = new Guid("8D5AC209-3639-485D-8432-E01FFEA199CB");
            var encounterTypePropertyWithChildrenId = new Guid("CB02F908-881A-47CC-85AB-1428D1816A43");

            modelBuilder.Entity<EncounterTypeProperty>().HasData(
                new EncounterTypeProperty
                {
                    Id = encounterTypePropertyAttitudeId,
                    ValueType = EValueType.Attitude,
                    Name = "Zachowanie"
                },
                new EncounterTypeProperty
                {
                    Id = encounterTypePropertyBreedId,
                    ValueType = EValueType.Breed,
                    Name = "Rasa"
                },
                new EncounterTypeProperty
                {
                    Id = encounterTypePropertyCollarId,
                    ValueType = EValueType.Collar,
                    Name = "Obroża"
                },
                new EncounterTypeProperty
                {
                    Id = encounterTypePropertyColorId,
                    ValueType = EValueType.Color,
                    Name = "Kolor"
                },
                new EncounterTypeProperty
                {
                    Id = encounterTypePropertyPackId,
                    ValueType = EValueType.Pack,
                    Name = "Czy jest w stadzie"
                },
                new EncounterTypeProperty
                {
                    Id = encounterTypePropertySizeId,
                    ValueType = EValueType.Size,
                    Name = "Wielkość"
                },
                new EncounterTypeProperty
                {
                    Id = encounterTypePropertyWithChildrenId,
                    ValueType = EValueType.WithChildren,
                    Name = "Czy jest z młodymi"
                }
            );

            modelBuilder.Entity<EncounterType>()
                .HasMany(p => p.EncounterTypeProperties)
                .WithMany(t => t.EncounterTypes)
                .UsingEntity<Dictionary<string, object>>(
                    "encounter_type_properties_encounter_types",
                    r => r.HasOne<EncounterTypeProperty>().WithMany().HasForeignKey("encounter_type_property_id"),
                    l => l.HasOne<EncounterType>().WithMany().HasForeignKey("encounter_type_id"),
                    je =>
                    {
                        je.HasKey("encounter_type_id", "encounter_type_property_id");
                        je.HasData(
                            new
                            {
                                encounter_type_id = encounterTypeKotId,
                                encounter_type_property_id = encounterTypePropertyCollarId
                            },
                            new
                            {
                                encounter_type_id = encounterTypeKotId,
                                encounter_type_property_id = encounterTypePropertyBreedId
                            },
                            new
                            {
                                encounter_type_id = encounterTypeKotId,
                                encounter_type_property_id = encounterTypePropertyColorId
                            },
                            new
                            {
                                encounter_type_id = encounterTypeKotId,
                                encounter_type_property_id = encounterTypePropertyAttitudeId
                            },
                            new
                            {
                                encounter_type_id = encounterTypePiesId,
                                encounter_type_property_id = encounterTypePropertyCollarId
                            },
                            new
                            {
                                encounter_type_id = encounterTypePiesId,
                                encounter_type_property_id = encounterTypePropertyBreedId
                            },
                            new
                            {
                                encounter_type_id = encounterTypePiesId,
                                encounter_type_property_id = encounterTypePropertyColorId
                            },
                            new
                            {
                                encounter_type_id = encounterTypePiesId,
                                encounter_type_property_id = encounterTypePropertyAttitudeId
                            },
                            new
                            {
                                encounter_type_id = encounterTypePiesId,
                                encounter_type_property_id = encounterTypePropertySizeId
                            },
                            //dzik
                            new
                            {
                                encounter_type_id = encounterTypeDzikId,
                                encounter_type_property_id = encounterTypePropertyPackId
                            },
                            new
                            {
                                encounter_type_id = encounterTypeDzikId,
                                encounter_type_property_id = encounterTypePropertyWithChildrenId
                            },
                            new
                            {
                                encounter_type_id = encounterTypeDzikId,
                                encounter_type_property_id = encounterTypePropertyAttitudeId
                            }
                          );
                    });
        }
    }
}