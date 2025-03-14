namespace TurnBasedRPG.Units.Observers;

public class SlimeObserver(Role summoner) : IRoleObserver
{
    private Role _summoner = summoner;
    public void Notify(Role role)
    {
        if (_summoner.IsAlive())
            _summoner.Heal(30);
        role.UnRegister(this);
    }
}