using System.Text;
using AdventOfCodeEon.Instructions;
using AdventOfCodeEon.RayTube;

namespace AdventOfCodeEon;

class Program {
    static void Main(string[] args) {
        var commands = File.ReadAllLines("instructions.txt").ToList();
        var handler = new InstructionHandler(commands.ToArray());
        var cathodeRayTube = new CathodeRayTube();
        cathodeRayTube.Run(handler);
    }

}

