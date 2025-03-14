using TurnBasedRPG.Constnats;
using TurnBasedRPG.Units.States;

namespace TurnBasedRPG.Units.CombatActions.OnePunchHandlers;

public class CheerUpStateHandler(OnePunchHandler? next) : OnePunchHandler(next)
{
    protected override bool IsMatch(Role target) => target.GetState() is CheerUpState;
    protected override void Execute(Role caster, Role target, int increase, Action<Role, List<Role>, bool, int> printCombatMessage)
    {
        printCombatMessage(caster, new() { target }, true, GameConfig.CombatAction.Damage.OnePunchInCheerUpState + increase);
        target.DamageAUnit(GameConfig.CombatAction.Damage.OnePunchInCheerUpState);
        new NormalState(target).EntryState();
    }
}