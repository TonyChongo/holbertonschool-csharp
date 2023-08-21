using System;


namespace Enemies
{
    /// <summary>
    /// Public class Zombie that contains their health
    /// </summary>
    public class Zombie
    {
        /// <summary>
        /// Public field
        /// </summary>
        private int health;

        /// <summary>
        /// Public constructor
        /// </summary>
        public Zombie()
        {
            health = 0;
        }

        /// <summary>
        /// New public contructor
        /// </summary>
        /// <param name="value"></param>
        public Zombie(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Health must be greater than or equal to 0");
            }
            health = value;
        }

        /// <summary>
        /// New private field name
        /// </summary>
        /// <returns></returns>
        private string name = "(No name)";

        /// <summary>
        /// New public property
        /// </summary>
        /// <value></value>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Method thats return the value of health
        /// </summary>
        /// <returns></returns>
        public int GetHealth()
        {
            return health;
        }

        /// <summary>
        /// Add an ovveride ToString that prints Zombie object’s attributes to stdout
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Zombie Name: {Name} / Total Health: {health}";
        }
    }
}

