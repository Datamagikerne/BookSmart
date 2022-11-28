using BookSmart.Models;
using BookSmart.Services.EFServices;
using BookSmart.Services.EFServices.STabel;
using BookSmart.Services.Interfaces;
using BookSmart.Services.Interfaces.STabel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<IBookService, EFBookService>();
builder.Services.AddTransient<ISubjectService, EFSubjectService>();
builder.Services.AddTransient<ITeacherService, EFTeacherService>();
builder.Services.AddTransient<IClassService, EFClassService>();
builder.Services.AddTransient<ISubjectTeacherService, EFSubjectTeacherService>();
builder.Services.AddDbContext<BookSmartDBContext>();

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
