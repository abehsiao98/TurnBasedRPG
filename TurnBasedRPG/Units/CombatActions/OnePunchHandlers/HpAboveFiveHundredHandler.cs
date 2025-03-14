using TurnBasedRPG.Constnats;

namespace TurnBasedRPG.Units.CombatActions.OnePunchHandlers;

public class HpAboveFiveHundredHandler(OnePunchHandler? next) : OnePunchHandler(next)
{
    protected override bool IsMatch(Role target) => target.Hp >= 500;
    protected override void Execute(Role caster, Role target, int increase, Action<Role, List<Role>, bool, int> printCombatMessage)
    {
        printCombatMessage(caster, new() { target }, true, GameConfig.CombatAction.Damage.OnePunchInHpAboveFiveHundred + increase);
        target.DamageAUnit(GameConfig.CombatAction.Damage.OnePunchInHpAboveFiveHundred);
    }
}