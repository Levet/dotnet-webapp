namespace Services
{
    public class Dogs
    {

        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        public static async void HandleDogs()
        {

            var dogs = new Tasks.Dogs();

            try
            {
                Console.WriteLine("Starting to get dog breeds");
                var data = await dogs.GetDogBreedsAsync();
                string output = await dogs.ProcessDogBreedsAsync(data.Value);
                Console.WriteLine(output);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}