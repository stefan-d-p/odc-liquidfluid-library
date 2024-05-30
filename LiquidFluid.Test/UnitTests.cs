using System.Text.Json;

namespace Without.Systems.LiquidFluid.Test;

public class Tests
{
    private static readonly ILiquidFluid _actions = new LiquidFluid();

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task Simple_Template_And_Data()
    {
        string template = @"<span>{{product}}</span>";
        string model = @"{ ""product"":""Scanner 102"" }";
        string expectedResult = @"<span>Scanner 101</span>";
        
        string result = await _actions.RenderTemplate(template, model);
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Malformed_Template()
    {
        string template = @"<span>{{{{product}}</span>";
        string model = @"{ ""product"":""Scanner 101"" }";
        Assert.ThrowsAsync<Fluid.ParseException>(() =>_actions.RenderTemplate(template, model));
    }

    [Test]
    public void Malformed_Data()
    {
        string template = @"<span>{{product}}</span>";
        string model = @" ""product"":""Scanner 101"" }";
        Assert.ThrowsAsync<JsonException>(() => _actions.RenderTemplate(template, model));
    }
}