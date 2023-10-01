using Azure.AI.OpenAI;
using MediatR;

namespace HackYeah.Application.Queries
{
    public class FactQuery : IRequest<string>
    {
        public string AnimalType { get; set; }
    }

    public class FactQueryHandler : IRequestHandler<FactQuery, string>
    {

        public FactQueryHandler()
        {
        }

        public async Task<string> Handle(FactQuery request,
            CancellationToken cancellationToken)
        {
            OpenAIClient openAiClient = new OpenAIClient("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");

            var response = await openAiClient.GetCompletionsAsync("text-davinci-003", $"Napisz mi krótką ciekawostkę o zwierzęciu {request.AnimalType}");

            var result = response.Value.Choices.First();

            return result.Text;
        }
    }
}