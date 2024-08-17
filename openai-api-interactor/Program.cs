var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// and this is an entire topic to learn.  lambdas / delegates
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhostAccess",
    // you don't want to allow just any origin
    // once your app is deployed, use the actual app URL
    // 
    // this is one important layer of security.  it prevents any
    // old origin from spamming your API with requests.  a potential bad
    // actor would have to work harder, navigating to your url and getting into
    // the dev tools.

    // having a / on the end of the url breaks it. lmaooo
    policy => policy.WithOrigins("http://localhost:5173")
        .AllowAnyHeader() 
        .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowLocalhostAccess");

app.UseAuthorization();

// the MVC framework crawls the project for controllers.  And spins up the API endpoints accordingly.
app.MapControllers();

app.Run();
