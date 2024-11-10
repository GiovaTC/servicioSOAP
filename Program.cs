using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServicioSOAP.Services;
using SoapCore;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// Registra el servicio SOAP
builder.Services.AddSoapCore();
builder.Services.AddSingleton<ICalculatorService, CalculatorService>();

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{

    endpoints.UseSoapEndpoint<ICalculatorService>("/CalculatorService.svc", new SoapEncoderOptions(), SoapSerializer.DataContractSerializer);


    endpoints.MapGet("/CalculatorService.svc/wsdl", async context =>
    {

        if (context.Request.Query.ContainsKey("wsdl"))
        {
            var wsdlFilePath = "D:/Source 7.0/CalculatorService.wsdl"; 
            var wsdlContent = await File.ReadAllTextAsync(wsdlFilePath);
            context.Response.ContentType = "application/xml";
            await context.Response.WriteAsync(wsdlContent);
        }
        else
        {
            context.Response.StatusCode = 404;
        }
    });
});

app.Run();
