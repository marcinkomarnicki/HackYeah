using HackYeah.Application.Services;
using HackYeah.DAL;
using HackYeah.DAL.Models;
using MediatR;
using Microsoft.AspNetCore.StaticFiles;

namespace HackYeah.Application.Commands
{
    public class AddEncounterImageCommand : IRequest
    {
        public Guid EncounterId { get; set; }
        public IFormFile ImageFile { get; set; }
    }

    public class AddEncounterImageCommandHandler : IRequestHandler<AddEncounterImageCommand>
    {
        private readonly ImageService _imageService;
        private readonly HackYeahDbContext _dbContext;

        public AddEncounterImageCommandHandler(ImageService imageService, HackYeahDbContext dbContext)
        {
            _imageService = imageService;
            _dbContext = dbContext;
        }

        public async Task Handle(AddEncounterImageCommand request, CancellationToken cancellationToken)
        {
            var mimeTypeProvider = new FileExtensionContentTypeProvider();
            var mimeType = string.Empty;

            mimeTypeProvider.TryGetContentType(request.ImageFile.FileName, out mimeType);

            var encounterImage = new EncounterImage
            {
                EncounterId = request.EncounterId,
                Encounter = null,
                MimeType = mimeType
            };

            _dbContext.EncounterImages.Add(encounterImage);
            await _dbContext.SaveChangesAsync();

            using (var imageStream = request.ImageFile.OpenReadStream())
            {
                _imageService.Save(imageStream, encounterImage.Id.ToString());
            }
        }
    }
}
