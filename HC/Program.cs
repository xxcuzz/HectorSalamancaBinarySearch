namespace HC;

public class Program
{
    public static void Main()
    {
        var chars = new List<char>() { 
            'A', 'B', 'C', 'D', 
            'E', 'F', 'G', 'H', 
            'I', 'J', 'K', 'L', 
            'M', 'N', 'O', 'P', 
            'Q', 'R', 'S', 'T', 
            'U', 'V', 'W', 'X', 
            'Y', 'Z' 
        };

        var result = string.Empty;
        
        for (; ; )
        {
            var ch = FindLetter(chars, 0, chars.Count - 1);
            result += ch;
            Console.Clear();
            Console.WriteLine(result);
        }
    }

    private static char FindLetter(List<char> chars, int start, int end)
    {
        if (end - start == 0)
        {
            return chars[start];
        }

        var searchString = UpdateSearchString(new List<char>(chars), start, end);
        ShowSearchString(searchString);

        char key = Console.ReadKey().KeyChar;
        Console.Write("\b");

        if (char.ToUpper(key) == 'D')
        {
            Console.WriteLine("*DING!!!*");
            return FindLetter(chars, searchString.IndexOf(' '), end);
        }
        else
        {
            return FindLetter(chars, start, searchString.IndexOf(' ') - 1);
        }
    }

    private static List<char> UpdateSearchString(List<char> chars, int start, int end)
    {
        int mid = (end + start) / 2;
        chars.Insert(mid + 1, ' ');

        return chars;
    }

    private static void ShowSearchString(List<char> chars)
    {
        foreach (var ch in chars)
        {
            Console.Write(ch);
        }

        Console.WriteLine();
    }
}