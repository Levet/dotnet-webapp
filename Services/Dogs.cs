namespace Services
{
    public class Dogs
    {

        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        public static async Task<string> HandleDogs()
        {

            var dogs = new Tasks.Dogs();

            try
            {
                var data = await dogs.GetDogBreedsAsync();
                string output = await dogs.ProcessDogBreedsAsync(data.Value);
                return output;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "{\"error\": \"Error\"}";
            }
        }
    }
}