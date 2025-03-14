namespace TurnBasedRPG.Units.Observers;

public class CurserObserver(Role curseCaster) : IRoleObserver
{
    private Role _curseCaster = curseCaster;
    public void Notify(Role role)
    {
        if (_curseCaster.IsAlive())
            _curseCaster.Heal(role.Mp);
        role.UnRegister(this);
    }
}