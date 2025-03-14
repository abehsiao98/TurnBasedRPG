namespace TurnBasedRPG.Units.States;

public class NormalState(Role role) : State(role)
{
    public override void EntryState() => Role.SetState(this);
    protected override void ExitState() { }
    protected override bool IsExitState() => true;
}