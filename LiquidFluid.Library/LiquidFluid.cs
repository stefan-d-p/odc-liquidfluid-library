using System.Dynamic;
using System.Text.Json;
using Fluid;

namespace Without.Systems.LiquidFluid;

public class LiquidFluid : ILiquidFluid
{
    private static readonly FluidParser _fluidParser = new FluidParser();
    
    /// <summary>
    /// Renders a document
    /// </summary>
    /// <param name="template">Liquid template</param>
    /// <param name="data">JSON data</param>
    /// <returns>Rendered result</returns>
    /// <exception cref="ArgumentException"></exception>
    public string RenderTemplate(string template, string data)
    {
        if(string.IsNullOrEmpty(template) || string.IsNullOrEmpty(data))
            throw new ArgumentException("Template and data are required");

        IFluidTemplate parsedTemplate = _fluidParser.Parse(template);
        var jsonDocument = JsonSerializer.Deserialize<ExpandoObject>(data);
        var context = new TemplateContext(jsonDocument);
        return parsedTemplate.RenderAsync(context).Result;
    }
}
