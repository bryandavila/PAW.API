using PAW.Core.ApprovalProcess;
using PAW.Core.ApprovalProcess.Contract;
using PAW.Repository.Approvals;
using PAW.Repository.Products;
using PAW.Repository.Roles;
using PAW.API.Controllers;
using PAW.Services;
using PAW.Architecture.Providers;
using APW.Architecture;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<IApprovalHandler<HandlerBase>, PendingHandler>();
builder.Services.AddScoped<IApprovalHandler<HandlerBase>, ArchivedHandler>();
builder.Services.AddScoped<IApprovalHandler<HandlerBase>, InProgressHandler>();
builder.Services.AddScoped<ITicketApprovalProcess, TicketApprovalProcess>();
builder.Services.AddScoped<IProductGenerationService, ProductGenerationService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IRestProvider, RestProvider>();


builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IComponentRepository, ComponentRepository>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<IUserActionRepository, UserActionRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
