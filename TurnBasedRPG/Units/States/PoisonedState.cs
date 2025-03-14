using TurnBasedRPG.Constnats;

namespace TurnBasedRPG.Units.States;

public class PoisonedState(Role role) : State(role)
{
    public override void EntryState() => Role.SetState(this);
    protected override void ExitState() => new NormalState(Role).EntryState();
    protected override bool IsExitState() => Round > GameConfig.State.Round.Poison;
    public override void Action()
    {
        Role.DamageAUnit(GameConfig.CombatAction.Effect.PoisonDamage);
        if (Role.IsAlive())
            base.Action();
    }
}