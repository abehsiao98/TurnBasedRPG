using TurnBasedRPG.Constnats;
using TurnBasedRPG.Units.States;
using TurnBasedRPG.Utilities;

namespace TurnBasedRPG.Units.CombatActions;

public class CheerUp : CombatAction
{
    protected override bool IsEnoughMp(int mp) => mp >= GameConfig.CombatAction.RequiredMp.CheerUp;
    protected override bool IsCorrectTargets(Troop troop, List<Role> targets) => (troop.GetAliveRoles().Count > GameConfig.CombatAction.TargetCount.CheerUp ? targets.Count == GameConfig.CombatAction.TargetCount.CheerUp : targets.Count <= GameConfig.CombatAction.TargetCount.CheerUp) && targets.All(role => troop.GetAliveRoles().Contains(role));
    protected override List<Role> SelectTargets(Role caster, Troop troop) => SelectTargetsWithPrompt(troop.GetAliveRoles(), GameConfig.CombatAction.TargetCount.CheerUp);
    protected override void Action(Role caster, List<Role> targets, int increase)
    {
        PrintCombatMessage(caster, targets, false, 0);
        caster.ReduceMp(GameConfig.CombatAction.RequiredMp.CheerUp);
        targets.ForEach(target => new CheerUpState(target).EntryState());
    }
    protected override List<Role> SelectTargetsWithAi(Role caster, Troop troop)
    {
        if (troop.GetAliveRoles().Count <= 3)
            return troop.GetAliveRoles();
        return troop.GetAliveRoles().OrderBy(role => RandomSingleton.Instance.Next()).Take(GameConfig.CombatAction.TargetCount.CheerUp).ToList();
    }
}