using System.Text;
using TurnBasedRPG.Units.CombatActions;
using TurnBasedRPG.Units.Observers;
using TurnBasedRPG.Units.States;

namespace TurnBasedRPG.Units;

public abstract class Role
{
    private State _state;
    private Troop? _troop;
    private Dictionary<string, CombatAction> _combatActionDic = new();
    private List<IRoleObserver> _roleObservers = new();
    public string Name { get; private set; }
    public int Hp { get; private set; }
    public int Mp { get; private set; }
    public int Str { get; private set; }

    protected Role(string name, int hp, int mp, int str, Dictionary<string, CombatAction> combatActionDic)
    {
        Name = name;
        Hp = Math.Max(hp, 0);
        Mp = Math.Max(mp, 0);
        Str = Math.Max(str, 0);
        _combatActionDic = combatActionDic;
        _state = new NormalState(this);
    }
    public bool IsDead() => Hp == 0;
    public bool IsAlive() => Hp > 0;
    public void Action()
    {
        _state.RoundHandle();
        _state.Action();
    }
    public virtual void ActualAction(int increase)
    {
        Console.WriteLine($"It's the {Name}'s turn (Hp: {Hp}, Mp: {Mp}, STR: {Str}, State: {_state.GetType().Name})");
        var stringBuilder = new StringBuilder("Choose an action");
        foreach (var item in _combatActionDic)
        {
            stringBuilder.Append($" ({item.Key}) {item.Value.GetType().Name} ");
        }
        Console.WriteLine(stringBuilder.ToString());
        while (true)
        {
            var input = Console.ReadLine();
            if (_combatActionDic.TryGetValue(input, out var combatAction) && combatAction.TryAction(this, _troop, increase))
            {
                break;
            }
            Console.WriteLine("Invalid action. Please try again.");
        }
    }
    public void DamageAUnit(int damage)
    {
        Hp = Math.Max(Hp - damage, 0);
        if (IsDead())
        {
            Notify(this);
            _troop.UnRegister(this);
        }
    }
    public void Heal(int amount) => Hp += amount;
    public void ReduceMp(int mp) => Math.Max(Mp -= mp, 0);
    public void Register(IRoleObserver roleObserver)
    {
        if (!_roleObservers.Contains(roleObserver))
            _roleObservers.Add(roleObserver);
    }
    public void UnRegister(IRoleObserver roleObserver)
    {
        if (!_roleObservers.Contains(roleObserver))
        {
            Console.WriteLine("Not registered can't unregister");
            return;
        }
        _roleObservers.Remove(roleObserver);
    }
    private void Notify(Role role) => _roleObservers.ForEach(o => o.Notify(role));
    public Dictionary<string, CombatAction> GetCombatActionDic() => _combatActionDic;
    public Troop GetTroop() => _troop;
    public void SetTroop(Troop? troop)
    {
        _troop = troop;
        if (troop != null)
            Name = $"[{_troop.Name}]" + Name;
    }
    public State GetState() => _state;
    public void SetState(State state) => _state = state;
}