using System.Text;
using TurnBasedRPG;
using TurnBasedRPG.Units.CombatActions;
using TurnBasedRPG.Units;
using TurnBasedRPG.Units.CombatActions.OnePunchHandlers;
using TurnBasedRPG.Units.AiActions;

Console.OutputEncoding = Encoding.UTF8;
var t1 = new Troop("1");
var t2 = new Troop("2");
var onePunchHandler = new HpAboveFiveHundredHandler(new PoisonOrPetrochemicalStateHandler(new CheerUpStateHandler(new NormalStateHandler(null))));
var combatActionDic = new Dictionary<string, CombatAction>()
{
    {"0", new BasicAttack()},
    {"1", new WaterBall()},
    {"2", new FireBall()},
    {"3", new Petrochemical()},
    {"4", new Poison()},
    {"5", new Summon()},
    {"6", new SelfExplosion()},
    {"7", new CheerUp()},
    {"8", new Curse()},
    {"9", new OnePunch(onePunchHandler)},
};

var aiAction = new AiAction();
Hero.CreateInstance("Abe", 5000, 1000, 100, combatActionDic);
var abe = Hero.GetInstance();
var abe2 = new Ai("ally1", 500, 100, 100, combatActionDic, aiAction);
var abe3 = new Ai("enemy1", 300, 100, 100, combatActionDic, aiAction);
var abe4 = new Ai("enemy2", 300, 100, 100, combatActionDic, aiAction);
var abe5 = new Ai("enemy3", 300, 100, 100, combatActionDic, aiAction);
t1.Register(abe);
t1.Register(abe2);
t2.Register(abe3);
t2.Register(abe4);
t2.Register(abe5);
var battle = new Battle((t1, t2));
var rpg = new RPG(battle);
rpg.Start();