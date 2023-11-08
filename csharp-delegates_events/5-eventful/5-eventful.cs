using System;

/// <summary>Defines Player class</summary>
class Player
{
    private string name;
    private float maxHp;
    private float hp;
    public event EventHandler<CurrentHPArgs> HPCheck;
    private string status;

    ///<summary>Handles health related events</summary>
    public delegate void CalculateHealth(float amount);
    /// <summary>
    /// Prints damage taken
    /// </summary>
    /// <param name="damage">amount of damage taken</param>
    public void TakeDamage(float damage)
    {
        if (damage <= 0)
            Console.WriteLine($"{name} takes 0 damage!");
        else
            Console.WriteLine($"{name} takes {damage} damage!");
            ValidateHP(hp - damage);
    }
    /// <summary>
    /// Prints damage healed
    /// </summary>
    /// <param name="heal">Amount of damage healed</param>
    public void HealDamage(float heal)
    {
        if (heal <= 0)
            Console.WriteLine($"{name} heals 0 HP!");
        else
        {
            Console.WriteLine($"{name} heals {heal} HP!");
            ValidateHP(hp + heal);
        }

    }

    /// <summary>
    /// sets the new value of the Player’s hp
    /// </summary>
    /// <param name="newHp">new value</param>
    public void ValidateHP(float newHp)
    {
        if (newHp <= 0)
            hp = 0;
        else if (newHp > maxHp)
            hp = maxHp;
        else
            hp = newHp;
        OnCheckStatus(new CurrentHPArgs(hp));
    }
    /// <summary>
    /// Player constructor
    /// </summary>
    /// <param name="name">name of the player</param>
    /// <param name="maxHp">max Hp of the player</param>
    public Player(string name = "Player", float maxHp = 100f)
    {
        if (maxHp > 0)
            this.maxHp = maxHp;
        else
        {
            this.maxHp = 100f;
            Console.WriteLine("maxHp must be greater than 0. maxHp set to 100f by default.");
        }
        this.hp = this.maxHp;
        this.name = name;
        this.status = $"{this.name} is ready to go!";
        HPCheck = CheckStatus;
    }

    /// <summary>Prints health of the player</summary>
    public void PrintHealth()
    {
        Console.WriteLine($"{name} has {hp} / {maxHp} health");
    }

    public float ApplyModifier(float baseValue, Modifier modifier)
    {
        if (modifier == Modifier.Weak)
            return baseValue * 0.5f;
        else if (modifier == Modifier.Base)
            return baseValue;
        else
            return baseValue * 1.5f;
    }

    private void CheckStatus(object sender, CurrentHPArgs e)
    {
        if (e.currentHp == maxHp)
            status = $"{name} is in perfect health!";
        else if (e.currentHp >= (maxHp / 2) && e.currentHp < maxHp)
            status = $"{name} is doing well!";
        else if (e.currentHp >= (maxHp / 4) && e.currentHp < (maxHp / 2))
            status = $"{name} isn't doing too great...";
        else if (e.currentHp > 0 && e.currentHp < (maxHp / 4))
            status = $"{name} needs help!";
        else
            status = $"{name} is knocked out!";
        Console.WriteLine(status);
    }

    private void HPValueWarning(object sender, CurrentHPArgs e)
    {
        if (e.currentHp == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Health has reached zero!");
            Console.ForegroundColor = ConsoleColor.White;

        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Health is low!");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    private void OnCheckStatus(CurrentHPArgs e)
    {
        if (e.currentHp <= (maxHp / 4))
            HPCheck += HPValueWarning;
        else
            HPCheck -= HPValueWarning;
        HPCheck(this, e);
    }
}

enum Modifier
{
    Weak,
    Base,
    Strong
}

delegate float CalculateModifier(float baseValue, Modifier modifier);

class CurrentHPArgs : EventArgs
{
    public float currentHp { get; }

    public CurrentHPArgs(float newHp)
    {
        this.currentHp = newHp;
    }
}