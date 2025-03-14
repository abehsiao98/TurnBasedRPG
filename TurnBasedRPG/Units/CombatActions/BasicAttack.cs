using TurnBasedRPG.Constnats;
using TurnBasedRPG.Utilities;

namespace TurnBasedRPG.Units.CombatActions;

public class BasicAttack : CombatAction
{
    protected override bool IsEnoughMp(int mp) => true;
    protected override bool IsCorrectTargets(Troop troop, List<Role> targets) => targets.Count == GameConfig.CombatAction.TargetCount.BasicAttack && targets.All(role => troop.GetEnemyAliveRoles().Contains(role));
    protected override List<Role> SelectTargets(Role caster, Troop troop) => SelectTargetsWithPrompt(troop.GetEnemyAliveRoles(), GameConfig.CombatAction.TargetCount.BasicAttack);
    protected override void Action(Role caster, List<Role> targets, int increase)
    {
        PrintCombatMessage(caster, targets, true, caster.Str + increase);
        targets.ForEach(target => target.DamageAUnit(caster.Str));
    }
    protected override List<Role> SelectTargetsWithAi(Role caster, Troop troop)
    {
        if (troop.GetEnemyAliveRoles().Count <= GameConfig.CombatAction.TargetCount.BasicAttack)
            return troop.GetEnemyAliveRoles();
        return troop.GetEnemyAliveRoles().OrderBy(role => RandomSingleton.Instance.Next()).Take(GameConfig.CombatAction.TargetCount.BasicAttack).ToList();
    }
}