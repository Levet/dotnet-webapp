using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tasks
{
    public class Dogs
    {

        static readonly HttpClient client = new HttpClient();

        public async Task<Classes.Result<Models.DogsDto>> GetDogBreedsAsync()
        {

            var request = new HttpRequestMessage(HttpMethod.Get, "https://dog.ceo/api/breeds/list/all");

            using (var response = await client.SendAsync(request))
            {
                if(response.StatusCode == HttpStatusCode.OK)
                {
                    var responseJson = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
                    var data = JsonSerializer.Deserialize<Models.DogsDto>(responseJson, options);
                    Console.WriteLine(data.Status);
                    return Classes.Result<Models.DogsDto>.Ok(data);
                }

                return Classes.Result<Models.DogsDto>.Fail(response.StatusCode.ToString());
            }
        }

        public async Task<string> ProcessDogBreedsAsync(Models.DogsDto dogs, CancellationToken cancellationToken)
        {
            Console.WriteLine("Processing dog breeds...");

            List<string> dogBreeds = new List<string>();
            foreach (var prop in dogs.Message.GetType().GetProperties()) 
            {
                dogBreeds.Add(prop.Name);

                // Simulate a long-running task.
                await Task.Delay(100, cancellationToken).ConfigureAwait(false);

                if(cancellationToken.IsCancellationRequested)
                {
                    Console.WriteLine("Cancelling...");
                    cancellationToken.ThrowIfCancellationRequested();
                }
            }

            string output = JsonSerializer.Serialize(dogBreeds);
            return output;
        }

        public async Task<string> ProcessDogBreedsAsync(Models.DogsDto dogs)
        {
            List<string> dogBreeds = dogs.Message.GetType().GetProperties().Select(x => x.Name).ToList();
            string output = JsonSerializer.Serialize(dogBreeds);
            return output;
        }
    }
}