namespace TurnBasedRPG.Utilities;

public class RandomSingleton
{
    private static readonly Random _instance = new Random();
    private RandomSingleton() { }
    public static Random Instance => _instance;
}
