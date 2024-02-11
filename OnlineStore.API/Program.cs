using OnlineStore.API.Interfaces;
using OnlineStore.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddSingleton<ICategoryService, CategoryService>();
builder.Services.AddTransient<IMyAuthenticationService, AuthenticationService>();
builder.Services.AddCors(options =>
{
	options.AddPolicy("MyPolicy", options =>
	{
		options.AllowAnyOrigin()
		.AllowAnyMethod()
		.AllowAnyHeader();
	});
});

builder.Services.AddAuthorization();
builder.Services.AddAuthentication("AnthonysCookieAuth").AddCookie("AnthonysCookieAuth", options =>
{
	options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
	options.Cookie.Name = "AnthonysCookieAuth";
});

builder.Services.AddHttpClient("FakeStoreAPI", client =>
{
	client.BaseAddress = new Uri("https://fakestoreapi.com/");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
