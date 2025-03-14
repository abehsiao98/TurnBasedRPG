using TurnBasedRPG.Constnats;

namespace TurnBasedRPG.Units.CombatActions;

public class SelfExplosion : CombatAction
{
    protected override bool IsEnoughMp(int mp) => mp >= GameConfig.CombatAction.RequiredMp.SelfExplosion;
    protected override bool IsCorrectTargets(Troop troop, List<Role> targets) => true;
    protected override List<Role> SelectTargets(Role caster, Troop troop) => troop.GetAliveRoles().Concat(troop.GetEnemyAliveRoles()).ToList();
    protected override void Action(Role caster, List<Role> targets, int increase)
    {
        PrintCombatMessage(caster, targets, true, GameConfig.CombatAction.Damage.SelfExplosion + increase);
        caster.ReduceMp(GameConfig.CombatAction.RequiredMp.SelfExplosion);
        caster.DamageAUnit(caster.Hp);
        targets.ForEach(target => target.DamageAUnit(GameConfig.CombatAction.Damage.SelfExplosion));
    }
    protected override List<Role> SelectTargetsWithAi(Role caster, Troop troop) => troop.GetAliveRoles().Concat(troop.GetEnemyAliveRoles()).ToList();
}