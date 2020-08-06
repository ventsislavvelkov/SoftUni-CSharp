namespace WildFarm.Animals
{
    public abstract class Bird : Animal
    {
        public Bird(string name, double weight, double wingSize)
            : base(name, weight)
        {
            this.WingSize = wingSize;
        }
        public double WingSize { get; private set; }

        public override string ToString()
        {
            return string.Format("{0} [{1}, {2}, {3}, {4}]", this.GetType().Name
                , this.Name, this.WingSize, this.Weight, this.FoodEaten);
        }
    }
}

