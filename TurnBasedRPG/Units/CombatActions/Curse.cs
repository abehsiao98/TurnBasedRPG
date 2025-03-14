using TurnBasedRPG.Constnats;
using TurnBasedRPG.Units.Observers;
using TurnBasedRPG.Utilities;

namespace TurnBasedRPG.Units.CombatActions;

public class Curse : CombatAction
{
    protected override bool IsEnoughMp(int mp) => mp >= GameConfig.CombatAction.RequiredMp.Curse;
    protected override bool IsCorrectTargets(Troop troop, List<Role> targets) => targets.Count == GameConfig.CombatAction.TargetCount.Curse && targets.All(role => troop.GetEnemyAliveRoles().Contains(role));
    protected override List<Role> SelectTargets(Role caster, Troop troop) => SelectTargetsWithPrompt(troop.GetEnemyAliveRoles(), GameConfig.CombatAction.TargetCount.Curse);
    protected override void Action(Role caster, List<Role> targets, int increase)
    {
        PrintCombatMessage(caster, targets, false, 0);
        caster.ReduceMp(GameConfig.CombatAction.RequiredMp.Curse);
        targets.ForEach(target => caster.Register(new CurserObserver(target)));
    }
    protected override List<Role> SelectTargetsWithAi(Role caster, Troop troop)
    {
        if (troop.GetEnemyAliveRoles().Count <= GameConfig.CombatAction.TargetCount.Curse)
            return troop.GetEnemyAliveRoles();
        return troop.GetEnemyAliveRoles().OrderBy(role => RandomSingleton.Instance.Next()).Take(GameConfig.CombatAction.TargetCount.Curse).ToList();
    }
}