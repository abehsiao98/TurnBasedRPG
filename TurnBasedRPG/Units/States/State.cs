namespace TurnBasedRPG.Units.States;

public abstract class State(Role role)
{
    protected Role Role = role;
    protected int Round { get; private set; }
    public abstract void EntryState();
    protected abstract void ExitState();
    protected abstract bool IsExitState();

    public void RoundHandle()
    {
        Round++;
        if (IsExitState())
        {
            Round = 0;
            ExitState();
        }
    }
    public virtual void Action() => Role.ActualAction(0);
}