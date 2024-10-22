var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(c =>
{
    c.RegisterServicesFromAssembly(typeof(Program).Assembly);
    c.AddOpenBehavior(typeof(ValidatorPipelineBehavior<,>));
});

builder.Services.AddMarten(x => x.Connection(builder.Configuration.GetConnectionString("GradeDb")!))
  .UseLightweightSessions();


builder.Services.AddCarter();

var app = builder.Build();
app.MapCarter();
app.Run();
