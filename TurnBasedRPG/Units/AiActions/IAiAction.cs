namespace TurnBasedRPG.Units.AiActions;

public interface IAiAction
{
    void Action(Ai ai, int increase);
}