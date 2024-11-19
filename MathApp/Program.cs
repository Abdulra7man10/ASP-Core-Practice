using Microsoft.Extensions.Primitives;
using System.IO;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    context.Request.Headers["Context-Type"] = "text/html";
    if (context.Request.Method == "GET")
    {
        int firstNumber = 0, secondNumber = 0;
        string operation = "";
        bool check = true;
        if (context.Request.Query.ContainsKey("firstNumber"))
        {
            if (!int.TryParse(context.Request.Query["firstNumber"], out firstNumber))
            {
                await context.Response.WriteAsync($"Invalid input for 'firstNumber'\n");
                context.Response.StatusCode = 400;
            }
        } else
        {
            await context.Response.WriteAsync($"Invalid input for 'firstNumber'\n");
            check = false;
        }


        if (context.Request.Query.ContainsKey("secondNumber"))
        {
            if (!int.TryParse(context.Request.Query["secondNumber"], out secondNumber))
            {
                await context.Response.WriteAsync($"Invalid input for 'secondNumber'\n");
                context.Response.StatusCode = 400;
            }
        } else
        {
            await context.Response.WriteAsync($"Invalid input for 'secondNumber'\n");
            context.Response.StatusCode = 400;
            check = false;
        }


        if (context.Request.Query.ContainsKey("operation"))
            operation = context.Request.Query["operation"];
        else 
        {
            await context.Response.WriteAsync($"Invalid input for 'operation'\n");
            context.Response.StatusCode = 400;
            check = false;
        }


        if(check)
        {
            int result = 0;
            switch (operation)
            {
                case "add":
                    result = firstNumber + secondNumber;
                    break;
                case "sub":
                    result = firstNumber - secondNumber;
                    break;
                case "mul":
                    result = firstNumber * secondNumber;
                    break;
                case "div":
                    if (secondNumber == 0)
                    {
                        await context.Response.WriteAsync($"Division by zero is not allowed.");
                        return;
                    }
                    result = firstNumber / secondNumber;
                    break;
                case "mod":
                    if (secondNumber == 0)
                    {
                        await context.Response.WriteAsync($"Mod by zero is not allowed.");
                        return;
                    }
                    result = firstNumber % secondNumber;
                    break;
                default:
                    await context.Response.WriteAsync($"Invalid operation '{operation}'. Valid options are: add, sub, mul, div.");
                    return;
            }

            await context.Response.WriteAsync($"{result}");
        }
    }
});

app.Run();
