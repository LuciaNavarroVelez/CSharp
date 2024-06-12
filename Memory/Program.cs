internal class Program
{
    private static void Main(string[] args)
    {
        Memory memory = new();

        MemoryRenderer memoryRenderer = new(memory);
        memory.ChooseGameLevel();
        
        do{
            Console.Clear();
            memoryRenderer.Show();
            memory.Run();
        }while(!memory.IsEndOfTheGame());
        
        Console.Clear();
        memoryRenderer.Show();

        Console.WriteLine("\nEND!!");
    }
}