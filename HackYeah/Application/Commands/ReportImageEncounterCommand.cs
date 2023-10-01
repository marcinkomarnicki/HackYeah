using HackYeah.Application.Services;
using HackYeah.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HackYeah.Application.Commands
{
    public class ReportImageEncounterCommand : IRequest<Guid?>
    {
        public IFormFile ImageFile { get; set; }
    }

    public class ReportImageEncounterCommandHandler : IRequestHandler<ReportImageEncounterCommand, Guid?>
    {
        private readonly ImagePredictionService _imagePredictionService;
        private readonly HackYeahDbContext _dbContext;

        public ReportImageEncounterCommandHandler(ImagePredictionService imagePredictionService, HackYeahDbContext dbContext)
        {
            _imagePredictionService = imagePredictionService;
            _dbContext = dbContext;
        }

        public async Task<Guid?> Handle(ReportImageEncounterCommand request, CancellationToken cancellationToken)
        {
            using (var imageFileStream = request.ImageFile.OpenReadStream())
            {
                var aiLabelId = _imagePredictionService.Predict(imageFileStream, Path.GetExtension(request.ImageFile.FileName));

                var encounterType = await _dbContext.EncounterType
                    .FirstOrDefaultAsync(et => et.AiLabelId == aiLabelId);

                return encounterType == null ? (Guid?)null : encounterType.Id;
            }
        }
    }
}
