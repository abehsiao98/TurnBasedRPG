using TurnBasedRPG.Constnats;
using TurnBasedRPG.Units.Observers;
using TurnBasedRPG.Utilities;

namespace TurnBasedRPG.Units.CombatActions;

public class Summon : CombatAction
{
    protected override bool IsEnoughMp(int mp) => mp >= GameConfig.CombatAction.RequiredMp.Summon;
    protected override bool IsCorrectTargets(Troop troop, List<Role> targets) => true;
    protected override List<Role> SelectTargets(Role caster, Troop troop) => new();
    protected override void Action(Role caster, List<Role> targets, int increase)
    {
        PrintCombatMessage(caster, targets, false, 0);
        caster.ReduceMp(GameConfig.CombatAction.RequiredMp.Summon);
        var slime = SlimeFactory.CreateSlime(caster);
        caster.Register(new SlimeObserver(caster));
        caster.GetTroop().Register(slime);
    }
    protected override List<Role> SelectTargetsWithAi(Role caster, Troop troop) => new();
}