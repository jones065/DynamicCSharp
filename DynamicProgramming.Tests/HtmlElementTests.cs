using Microsoft.CSharp.RuntimeBinder;

namespace DynamicProgramming.Tests;

public class HtmlElementTests
{
    [Fact]
    public void ShouldStoreTagName()
    {
        dynamic image = new HtmlElement("img");

        Assert.Equal("img", image.TagName);
    }

    [Fact]
    public void ShowAddAttributeNameAndValueDynamically()
    {
        dynamic image = new HtmlElement("img");

        image.src = "car.png";

        Assert.Equal("car.png", image.src);
    }

    [Fact]
    public void ShouldErrorIfAttributeNotSet()
    {
        dynamic image = new HtmlElement("img");

        Assert.Throws<RuntimeBinderException>(() => image.src);
    }

    [Fact]
    public void ShouldReturnDynamicMemberNames()
    {
        dynamic image = new HtmlElement("img");
        image.src = "car.png";
        image.alt = "a blue car";

        IReadOnlyList<string> members = image.GetDynamicMemberNames();

        Assert.Equal(2, members.Count);
        Assert.Equal("src", members[0]);
        Assert.Equal("alt", members[1]);
    }

    [Fact]
    public void ShouldOutputTagHtml()
    {
        string tag = "img";
        dynamic image = new HtmlElement(tag);
        image.src = "car.png";
        image.alt = "a blue car";

        var html = image.ToString();

        Assert.Equal($"<img src=\"car.png\" alt=\"a blue car\"></{tag}>", html);
    }

    [Fact]
    public void ShouldBeCastableToDictionary()
    {
        dynamic image = new HtmlElement("img");

        var attributes = (IDictionary<string, object?>)image;

        attributes["src"] = "car.png";

        Assert.Equal("car.png", image["src"]);
    }

    [Fact]
    public void ShouldBeEnumerable()
    {
        string tag = "img";
        dynamic image = new HtmlElement(tag);
        image.src = "car.png";

        var count = 0;
        foreach(var attribute in image)
        {
            Assert.Equal("src", attribute.Key);
            Assert.Equal("car.png", attribute.Value);
            count++;
        }

        Assert.Equal(1, count);
    }

    [Fact]
    public void ShouldRenderHtml()
    {
        string tag = "img";
        dynamic image = new HtmlElement(tag);

        image.src = "car.png";
        image.alt = "a blue car";

        string html = image.Render();
        Assert.Equal($"<img src=\"car.png\" alt=\"a blue car\"></{tag}>", html);
    }

    [Fact]
    public void ShouldRenderHtmlOnInvoke()
    {
        string tag = "img";
        dynamic image = new HtmlElement(tag);

        image.src = "car.png";
        image.alt = "a blue car";

        var html = image();
        //<img src="car.png" alt="a blue car"></img>
        Assert.Equal($"<img src=\"car.png\" alt=\"a blue car\"></{tag}>", html);
    }
}
