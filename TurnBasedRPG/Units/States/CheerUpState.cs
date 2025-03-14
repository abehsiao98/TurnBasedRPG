using TurnBasedRPG.Constnats;

namespace TurnBasedRPG.Units.States;

public class CheerUpState(Role role) : State(role)
{
    public override void EntryState() => Role.SetState(this);
    protected override void ExitState() => Role.SetState(new NormalState(Role));
    protected override bool IsExitState() => Round > GameConfig.State.Round.CheerUp;
    public override void Action() => Role.ActualAction(GameConfig.State.Increase.CheerUp);
}