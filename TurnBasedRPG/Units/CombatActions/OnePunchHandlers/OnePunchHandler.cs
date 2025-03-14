namespace TurnBasedRPG.Units.CombatActions.OnePunchHandlers;
public abstract class OnePunchHandler(OnePunchHandler? next)
{
    private OnePunchHandler? _next = next;
    public void Handle(Role caster, Role target, int increase, Action<Role, List<Role>, bool, int> printCombatMessage)
    {
        if (IsMatch(target))
            Execute(caster, target, increase, printCombatMessage);
        else if (_next != null)
            _next.Handle(caster, target, increase, printCombatMessage);
    }
    protected abstract bool IsMatch(Role target);
    protected abstract void Execute(Role caster, Role target, int increase, Action<Role, List<Role>, bool, int> printCombatMessage);
}