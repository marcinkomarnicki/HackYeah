using HackYeah.Application.Services;
using HackYeah.DAL;
using HackYeah.DAL.Models;
using MediatR;
using Microsoft.AspNetCore.StaticFiles;

namespace HackYeah.Application.Commands
{
    public class AddMissingPetImageCommand : IRequest
    {
        public Guid MissingPetReportId { get; set; }
        public IFormFile ImageFile { get; set; }
    }

    public class AddMissingPetImageCommandHandler : IRequestHandler<AddMissingPetImageCommand>
    {
        private readonly ImageService _imageService;
        private readonly HackYeahDbContext _dbContext;

        public AddMissingPetImageCommandHandler(ImageService imageService, HackYeahDbContext dbContext)
        {
            _imageService = imageService;
            _dbContext = dbContext;
        }

        public async Task Handle(AddMissingPetImageCommand request, CancellationToken cancellationToken)
        {
            var mimeTypeProvider = new FileExtensionContentTypeProvider();
            var mimeType = string.Empty;

            mimeTypeProvider.TryGetContentType(request.ImageFile.FileName, out mimeType);

            var missingPetImage = new MissingPetReportImage
            {
                MissingPetReportId = request.MissingPetReportId,
                MissingPetReport = null,
                MimeType = mimeType
            };

            _dbContext.MissingPetsReportImages.Add(missingPetImage);
            await _dbContext.SaveChangesAsync();

            using (var imageStream = request.ImageFile.OpenReadStream())
            {
                _imageService.Save(imageStream, missingPetImage.Id.ToString());
            }
        }
    }
}
