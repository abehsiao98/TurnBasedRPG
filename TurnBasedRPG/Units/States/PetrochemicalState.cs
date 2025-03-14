using TurnBasedRPG.Constnats;
namespace TurnBasedRPG.Units.States;

public class PetrochemicalState(Role role) : State(role)
{
    public override void EntryState() => Role.SetState(this);
    protected override void ExitState() => new NormalState(Role).EntryState();
    protected override bool IsExitState() => Round > GameConfig.State.Round.Petrochemical;
    public override void Action() { }
}