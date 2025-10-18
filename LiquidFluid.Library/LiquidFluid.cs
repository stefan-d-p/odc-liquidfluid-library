using System.Dynamic;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;
using Fluid;
using Fluid.Parser;
using Fluid.Values;
using Without.Systems.LiquidFluid.Filter;

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

        TemplateOptions options = new TemplateOptions();
        options.Filters.WithCustomFilters();

        var jsonDocument = JsonNode.Parse(data);
        var context = new TemplateContext(jsonDocument, options);
        return parsedTemplate.RenderAsync(context).Result;
    }
}
