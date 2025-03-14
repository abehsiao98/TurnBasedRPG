using TurnBasedRPG.Constnats;

namespace TurnBasedRPG.Units.CombatActions;

public class FireBall : CombatAction
{
    protected override bool IsEnoughMp(int mp) => mp >= GameConfig.CombatAction.RequiredMp.FireBall;
    protected override bool IsCorrectTargets(Troop troop, List<Role> targets) => true;
    protected override List<Role> SelectTargets(Role caster, Troop troop) => troop.GetEnemyAliveRoles();
    protected override void Action(Role caster, List<Role> targets, int increase)
    {
        PrintCombatMessage(caster, targets, true, GameConfig.CombatAction.Damage.FireBall + increase);
        caster.ReduceMp(GameConfig.CombatAction.RequiredMp.FireBall);
        targets.ForEach(target => target.DamageAUnit(GameConfig.CombatAction.Damage.FireBall));
    }
    protected override List<Role> SelectTargetsWithAi(Role caster, Troop troop) => troop.GetEnemyAliveRoles();
}