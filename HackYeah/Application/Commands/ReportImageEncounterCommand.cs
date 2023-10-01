using HackYeah.Application.Services;
using HackYeah.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HackYeah.Application.Commands
{
    public class ReportImageEncounterCommand : IRequest<string?>
    {
        public IFormFile ImageFile { get; set; }
    }

    public class ReportImageEncounterCommandHandler : IRequestHandler<ReportImageEncounterCommand, string?>
    {
        private readonly ImageService _imageService;
        private readonly HackYeahDbContext _dbContext;

        public ReportImageEncounterCommandHandler(ImageService imageService, HackYeahDbContext dbContext)
        {
            _imageService = imageService;
            _dbContext = dbContext;
        }

        public Task<string?> Handle(ReportImageEncounterCommand request, CancellationToken cancellationToken)
        {
            using (var imageFileStream = request.ImageFile.OpenReadStream())
            {
                var aiLabelId = _imageService.Predict(imageFileStream, Path.GetExtension(request.ImageFile.FileName));

                return _dbContext.EncounterType
                    .Where(et => et.AiLabelId == aiLabelId)
                    .Select(et => et.Code)
                    .FirstOrDefaultAsync(cancellationToken);
            }
        }
    }
}
