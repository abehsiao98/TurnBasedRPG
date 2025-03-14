namespace TurnBasedRPG;

public class Battle
{
    private (Troop, Troop) _troops;
    public Battle((Troop, Troop) troop)
    {
        _troops = troop;
        _troops.Item1.SetEnemyTroop(_troops.Item2);
        _troops.Item2.SetEnemyTroop(_troops.Item1);
    }
    public void Start()
    {
        while (!_troops.Item1.IsAnnihilated() && !_troops.Item2.IsAnnihilated())
        {
            _troops.Item1.Start();
            _troops.Item2.Start();
        }
        Console.WriteLine("Game over");
    }
}