using HackYeah.Application.Exceptions;
using HackYeah.Application.Queries.Models;
using HackYeah.Application.Services;
using HackYeah.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace HackYeah.Application.Queries
{
    public class GetMissingPetImageQuery : IRequest<GetMissingPetImageResult> 
    {
        public Guid Id { get; set; }
    }

    public class GetMissingPetImageQueryHandler : IRequestHandler<GetMissingPetImageQuery, GetMissingPetImageResult>
    {
        private readonly ImageService _imageService;
        private readonly HackYeahDbContext _dbContext;

        public GetMissingPetImageQueryHandler(ImageService imageService, HackYeahDbContext dbContext)
        {
            _imageService = imageService;
            _dbContext = dbContext;
        }

        public async Task<GetMissingPetImageResult> Handle(GetMissingPetImageQuery request, CancellationToken cancellationToken)
        {
            var missingPetImageEntity = await _dbContext.MissingPetsReportImages
                .FirstOrDefaultAsync(image => image.Id == request.Id);

            if (missingPetImageEntity == null)
            {
                throw new NotFoundException(string.Empty);
            }

            return new GetMissingPetImageResult
            {
                ImageStream = _imageService.Load(missingPetImageEntity.Id.ToString()),
                MimeType = missingPetImageEntity.MimeType
            };
        }
    }
}
