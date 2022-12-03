using BookSmart.Models;
using BookSmart.Services.EFServices;
using BookSmart.Services.EFServices.CorrelationTables;
using BookSmart.Services.Interfaces;
using BookSmart.Services.Interfaces.CorrelationTables;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<IBookService, EFBookService>();
builder.Services.AddTransient<ISubjectService, EFSubjectService>();
builder.Services.AddTransient<ITeacherService, EFTeacherService>();
builder.Services.AddTransient<IClassService, EFClassService>();
builder.Services.AddDbContext<BookSmartDBContext>();
builder.Services.AddTransient<ITeacherService, EFTeacherService>();
builder.Services.AddTransient<IClassService, EFClassService>();
builder.Services.AddTransient<IBookClassService, EFBookClassService>();
builder.Services.AddTransient<ISubjectTeacherService, EFSubjectTeacherService>();
builder.Services.AddTransient<IClassTeacherService, EFClassTeacherService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
