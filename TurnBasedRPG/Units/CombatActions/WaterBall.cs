using TurnBasedRPG.Constnats;
using TurnBasedRPG.Utilities;

namespace TurnBasedRPG.Units.CombatActions;

public class WaterBall : CombatAction
{
    protected override bool IsEnoughMp(int mp) => mp >= GameConfig.CombatAction.RequiredMp.WaterBall;
    protected override bool IsCorrectTargets(Troop troop, List<Role> targets) => targets.Count == GameConfig.CombatAction.TargetCount.WaterBall && targets.All(role => troop.GetEnemyAliveRoles().Contains(role));
    protected override List<Role> SelectTargets(Role caster, Troop troop) => SelectTargetsWithPrompt(troop.GetEnemyAliveRoles(), GameConfig.CombatAction.TargetCount.WaterBall);
    protected override void Action(Role caster, List<Role> targets, int increase)
    {
        PrintCombatMessage(caster, targets, true, GameConfig.CombatAction.Damage.WaterBall + increase);
        caster.ReduceMp(GameConfig.CombatAction.RequiredMp.WaterBall);
        targets.ForEach(target => target.DamageAUnit(GameConfig.CombatAction.Damage.WaterBall));
    }
    protected override List<Role> SelectTargetsWithAi(Role caster, Troop troop)
    {
        if (troop.GetEnemyAliveRoles().Count <= GameConfig.CombatAction.TargetCount.WaterBall)
            return troop.GetEnemyAliveRoles();
        return troop.GetEnemyAliveRoles().OrderBy(role => RandomSingleton.Instance.Next()).Take(GameConfig.CombatAction.TargetCount.WaterBall).ToList();
    }
}