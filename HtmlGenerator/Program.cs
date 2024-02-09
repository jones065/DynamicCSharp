using DynamicProgramming;
using Newtonsoft.Json;

namespace HtmlGenerator;

internal class Program
{
    static void Main(string[] args)
    {
        Program p = new Program();
        p.Run();
    }

    public void Run()
    {
        string jsonData = QueryAPI();
        dynamic? reportData = JsonConvert.DeserializeObject(jsonData);

        var customerHtmlElements = new List<HtmlElement>();

        foreach (dynamic customer in reportData.customers)
        {
            dynamic element = new HtmlElement("p");
            element.InnerHtml = $"{customer.firstName} {customer.lastName}";
            element.@class = "names";

            customerHtmlElements.Add(element);
        }

        Console.WriteLine($"<h1>{reportData.reportName}<h1/>");

        foreach (var line in customerHtmlElements)
        {
            Console.WriteLine(line);
        }

        Console.ReadLine();

    }

    private static string QueryAPI()
    {
        // Simulate querying an API to get report data
        return @"
	    {
		    'reportName': 'New Customers',
		    'customers':		
			    [
				    { 'firstName': 'Sarah', 'lastName': 'Smith' },
				    { 'firstName': 'Gentry', 'lastName': 'Jones' },
                    { 'firstName': 'Jason', 'lastName': 'Roberts' }
			    ]
       }";
    }
}
