﻿using HackYeah.Application.Queries.Models;
using MediatR;
using HackYeah.DAL;
using Microsoft.EntityFrameworkCore;

namespace HackYeah.Application.Queries
{
    public class GetEncountersQuery : IRequest<List<EncounterResult>>
    {
        public decimal MinLatitude { get; set; }
        public decimal MaxLatitude { get; set; }
        public decimal MinLongitude { get; set; }
        public decimal MaxLongitude { get; set; }
        public string EncounterType { get; set; }
        public bool IsWild { get; set; }
    }

    public class GetEncountersQueryHandler : IRequestHandler<GetEncountersQuery, List<EncounterResult>>
    {
        private readonly HackYeahDbContext _dbContext;

        public GetEncountersQueryHandler(HackYeahDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<EncounterResult>> Handle(GetEncountersQuery request, CancellationToken cancellationToken)
        {
            var timeNow = DateTime.UtcNow;
            var minTime = timeNow.AddHours(-3);

            var dataFromDb = _dbContext.Encounters
                .Where(e => 
                            (string.IsNullOrWhiteSpace(request.EncounterType) || e.EncounterType.Code == request.EncounterType) &&
                            e.TimeUtc > minTime &&
                            e.Latitude < request.MaxLatitude &&
                            e.Latitude > request.MinLatitude &&
                            e.Longitude < request.MaxLongitude &&
                            e.Longitude > request.MinLongitude)
                .Include(encounter => encounter.EncounterType)
                .Include(encounter => encounter.EncounterProperties)
                .ThenInclude(propType => propType.EncounterTypeProperty)
                .Where(p => p.EncounterType.IsSearchable != request.IsWild)
                .ToList();

            var result = dataFromDb.Select(e => new EncounterResult()
            {
                Latitude = e.Latitude,
                Longitude = e.Longitude,
                IsWild = !e.EncounterType.IsSearchable,
                EncounterType = e.EncounterType.Code,
                TimeUtc = e.TimeUtc,
                PropabilityOfOccurance = (int)((timeNow - e.TimeUtc).TotalMinutes / 180) * 100,
                Properties = e.EncounterProperties.Select(p => new EncounterResultProperties
                {
                    Name = p.EncounterTypeProperty.Name,
                    ValueType = p.EncounterTypeProperty.ValueType.ToString(),
                    Value = p.Value
                }).ToList()
            }).ToList();

            return result;
        }
    }
}