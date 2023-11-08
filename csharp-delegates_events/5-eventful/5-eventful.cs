using System;

/// <summary>
/// Public enum
/// </summary>
public enum Modifier
{
    /// Weak /// 
    Weak,
    /// Base /// 
    Base,
    /// Strong /// 
    Strong
}

/// <summary>
/// public delegate float CalculateModifier
/// </summary>
/// <param name="baseValue"></param>
/// <param name="modifier"></param>
/// <returns></returns>
public delegate float CalculateModifier(float baseValue, Modifier modifier);

/// <summary>
/// public class Player
/// </summary>
public class Player
{
    private string name;
    private float maxHp;
    private float hp;
    private string status;

    /// <summary>
    /// public delegate void
    /// </summary>
    /// <param name="amount"></param>
    public delegate void CalculateHealth(float amount);

    /// <summary>
    /// public event EventHandler
    /// </summary>
    public event EventHandler<CurrentHPArgs> HPCheck;

    /// <summary>
    /// public Player
    /// </summary>
    /// <param name="name"></param>
    /// <param name="maxHp"></param>
    public Player(string name = "Player", float maxHp = 100f)
    {
        this.name = name;
        if (maxHp > 0)
        {
            this.maxHp = maxHp;
        }
        else
        {
            this.maxHp = 100f;
            Console.WriteLine("maxHp must be greater than 0. maxHp set to 100f by default.");
        }
        this.hp = this.maxHp;
        status = $"{name} is ready to go!";
        HPCheck += CheckStatus;
    }

    /// <summary>
    /// public void PrintHealth()
    /// </summary>
    public void PrintHealth()
    {
        Console.WriteLine($"{name} has {hp} / {maxHp} health");
    }

    /// <summary>
    /// public void TakeDamage
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(float damage)
    {
        if (damage <= 0)
        {
            Console.WriteLine($"{name} takes 0 damage!");
        }
        else
        {
            Console.WriteLine($"{name} takes {damage} damage!");
            ValidateHP(hp - damage);
        }
    }

    /// <summary>
    /// public void HealDamage
    /// </summary>
    /// <param name="heal"></param>
    public void HealDamage(float heal)
    {
        if (heal <= 0)
        {
            Console.WriteLine($"{name} heals 0 HP!");
        }
        else
        {
            Console.WriteLine($"{name} heals {heal} HP!");
            ValidateHP(hp + heal);
        }   
    }

    /// <summary>
    /// public void ValidateHP
    /// </summary>
    /// <param name="newHp"></param>
    public void ValidateHP(float newHp)
    {
        if (newHp <= 0)
        {
            hp = 0;
        }
        else if (newHp > maxHp)
        {
            hp = maxHp;
        }
        else
        {
            hp = newHp;
        }
        OnCheckStatus(new CurrentHPArgs(hp));
    }

    /// <summary>
    /// public float ApplyModifier
    /// </summary>
    /// <param name="baseValue"></param>
    /// <param name="modifier"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public float ApplyModifier(float baseValue, Modifier modifier)
    {
        switch (modifier)
        {
            case Modifier.Weak:
                return baseValue / 2f;
            case Modifier.Base:
                return baseValue;
            case Modifier.Strong:
                return baseValue * 1.5f;
            default:
                throw new ArgumentOutOfRangeException(nameof(modifier), modifier, null);
        }
    }
    
    private void CheckStatus(object sender, CurrentHPArgs e)
    {
        if (e.currentHp == maxHp)
        {
            status = $"{name} is in perfect health!";
        }
        else if (e.currentHp >= maxHp / 2 && e.currentHp < maxHp)
        {
            status = $"{name} is doing well!";
        }
        else if (e.currentHp >= maxHp / 4 && e.currentHp < maxHp / 2)
        {
            status = $"{name} isn't doing too great...";
        }
        else if (e.currentHp > 0 && e.currentHp < maxHp / 4)
        {
            status = $"{name} needs help!";
        }
        else if (e.currentHp == 0)
        {
            status = $"{name} is knocked out!";
        }
        Console.WriteLine(status);
    }

    private void HPValueWarning(object sender, CurrentHPArgs e)
    {
        if (e.currentHp == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Health has reached zero!");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Health is low!");
        }
        Console.ResetColor();
    }

    private void OnCheckStatus(CurrentHPArgs e)
    {
        if (e.currentHp <= maxHp / 4)
        {
            HPCheck += HPValueWarning;
        }
        else
        {
            HPCheck -= HPValueWarning;
        }
        HPCheck(this, e);
    }
}

/// <summary>
/// public class CurrentHPArgs : EventArgs
/// </summary>
public class CurrentHPArgs : EventArgs
{
    /// <summary>
    /// public float currentHp
    /// </summary>
    /// <value></value>
    public float currentHp { get; }

    /// <summary>
    /// public CurrentHPArgs
    /// </summary>
    /// <param name="newHp"></param>
    public CurrentHPArgs(float newHp)
    {
        currentHp = newHp;
    }
}
