namespace TurnBasedRPG.Units.AiActions;

public class AiAction : IAiAction
{
    public void Action(Ai ai, int increase)
    {
        while (true)
        {
            var index = (ai.Seed % ai.GetCombatActionDic().Count()).ToString();
            if (ai.GetCombatActionDic().TryGetValue(index, out var combatAction) && combatAction.AiAction(ai, ai.GetTroop(), increase))
            {
                break;
            }
        }
    }
}