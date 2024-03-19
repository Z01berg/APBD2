namespace APBD2;

class Container
{
    public static List<Container> DB_Container = new List<Container>();

    private int _weightLoad; //in kg
    private int _height; //in cm
    private int _weightShell; //in kg
    private int _depth; //in cm
    private string _serialNumber = ReturnID();
    private int _weightMax; //in kg


    public Container(int weightLoad, int height, int weightShell, int depth, string serialNumber, int weightMax)
    {
        this._weightLoad = weightLoad;
        this._height = height;
        this._weightShell = weightShell;
        this._depth = depth;
        this._serialNumber = serialNumber;
        this._weightMax = weightMax;
        DB_Container.Add(this);
    }

    public static string CreateSerialNumber(char kind_C, string id)
    {
        string serialNumber = $"KON-{kind_C}-{id}";
        return serialNumber;
    }

    
    /* Random Generation Number */
    public static string GenerateID()
    {
        Guid guid = Guid.NewGuid();

        string guidString = guid.ToString("N");
        string firstFiveChars = guidString.Substring(0, 5);

        string code = "";
        foreach (char c in firstFiveChars)
        {
            if (char.IsLetter(c))
            {
                int unicodeValue = (int)c;
                int digitalValue = unicodeValue % 10;
                code += digitalValue.ToString();
            }
            else
            {
                code += c;
            }
        }

        return code;
    }

    public static bool CheckFalseID(string id)
    {
        foreach (var con in DB_Container)
        {
            string check = con._serialNumber.Substring(5);
            if (check == id)
            {
                return true;
            }
        }

        return false;
    }

    public static string ReturnID()
    {
        string id;

        do
        {
            id = GenerateID();
        } while (CheckFalseID(id));

        return id;
    }

    
    /* Lodaout */
    public static void ClearLoad(string id)
    {
        foreach (var con in DB_Container)
        {
            if (con._serialNumber.Equals(id))
            {
                con._weightLoad = 0;
            }
        }
    }

    public static void LoadLoad(string id)
    {
        foreach (var con in DB_Container)
        {
            if (con._serialNumber.Equals(id))
            {
                int loadMass = con._weightMax - (con._weightLoad + con._weightShell);
                if (loadMass < 0)
                {
                    throw new OverfillException("Masa ładunku przekracza pojemność kontenera.");
                }
            }
        }
    }
}

internal class OverfillException : Exception
{
    public OverfillException(string masaŁadunkuPrzekraczaPojemnośćKontenera)
    {
        throw new NotImplementedException();
    }
}