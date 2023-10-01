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

            var response = await openAiClient.GetCompletionsAsync("text-davinci-003", $"Napisz mi bardzo krotka ciekawostke o zwierzeciu {request.AnimalType}");

            var result = response.Value.Choices.First();

            return result.Text;
        }
    }
}