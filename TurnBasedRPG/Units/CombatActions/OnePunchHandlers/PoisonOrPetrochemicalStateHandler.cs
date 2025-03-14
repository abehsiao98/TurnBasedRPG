using TurnBasedRPG.Constnats;
using TurnBasedRPG.Units.States;

namespace TurnBasedRPG.Units.CombatActions.OnePunchHandlers;

public class PoisonOrPetrochemicalStateHandler(OnePunchHandler? next) : OnePunchHandler(next)
{
    protected override bool IsMatch(Role target) => target.GetState() is PoisonedState || target.GetState() is PetrochemicalState;
    protected override void Execute(Role caster, Role target, int increase, Action<Role, List<Role>, bool, int> printCombatMessage)
    {
        for (var i = 0; i < GameConfig.CombatAction.AttackHits.OnePunchInPoisonOrPetrochemicalState; i++)
        {
            printCombatMessage(caster, new() { target }, true, GameConfig.CombatAction.Damage.OnePunchInPoisonOrPetrochemicalState + increase);
            target.DamageAUnit(GameConfig.CombatAction.Damage.OnePunchInPoisonOrPetrochemicalState + increase);
        }
    }
}