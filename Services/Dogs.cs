namespace Services
{
    public class Dogs
    {

        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        public async Task<string> HandleDogs()
        {

            if (_cancellationTokenSource.IsCancellationRequested)
            {
                _cancellationTokenSource.Dispose();
                _cancellationTokenSource = new CancellationTokenSource();
            }

            var dogs = new Tasks.Dogs();

            try
            {
                var data = await dogs.GetDogBreedsAsync();
                string output = await dogs.ProcessDogBreedsAsync(data.Value, _cancellationTokenSource.Token);
                return output;
            }
            catch(OperationCanceledException ex)
            {
                return "{\"status\": \"Cancelled\"}";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "{\"error\": \"Error\"}";
            }
        }

        public void CancelDogs()
        {
            _cancellationTokenSource.Cancel();
        }
    }
}