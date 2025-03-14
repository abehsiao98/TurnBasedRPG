namespace TurnBasedRPG;

public class RPG(Battle battle)
{
    private Battle _battle = battle;
    public void Start() => _battle.Start();
}