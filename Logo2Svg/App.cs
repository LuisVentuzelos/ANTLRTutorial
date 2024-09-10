using Antlr4.Runtime;

namespace Logo2Svg;

static class App 
{
    static int Main(string[] args)
    {
        // Check we have the correct arguments
        if (args.Length != 2) {
            Console.Error.WriteLine("Usage: logo2svg <input.logo> <output.svg>");
            return 1;
        }
        // Show some output
        var input = args[0];
        var output = args[1];
        Console.WriteLine($"From {input} to {output}");
        try
        {
             // Call ANTLR parser
             using FileStream fs = File.OpenRead(input);
             AntlrInputStream inputStream = new AntlrInputStream(fs);
             var lexer = new LogoLexer(inputStream);
             var parser = new LogoParser(new CommonTokenStream(lexer));

             LogoParser.ProgramContext program = parser.program();
        }
        catch (Exception exception)
        {
             Console.WriteLine($"Error: {exception}");                
        }
        return 0;
    }
}