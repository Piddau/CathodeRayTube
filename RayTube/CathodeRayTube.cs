using System.Text;
using AdventOfCodeEon.Instructions;

namespace AdventOfCodeEon.RayTube;

public class CathodeRayTube
{
    const int ScreenWidth = 40, CycleOffset = 20;
    const char PixelOn = '#', PixelOff = '.';
    
    private int register = 1, globalCycle = 0, counter = 0, sum = 0, currentPixel = 0;

    private StringBuilder actualScreenBuilder;

    public CathodeRayTube()
    {
        actualScreenBuilder = new StringBuilder();
    }

    public void Run(InstructionHandler handler)
    {
        Instruction? currentInstruction = handler.GetNextInstructionInList();
        PrintHeader();

        while (currentInstruction != null)
        {
            ProcessInstruction(currentInstruction);

            if (currentInstruction.Completed)
                currentInstruction = handler.GetNextInstructionInList();
        }

        PrintFooter();
    }

    private void PrintFooter()
    {
        Console.WriteLine("\n\n----------------------------------------");
        Console.WriteLine($"Sum of Cycles: {sum}");
        Console.WriteLine("----------------------------------------\n\n");
    }

    private static void PrintHeader()
    {
        Console.WriteLine("\n\n========================================");
        Console.WriteLine("=         The Cathode-Ray Tube!        =");
        Console.WriteLine("========================================\n\n");
    }

    private void ProcessInstruction(Instruction currentInstruction)
    {
        var currentData = currentInstruction.HandleInstruction(register);
        globalCycle++;

        actualScreenBuilder.Append(currentPixel >= register - 1 && currentPixel <= register + 1 ? PixelOn : PixelOff);
    
        if(globalCycle == CycleOffset + counter * ScreenWidth) {
            counter++;

            sum += globalCycle * register;
        }

        currentPixel = (currentPixel + 1) % ScreenWidth;

        if (currentPixel == 0) {
            Console.WriteLine(actualScreenBuilder);
            actualScreenBuilder.Clear();
        }
        register = currentData.index;
    }
}
