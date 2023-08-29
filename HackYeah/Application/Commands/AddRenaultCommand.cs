using MediatR;

namespace HackYeah.Application.Commands
{
    public class AddRenaultCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class AddRenaultCommandHandler : IRequestHandler<AddRenaultCommand>
    {
        public Task Handle(AddRenaultCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
