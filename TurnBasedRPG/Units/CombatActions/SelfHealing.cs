using TurnBasedRPG.Constnats;

namespace TurnBasedRPG.Units.CombatActions;

public class SelfHealing : CombatAction
{
    protected override bool IsEnoughMp(int mp) => mp >= GameConfig.CombatAction.RequiredMp.SelfHealing;
    protected override bool IsCorrectTargets(Troop troop, List<Role> targets) => true;
    protected override List<Role> SelectTargets(Role caster, Troop troop) => new() { caster };
    protected override void Action(Role caster, List<Role> targets, int increase)
    {
        PrintCombatMessage(caster, targets, false, 0);
        caster.ReduceMp(GameConfig.CombatAction.RequiredMp.SelfHealing);
        targets.ForEach(target => target.Heal(GameConfig.CombatAction.Effect.SelfHealingAmount));
    }
    protected override List<Role> SelectTargetsWithAi(Role caster, Troop troop) => new() { caster };
}