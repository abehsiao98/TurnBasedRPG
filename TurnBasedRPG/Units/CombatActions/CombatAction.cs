using System.Text;

namespace TurnBasedRPG.Units.CombatActions;

public abstract class CombatAction
{
    protected abstract bool IsEnoughMp(int mp);
    protected abstract List<Role> SelectTargets(Role caster, Troop troop);
    protected abstract List<Role> SelectTargetsWithAi(Role caster, Troop troop);
    protected abstract bool IsCorrectTargets(Troop troop, List<Role> targets);
    protected abstract void Action(Role caster, List<Role> targets, int increase);
    public bool TryAction(Role role, Troop troop, int increase)
    {
        if (!IsEnoughMp(role.Mp))
            return false;
        var selectedRoles = new List<Role>();
        do
        {
            selectedRoles = SelectTargets(role, troop);
        }
        while (!IsCorrectTargets(troop, selectedRoles));
        Action(role, selectedRoles, increase);
        return true;
    }
    public bool AiAction(Role role, Troop troop, int increase)
    {
        if (!IsEnoughMp(role.Mp))
            return false;
        var selectedRole = new List<Role>();
        selectedRole = SelectTargetsWithAi(role, troop);
        Action(role, selectedRole, increase);
        return true;
    }
    protected List<Role> SelectTargetsWithPrompt(List<Role> targets, int targetCount)
    {
        if (targets.Count <= targetCount)
            return targets;
        var stringBuilder = new StringBuilder($"Choose {targetCount} target: ");
        foreach (var role in targets)
        {
            stringBuilder.Append($" ({targets.IndexOf(role)}) {role.Name}");
        }
        Console.WriteLine(stringBuilder.ToString());
        while (true)
        {
            var indices = Console.ReadLine();
            if (indices!.Split(" ").All(index => int.TryParse(index, out int indexValue) && (indexValue >= 0 && indexValue < targets.Count)))
                return indices.Split(" ").Select(index => targets[int.Parse(index)]).ToList();
            Console.WriteLine("Invalid input. Please try again.");
        }
    }
    protected void PrintCombatMessage(Role caster, List<Role> targets, bool isDamageDealt, int damage)
    {
        var stringBuilder = new StringBuilder($"The {caster.Name} used a {this.GetType().Name} on ");
        targets.ForEach(target => stringBuilder.Append($"{target.Name} "));
        Console.WriteLine(stringBuilder.ToString());
        if (isDamageDealt)
            targets.ForEach(target => Console.WriteLine($"{caster.Name} dealt {damage} damage to {target.Name}"));
    }
}