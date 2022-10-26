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
            var dogBreeds = dogs.Message.GetType().GetProperties().Select(x => x.Name).ToList();
            await Task.Delay(10, cancellationToken);
            string output = JsonSerializer.Serialize(dogBreeds);
            return output;
        }

        public async Task<string> ProcessDogBreedsAsync(Models.DogsDto dogs)
        {
            // await Task.Delay(10000);
            List<string> dogBreeds = dogs.Message.GetType().GetProperties().Select(x => x.Name).ToList();
            string output = JsonSerializer.Serialize(dogBreeds);
            return output;
        }
    }
}