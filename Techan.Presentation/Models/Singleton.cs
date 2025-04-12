namespace Techan.Presentation.Models;

public class Singleton
{
    public int Count { get; set; } = 0;

    public int Print()
    {
        return Count++;
    }
}
