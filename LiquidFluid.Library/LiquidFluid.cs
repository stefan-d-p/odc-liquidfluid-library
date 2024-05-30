using System.Dynamic;
using System.Text.Json;
using Fluid;

namespace Without.Systems.LiquidFluid;

public class LiquidFluid : ILiquidFluid
{
    private static readonly FluidParser _fluidParser = new FluidParser();
    
    public async Task<string> RenderTemplate(string template, string data)
    {
        if(string.IsNullOrEmpty(template) || string.IsNullOrEmpty(data))
            throw new ArgumentException("Template and data are required");

        IFluidTemplate parsedTemplate = _fluidParser.Parse(template);
        var jsonDocument = JsonSerializer.Deserialize<ExpandoObject>(data);
        var context = new TemplateContext(jsonDocument);
        return await parsedTemplate.RenderAsync(context);
    }
}
