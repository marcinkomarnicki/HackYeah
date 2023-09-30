using HackYeah.Application.Queries.Models;
using HackYeah.DAL.Models;
using HackYeah.Infrastructure.Configurations;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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
            var timeNow = DateTime.Now;
            var minTime = timeNow.AddHours(-3);

            var dataFromDb = _dbContext.Encounters
                .Where(e => e.EncounterType.Code == request.EncounterType &&
                            e.TimeUtc > minTime &&
                            e.IsWild == request.IsWild &&
                            e.Latitude < request.MaxLatitude &&
                            e.Latitude > request.MinLatitude &&
                            e.Longitude < request.MaxLongitude &&
                            e.Longitude > request.MinLongitude)
                .Include(encounter => encounter.EncounterType)
                .ToList();

            var result = dataFromDb.Select(e => new EncounterResult()
            {
                Latitude = e.Latitude,
                Longitude = e.Longitude,
                IsWild = e.IsWild,
                EncounterType = e.EncounterType,
                TimeUtc = e.TimeUtc,
                PropabilityOfOccurance = (int)((timeNow - e.TimeUtc).TotalMinutes / 180) * 100
            }).ToList();

            return result;
        }
    }
}
