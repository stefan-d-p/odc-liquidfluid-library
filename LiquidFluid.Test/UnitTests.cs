namespace Without.Systems.LiquidFluid.Test;

public class Tests
{
    private static readonly ILiquidFluid _actions = new LiquidFluid();

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Simple_Template_And_Data()
    {
        string template = @"<span>{{product}}</span>";
        string model = @"{ ""product"":""Scanner 102"" }";
        string expectedResult = @"<span>Scanner 102</span>";
        
        string result = _actions.RenderTemplate(template, model);
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Nested_Product_Data()
    {
        string model = File.ReadAllText(@"Samples\data.json");
        string template = @"<span>{{specs.color}}</span>";
        string result = _actions.RenderTemplate(template, model);
    }

    
}