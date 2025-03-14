using TurnBasedRPG.Units.AiActions;
using TurnBasedRPG.Units.CombatActions;

namespace TurnBasedRPG.Units;

public class Ai(string name, int hp, int mp, int str, Dictionary<string, CombatAction> combatActionDic, IAiAction aiAction) : Role(name, hp, mp, str, combatActionDic)
{
    private IAiAction _aiAction = aiAction;
    public int Seed { get; set; }
    public void AddSeed() => Seed++;
    public override void ActualAction(int increase) => _aiAction.Action(this, increase);
}