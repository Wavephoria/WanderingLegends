using WanderingLegends.Views.WanderingLegends;

namespace WanderingLegends.Models.Heroes;

public class HeroService
{
    public Hero GeneratingNewHero()
    {
        return new Hero();
    }
    public void BattlingEnemy(GameStartVM chars)
    {
        if (chars.monster.Life == 0)
        {
            return;
        }

        bool isHeroInitiative = true;
        do
        {
            if (isHeroInitiative)
            {
                HitByHero(chars);
                if (chars.monster.Life != 0)
                    HitByMonster(chars);
            }
            else
            {
                HitByMonster(chars);
                if (chars.hero.Life != 0)
                    HitByHero(chars);
            }
        } while (chars.hero.Life > 0 && chars.monster.Life > 0);

        if (chars.hero.Life <= 0)
        {
            chars.hero.Life = chars.hero.StartingLife;
        }
        
    }

    public void HitByMonster(GameStartVM chars)
    {
        int hitPower = chars.monster.Strength - chars.hero.Protection;
        int lifeLeft = chars.hero.Life - hitPower;
        chars.hero.Life = lifeLeft;
    }

    public void HitByHero(GameStartVM chars)
    {
        int hitPower = chars.hero.Strength - chars.monster.Protection;
        int lifeLeft = chars.monster.Life - hitPower;
        if (lifeLeft <= 0)
        {
            chars.monster.Life = 0;
            EnemyKilled(chars);
        }
        else
            chars.monster.Life = lifeLeft;
    }

    public void EnemyKilled(GameStartVM chars)
    {
        int exp = chars.monster.ExperiencePoints(chars.hero);
        ExperienceGained(chars, exp);
    }

    private void ExperienceGained(GameStartVM chars, int exp)
    {
        chars.hero.ExperiencePoints += exp;
        if (chars.hero.ExperiencePoints >= 100)
            chars.hero.LevelUp();
    }
}