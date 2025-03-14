using TurnBasedRPG.Constnats;
using TurnBasedRPG.Units.States;
using TurnBasedRPG.Utilities;

namespace TurnBasedRPG.Units.CombatActions;

public class Petrochemical : CombatAction
{
    protected override bool IsEnoughMp(int mp) => mp >= GameConfig.CombatAction.RequiredMp.Petrochemical;
    protected override bool IsCorrectTargets(Troop troop, List<Role> targets) => targets.Count == GameConfig.CombatAction.TargetCount.Petrochemical && targets.All(role => troop.GetEnemyAliveRoles().Contains(role));

    protected override List<Role> SelectTargets(Role caster, Troop troop) => SelectTargetsWithPrompt(troop.GetEnemyAliveRoles(), GameConfig.CombatAction.TargetCount.Petrochemical);
    protected override void Action(Role caster, List<Role> targets, int increase)
    {
        PrintCombatMessage(caster, targets, false, 0);
        caster.ReduceMp(GameConfig.CombatAction.RequiredMp.Petrochemical);
        targets.ForEach(target => new PetrochemicalState(target).EntryState());
    }
    protected override List<Role> SelectTargetsWithAi(Role caster, Troop troop)
    {
        if (troop.GetEnemyAliveRoles().Count <= GameConfig.CombatAction.TargetCount.Petrochemical)
            return troop.GetEnemyAliveRoles();
        return troop.GetEnemyAliveRoles().OrderBy(role => RandomSingleton.Instance.Next()).Take(GameConfig.CombatAction.TargetCount.Petrochemical).ToList();
    }
}