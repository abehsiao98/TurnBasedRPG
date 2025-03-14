using TurnBasedRPG.Units.AiActions;
using TurnBasedRPG.Units.CombatActions;

namespace TurnBasedRPG.Units;

public class Slime(string name, int hp, int mp, int str, Role role, Dictionary<string, CombatAction> combatActionDic, IAiAction aiAction) : Ai(name, hp, mp, str, combatActionDic, aiAction)
{
}