using System.Text.Json;
using Fluid;
using Fluid.Values;

namespace Without.Systems.LiquidFluid.Filter;

public static class CustomFilters
{
    public static FilterCollection WithCustomFilters(this FilterCollection filters)
    {
        filters.AddFilter("json", ToEncodedJson);
        return filters;
    }
    
    public static ValueTask<FluidValue> ToEncodedJson(FluidValue input, FilterArguments arguments,
        TemplateContext context)
    {
        var value = input.ToStringValue();
        var encoded = JsonSerializer.Serialize(value);
        return new StringValue(encoded);
        
    }
}