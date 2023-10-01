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

        public DbSet<Demo> Demos { get; set; }

        public DbSet<Encounter> Encounters { get; set; }

        public DbSet<EncounterType> EncounterType { get; set; }
        
        public DbSet<MissingPetReport> MissingPetsReports { get; set; }

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
            
            // modelBuilder.Entity<PetFile>()
            //     .HasOne(x => x.MissingPetReport)
            //     .WithOne().HasForeignKey(y => y);
            /*
            modelBuilder.Entity<EncounterType>()
                .HasMany(e => e.EncounterTypeProperties)
                .WithMany(e => e.EncounterTypes)
                .UsingEntity(
                    "encounter_types_encounter_type_properties",
                    r => r.HasOne(typeof(EncounterTypeProperty)).WithMany().HasForeignKey("encounter_type_property_id").HasPrincipalKey(nameof(EncounterTypeProperty.Id)),
                    l => l.HasOne(typeof(EncounterType)).WithMany().HasForeignKey("encounter_type_id").HasPrincipalKey(nameof(EncounterType.Id)),
                    j => j.HasKey("encounter_type_id", "encounter_type_property_id"));
                    */


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

            /*modelBuilder.Entity<EncounterTypesEncounterTypeProperties>().HasData(
                new EncounterTypesEncounterTypeProperties
                {
                    Id = new Guid("CFDB3BE4-3019-41B4-A042-DC890A5D3679"),
                    EncounterTypeId = encounterTypePiesId,
                    EncounterTypePropertyId = encounterTypePropertyCollarId
                },
                new EncounterTypesEncounterTypeProperties
                {
                    Id = new Guid("BE356819-7B76-48C8-AC6E-849559A72554"),
                    EncounterTypeId = encounterTypePiesId,
                    EncounterTypePropertyId = encounterTypePropertyColorId
                },
                new EncounterTypesEncounterTypeProperties
                {
                    Id = new Guid("CF7C0191-B37A-40B2-8B52-F4EFA40C1ED8"),
                    EncounterTypeId = encounterTypePiesId,
                    EncounterTypePropertyId = encounterTypePropertyBreedId
                },
                new EncounterTypesEncounterTypeProperties
                {
                    Id = new Guid("5CBCC212-C9F9-48AC-A992-F300D7CF7E07"),
                    EncounterTypeId = encounterTypePiesId,
                    EncounterTypePropertyId = encounterTypePropertyAttitudeId
                },
                new EncounterTypesEncounterTypeProperties
                {
                    Id = new Guid("11D94376-6F03-4275-AF07-A0BC2983C090"),
                    EncounterTypeId = encounterTypePiesId,
                    EncounterTypePropertyId = encounterTypePropertySizeId
                },
                new EncounterTypesEncounterTypeProperties
                {
                    Id = new Guid("CAC8E6C1-7D1A-4CA7-96E5-96DDBFDE7064"),
                    EncounterTypeId = encounterTypeKotId,
                    EncounterTypePropertyId = encounterTypePropertyCollarId
                },
                new EncounterTypesEncounterTypeProperties
                {
                    Id = new Guid("7F921E9F-99FC-4930-8805-1E4CD5CBD2FB"),
                    EncounterTypeId = encounterTypeKotId,
                    EncounterTypePropertyId = encounterTypePropertyColorId
                },
                new EncounterTypesEncounterTypeProperties
                {
                    Id = new Guid("93B13B81-1460-4D6B-A6D9-7ED2405EFDE3"),
                    EncounterTypeId = encounterTypeKotId,
                    EncounterTypePropertyId = encounterTypePropertyBreedId
                },
                new EncounterTypesEncounterTypeProperties
                {
                    Id = new Guid("5F3958A6-50FA-4638-B8AC-F6F2744FFAC4"),
                    EncounterTypeId = encounterTypeKotId,
                    EncounterTypePropertyId = encounterTypePropertyAttitudeId
                }
            );*/


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