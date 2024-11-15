namespace AdventOfCodeEon.Instructions;

public class InstructionHandler
{
    private List<Instruction> instructionList;
    private int currentIndex;

    public InstructionHandler(string[] instructions)
    {
        instructionList = instructions.Select(ParseInstruction).ToList();
        currentIndex = 0;
    }

    private static Instruction ParseInstruction(string instruction) {
        var splitInstruction = instruction.Split(' ');

        return splitInstruction.Length == 1 
        ? new Instruction(InstructionType.Noop) 
        : new Instruction(InstructionType.AddX, int.Parse(splitInstruction[1]));
    }

    public Instruction? GetNextInstructionInList()
    {
        while(currentIndex < instructionList.Count) {
            var instruction = instructionList[currentIndex];
            if (!instruction.Completed)
                return instruction;

            currentIndex++;
        }
        
        return null;
    }
}
