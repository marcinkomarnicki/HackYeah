using HackYeah.Application.Services;
using MediatR;

namespace HackYeah.Application.Commands
{
    public class ReportImageEncounterCommand : IRequest<int>
    {
        public IFormFile ImageFile { get; set; }
    }

    public class ReportImageEncounterCommandHandler : IRequestHandler<ReportImageEncounterCommand, int>
    {
        private readonly ImageService _imageService;

        public ReportImageEncounterCommandHandler(ImageService imageService)
        {
            _imageService = imageService;
        }

        public Task<int> Handle(ReportImageEncounterCommand request, CancellationToken cancellationToken)
        {
            using (var imageFileStream = request.ImageFile.OpenReadStream())
            {
                return Task.FromResult(_imageService.Predict(imageFileStream, Path.GetExtension(request.ImageFile.FileName)));
            }
        }
    }
}
