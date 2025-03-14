using TurnBasedRPG.Units.CombatActions;

namespace TurnBasedRPG.Units;

public class Hero(string name, int hp, int mp, int str, Dictionary<string, CombatAction> combatActionDic) : Role(name, hp, mp, str, combatActionDic)
{
    private static Hero? _instance;
    public static void CreateInstance(string name, int hp, int mp, int str, Dictionary<string, CombatAction> combatActionDic)
    {
        if (_instance == null)
            _instance = new Hero(name, hp, mp, str, combatActionDic);
    }
    public static Hero GetInstance()
    {
        if (_instance == null)
            throw new InvalidOperationException("Hero instance is not created");
        return _instance;
    }
}