using HackYeah.Application.Exceptions;
using HackYeah.Application.Queries.Models;
using HackYeah.Application.Services;
using HackYeah.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HackYeah.Application.Queries
{
    public class GetEncounterImageQuery : IRequest<GetEncounterImageResult>
    {
        public Guid Id { get; set; }
    }

    public class GetEncounterImageQueryHandler : IRequestHandler<GetEncounterImageQuery, GetEncounterImageResult>
    {
        private readonly ImageService _imageService;
        private readonly HackYeahDbContext _dbContext;

        public GetEncounterImageQueryHandler(ImageService imageService, HackYeahDbContext dbContext)
        {
            _imageService = imageService;
            _dbContext = dbContext;
        }

        public async Task<GetEncounterImageResult> Handle(GetEncounterImageQuery request, CancellationToken cancellationToken)
        {
            var encounterImageEntry = await _dbContext.EncounterImages
                .FirstOrDefaultAsync(image => image.Id == request.Id);

            if (encounterImageEntry == null)
            {
                throw new NotFoundException(string.Empty);
            }

            return new GetEncounterImageResult
            {
                ImageStream = _imageService.Load(encounterImageEntry.Id.ToString()),
                MimeType = encounterImageEntry.MimeType
            };
        }
    }
}
