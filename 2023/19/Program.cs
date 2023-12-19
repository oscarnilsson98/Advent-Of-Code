namespace _19;

class Program
{
    // private const string filePath = "./exampleInput.txt";
    private const string filePath = "./input.txt";

    static void Main()
    {
        Part1();
    }

    static void Part1()
    {
        var input = File.ReadAllLines(filePath).ToList();
        var indexToSplit = input.IndexOf("");
        var workflows = input.Take(indexToSplit);
        var parts = input.Skip(indexToSplit + 1);

        var acceptedPartValue = new List<int>();

        foreach (var part in parts)
        {
            var x = int.Parse(part.Split(",")[0].Split("=")[1]);
            var m = int.Parse(part.Split(",")[1].Split("=")[1]);
            var a = int.Parse(part.Split(",")[2].Split("=")[1]);
            var s = int.Parse(part.Split(",")[3].Split("=")[1].Split("}")[0]);

            var currentWorkflow = "in";
            while (currentWorkflow != "A" && currentWorkflow != "R")
            {
                var workflow = workflows.First(x => x.Split("{")[0] == currentWorkflow).Split("{")[1].Replace("}", "");

                var workflowSteps = workflow.Split(",");
                foreach (var step in workflowSteps)
                {
                    if (!step.Contains(':'))
                    {
                        currentWorkflow = step;
                        break;
                    }

                    var originalValue = step[0] switch
                    {
                        'x' => x,
                        'm' => m,
                        'a' => a,
                        _ => s,
                    };

                    var passes = step[1] switch
                    {
                        '>' => originalValue > int.Parse(step.Split(">")[1].Split(":")[0]),
                        '<' => originalValue < int.Parse(step.Split("<")[1].Split(":")[0]),
                        _ => false,
                    };

                    if (passes)
                    {
                        currentWorkflow = step.Split(":")[1];
                        break;
                    }
                }
            }
        
            if (currentWorkflow == "A")
            {
                acceptedPartValue.Add(x + m + a + s);
            }
        }

        Console.WriteLine(acceptedPartValue.Sum());
    }
}