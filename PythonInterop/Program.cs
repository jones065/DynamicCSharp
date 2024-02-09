using DynamicProgramming;
using IronPython.Hosting;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using static System.Console;


namespace PythonInterop;

internal class Program
{
    static void Main(string[] args)
    {
        Program p = new Program();

        Console.WriteLine("*********************");
        Console.WriteLine("*       MENU        *");
        Console.WriteLine("*********************");
        Console.WriteLine("1) Python simple canned expression");
        Console.WriteLine("2) Python user defined expression");
        Console.WriteLine("3) Python user defined statement");
        Console.WriteLine("4) Python object interaction");
        Console.WriteLine("5) Passing a dynamic object to Python");

        var key = Console.ReadKey();
        Console.WriteLine();
        switch(key.KeyChar)
        {
            case '1':
                p.Test1();
                break;
            case '2':
                p.Test2();
                break;
            case '3':
                p.Test3();
                break;
            case '4':
                p.Test4();
                break;
            case '5':
                p.Test5();
                break;
            default:
                Console.WriteLine("Invalid selection.  Quitting.");
                break;

        }
    }

    private void Test1()
    {
        ScriptEngine engine = Python.CreateEngine();

        string simpleExpression = "2 + 2";

        dynamic dynamicResult = engine.Execute(simpleExpression);
        int typedResult = engine.Execute<int>(simpleExpression);

        Console.WriteLine($"Dynamic Result: {dynamicResult}");
        Console.WriteLine($"Typed Result: {typedResult}");
    }

    // ** Executing an Expression in Python **
    // Set a variable
    // Use an expression
    // Use a script scope in addition to the engine
    private void Test2()
    {
        ScriptEngine engine = Python.CreateEngine();

        int customerAge = 42;

        WriteLine("Please enter an expression (use token 'a' for customer age) and press enter.  Type 'done' to quit.");
        WriteLine("Example: '1 < a < 70'");

        do
        {
            string simpleExpression = Console.ReadLine()!;
            if (simpleExpression == "done")
            {
                break;
            }

            ScriptScope scriptScope = engine.CreateScope();
            scriptScope.SetVariable("a", customerAge);

            ScriptSource scriptSource = engine.CreateScriptSourceFromString(
                simpleExpression,
                SourceCodeKind.Expression);

            dynamic dynamicResult = scriptSource.Execute(scriptScope);

            Console.WriteLine($"Dynamic Result: {dynamicResult}");

        } while (true);
    }

    // ** Executing a Statement in Python **
    // Get a variable
    // Use a statement
    private void Test3()
    {
        ScriptEngine engine = Python.CreateEngine();

        int customerAge = 42;

        WriteLine("Please enter a statement and press enter.  Type 'done' to quit.");
        WriteLine("Variables: use token 'a' for customer age and 'result' for the result of the statement");
        WriteLine("Example: 'result = 5 + a'");

        do
        {
            string singleStatement = Console.ReadLine()!;
            if (singleStatement == "done")
            {
                break;
            }

            ScriptScope scriptScope = engine.CreateScope();
            scriptScope.SetVariable("a", customerAge);

            ScriptSource scriptSource = engine.CreateScriptSourceFromString(
                singleStatement,
                SourceCodeKind.SingleStatement);  // change this to a statement instead of an expression

            scriptSource.Execute(scriptScope);

            dynamic dynamicResult = scriptScope.GetVariable("result");

            Console.WriteLine($"Dynamic Result: {dynamicResult}");

        } while (true);
    }

    // ** Interact with Python objects **
    private void Test4()
    {
        ScriptEngine engine = Python.CreateEngine();

        string tupleStatement = "customer = ('Sarah', 42, 200)";
        ScriptScope scope = engine.CreateScope();

        ScriptSource scriptSource = 
            engine.CreateScriptSourceFromString(
                tupleStatement, 
                SourceCodeKind.SingleStatement);

        scriptSource.Execute(scope);

        dynamic pythonTuple = scope.GetVariable("customer");

        WriteLine($"Name = {pythonTuple[0]} Age = {pythonTuple[1]} Height = {pythonTuple[2]}");

    }

    // ** Passing a dynamic object to Python **
    private void Test5()
    {
        ScriptEngine engine = Python.CreateEngine();

        HtmlElement image = new HtmlElement("img");

        ScriptScope scriptScope = engine.CreateScope();
        scriptScope.SetVariable("image", image);

        ScriptSource scriptSource = engine.CreateScriptSourceFromFile("SetImageAttributes.py");

        WriteLine($"image before Python execution: {image}");
        scriptSource.Execute(scriptScope);
        WriteLine($"image after Python execution: {image}");

    }
}
