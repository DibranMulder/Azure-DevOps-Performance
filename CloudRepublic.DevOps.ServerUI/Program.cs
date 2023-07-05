using CloudRepublic.DevOps.ServerUI.Data;
using Microsoft.TeamFoundation.TestManagement.WebApi;
using System.Net;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddHttpClient("azureHttpClient")
    .ConfigureHttpClient(client =>
    {
        client.Timeout = TimeSpan.FromSeconds(10);
    })
    .AddHttpMessageHandler(() => new AzurePrerequestHandler(
        builder.Configuration["Azure:TenantId"]!,
        builder.Configuration["Azure:ClientId"]!,
        builder.Configuration["Azure:ClientSecret"]!));

builder.Services.AddSingleton<AzureService>();

builder.Services.AddSingleton(new AzureDevOpsService(
    builder.Configuration["AzureDevOps:Organization"]!,
    builder.Configuration["AzureDevOps:Project"]!,
    builder.Configuration["AzureDevOps:PersonalAccessToken"]!));

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
