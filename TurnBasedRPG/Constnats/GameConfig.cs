namespace TurnBasedRPG.Constnats;

public class GameConfig
{
    public partial class CombatAction
    {
        public partial class RequiredMp
        {
            public const int WaterBall = 50;
            public const int FireBall = 50;
            public const int SelfHealing = 50;
            public const int Petrochemical = 100;
            public const int Poison = 80;
            public const int Summon = 150;
            public const int SelfExplosion = 200;
            public const int CheerUp = 100;
            public const int Curse = 100;
            public const int OnePunch = 180;
        }
        public partial class TargetCount
        {
            public const int BasicAttack = 1;
            public const int WaterBall = 1;
            public const int CheerUp = 3;
            public const int Curse = 1;
            public const int OnePunch = 1;
            public const int Petrochemical = 1;
            public const int Poison = 1;
        }
        public partial class Damage
        {
            public const int WaterBall = 120;
            public const int FireBall = 50;
            public const int SelfExplosion = 150;
            public const int OnePunchInNormalState = 100;
            public const int OnePunchInCheerUpState = 100;
            public const int OnePunchInHpAboveFiveHundred = 500;
            public const int OnePunchInPoisonOrPetrochemicalState = 80;
        }
        public partial class AttackHits
        {
            public const int OnePunchInPoisonOrPetrochemicalState = 3;
        }
        public partial class Effect
        {
            public const int SelfHealingAmount = 150;
            public const int PoisonDamage = 30;
        }
    }
    public partial class State
    {
        public partial class Round
        {
            public const int CheerUp = 3;
            public const int Petrochemical = 3;
            public const int Poison = 3;
        }
        public partial class Increase
        {
            public const int CheerUp = 50;
        }
    }
}