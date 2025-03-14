using TurnBasedRPG.Constnats;
using TurnBasedRPG.Units.CombatActions.OnePunchHandlers;
using TurnBasedRPG.Utilities;

namespace TurnBasedRPG.Units.CombatActions;

public class OnePunch(OnePunchHandler onePunchHandler) : CombatAction
{
    private OnePunchHandler _onePunchHandler = onePunchHandler;
    protected override bool IsEnoughMp(int mp) => mp >= GameConfig.CombatAction.RequiredMp.OnePunch;
    protected override bool IsCorrectTargets(Troop troop, List<Role> targets) => targets.Count == GameConfig.CombatAction.TargetCount.OnePunch && targets.All(role => troop.GetEnemyAliveRoles().Contains(role));
    protected override List<Role> SelectTargets(Role caster, Troop troop) => SelectTargetsWithPrompt(troop.GetEnemyAliveRoles(), GameConfig.CombatAction.TargetCount.OnePunch);
    protected override void Action(Role caster, List<Role> targets, int increase)
    {
        PrintCombatMessage(caster, targets, false, 0);
        caster.ReduceMp(GameConfig.CombatAction.RequiredMp.OnePunch);
        foreach (var target in targets)
        {
            _onePunchHandler.Handle(caster, target, increase, PrintCombatMessage);
        }
    }
    protected override List<Role> SelectTargetsWithAi(Role caster, Troop troop)
    {
        if (troop.GetEnemyAliveRoles().Count <= GameConfig.CombatAction.TargetCount.OnePunch)
            return troop.GetEnemyAliveRoles();
        return troop.GetEnemyAliveRoles().OrderBy(role => RandomSingleton.Instance.Next()).Take(GameConfig.CombatAction.TargetCount.OnePunch).ToList();
    }
}