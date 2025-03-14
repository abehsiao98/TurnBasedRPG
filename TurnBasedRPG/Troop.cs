using System.Data;
using TurnBasedRPG.Units;

namespace TurnBasedRPG;

public class Troop(string name)
{
    public readonly string Name = name;
    private LinkedList<Role> _roles = new();
    private Troop? _enemyTroop;
    public bool IsAnnihilated() => _roles.All(role => role.IsDead()) || _roles.Any(role => role is Hero && role.IsDead());

    public void Start()
    {
        if (_roles.Count == 0)
            return;
        var currentNode = _roles.First;
        while (currentNode != null && _enemyTroop.GetAliveRoles().Count != 0)
        {
            currentNode.Value.Action();
            currentNode = currentNode.Next;
        }
    }

    public void SetEnemyTroop(Troop enemyTroop) => _enemyTroop = enemyTroop;
    public void Register(Role role)
    {
        if (role.GetTroop() != null)
            throw new InvalidOperationException("This role already exists in the troop");
        _roles.AddLast(role);
        role.SetTroop(this);
    }

    public void UnRegister(Role role)
    {
        if (role.GetTroop() != this)
            throw new InvalidOperationException("This role doesn't exist in the troop");
        _roles.Remove(role);
        role.SetTroop(null);
    }
    public List<Role> GetAliveRoles() => _roles.Where(role => role.IsAlive()).ToList();

    public List<Role> GetEnemyAliveRoles()
    {
        if (_enemyTroop == null)
            throw new InvalidOperationException("Enemy troop isn't set");
        return _enemyTroop.GetAliveRoles();
    }
}