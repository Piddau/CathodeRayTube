namespace AdventOfCodeEon.Instructions;

public enum InstructionType {
    AddX,
    Noop
}

public class Instruction {
    public InstructionType Type { get; private set; }
    public int Value { get; private set; }
    private int cycles = 1;
    public bool Completed { get; set; }

    public Instruction(InstructionType type, int val = 0)
    {
        Type = type;
        Value = val;
        if (type == InstructionType.AddX)
            cycles = 2;
        Completed = false;
    }

    public (int index, int cycle) HandleInstruction(int index) {
        if (Type == InstructionType.Noop) {
            Completed = true;
            return (index, 0);
        }
        if (--cycles == 0) {
            Completed = true;
            return (index + Value, 0);
        }
        return (index, cycles);
    }
}