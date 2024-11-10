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
            var wsdlFilePath = "D:/Source 7.0/CalculatorService.wsdl"; //  var wsdlFilePath = "path_to_your_wsdl_file/CalculatorService.wsdl"; // Cambia esto a la ubicación correcta
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
