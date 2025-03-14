using TurnBasedRPG.Constnats;
using TurnBasedRPG.Units.States;
using TurnBasedRPG.Utilities;

namespace TurnBasedRPG.Units.CombatActions;

public class Poison : CombatAction
{
    protected override bool IsEnoughMp(int mp) => mp >= GameConfig.CombatAction.RequiredMp.Poison;
    protected override bool IsCorrectTargets(Troop troop, List<Role> targets) => targets.Count == GameConfig.CombatAction.TargetCount.Poison && targets.All(role => troop.GetEnemyAliveRoles().Contains(role));
    protected override List<Role> SelectTargets(Role caster, Troop troop) => SelectTargetsWithPrompt(troop.GetEnemyAliveRoles(), GameConfig.CombatAction.TargetCount.Poison);
    protected override void Action(Role caster, List<Role> targets, int increase)
    {
        PrintCombatMessage(caster, targets, false, 0);
        caster.ReduceMp(GameConfig.CombatAction.RequiredMp.Poison);
        targets.ForEach(target => new PoisonedState(target).EntryState());
    }
    protected override List<Role> SelectTargetsWithAi(Role caster, Troop troop)
    {
        if (troop.GetEnemyAliveRoles().Count <= GameConfig.CombatAction.TargetCount.Poison)
            return troop.GetEnemyAliveRoles();
        return troop.GetEnemyAliveRoles().OrderBy(role => RandomSingleton.Instance.Next()).Take(GameConfig.CombatAction.TargetCount.Poison).ToList();
    }
}