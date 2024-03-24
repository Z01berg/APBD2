using APBD2;

class Program
{
    public static void Main(string[] args)
    {
        Ship.CreateExmple_Ship();
        Console.WriteLine(_showListShip());
        Console.WriteLine(_showListContainer());
    }

    /*Default start of Terminal*/
    private static string _showListContainer()
    {
        string a = $"░░░▒▒▒▓▓▓▓ Lista kontenerów: ▓▓▓▓▒▒▒░░░\n" +
                   $"█ Wszystkich kontenerów: {_containerCount}\n" +
                   $"╔═════════════╦════════════╦══════════════╦═══════╦═══════════════╦════════╗\n" +
                   $"║ Weight_Load ║ Weight_Max ║ Weight_Shell ║ Depth ║ Serial_Number ║ Height ║\n" +
                   $"╠═════════════╬════════════╬══════════════╬═══════╬═══════════════╬════════╣\n" +
                   $"{Container.DrawContainer()}";
        return a;
    }
    
    private static int _containerCount { get { return Container.DB_Container.Count; } }
    
    private static string _showListShip()
    {
        string a = $"░░░▒▒▒▓▓▓▓ Lista kontenerowców: ▓▓▓▓▒▒▒░░░\n" +
                   $"█ Wszystkich kontenerowców: {_shipCount}\n" +
                   $"╔═════════╦═══════╦══════════════╦════════════╗\n" +
                   $"║   Name  ║ Speed ║   Cont_Num   ║   Weight   ║\n" +
                   $"╠═════════╬═══════╬══════════════╬════════════╣\n" +
                   $"{Ship.DrawShip()}";
        return a;
    }
    
    private static int _shipCount { get { return Ship.DB_Ship.Count; } }

    
}

