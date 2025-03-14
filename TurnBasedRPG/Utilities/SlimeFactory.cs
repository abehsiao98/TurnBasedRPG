using TurnBasedRPG.Units.CombatActions;
using TurnBasedRPG.Units;
using TurnBasedRPG.Units.AiActions;

namespace TurnBasedRPG.Utilities;

public static class SlimeFactory
{
    private static int _count;
    private static readonly Dictionary<string, CombatAction> _combatActions = new Dictionary<string, CombatAction>
    {
        { "0", new BasicAttack() }
    };
    private static readonly IAiAction _aiAction = new AiAction();
    public static Slime CreateSlime(Role role)
    {
        _count++;
        return new Slime($"Slime{_count}", 100, 0, 50, role, _combatActions, _aiAction);
    }
}