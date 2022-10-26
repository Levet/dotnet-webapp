var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var dogs = new Services.Dogs();

// API
app.MapGet("/api/get-data", async () => 
{
    try {

        dogs = new Services.Dogs();

        string json = await dogs.HandleDogs();
        return json;
    }
    catch (Exception ex) {
        return "{\"error\": \"Error\"}";
    }
});

app.MapGet("/api/cancel", () => 
{
    dogs.CancelDogs();
    return "Cancelled";
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
