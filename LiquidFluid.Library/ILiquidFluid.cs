using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.LiquidFluid
{
    [OSInterface(
        Name = "LiquidFluid",
        Description = "Fluid Template engine is based on the Liquid Template Language created by Shopify. Fluid is a native C# open-source implementation of the Liquid Template Language developed by Sebastien Ros",
        IconResourceName = "Without.Systems.LiquidFluid.Resources.Liquid.png")]
    public interface ILiquidFluid
    {
        [OSAction(
            Description = "Renders a Liquid template with data",
            ReturnType = OSDataType.Text,
            ReturnName = "result",
            ReturnDescription = "Rendered result",
            IconResourceName = "Without.Systems.LiquidFluid.Resources.Liquid.png")]
        string RenderTemplate(
            [OSParameter(
                Description = "Liquid template",
                DataType = OSDataType.Text)] string template,
            [OSParameter(
                Description = "Data to be rendered - JSON document",
                DataType = OSDataType.Text)] string data);
    }
}