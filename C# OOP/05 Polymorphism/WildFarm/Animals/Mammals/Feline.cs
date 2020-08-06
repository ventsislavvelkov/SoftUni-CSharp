namespace WildFarm.Animals.Mammals
{
    public abstract class Feline : Mammal
    {
        public Feline(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }
        public string Breed { get; private set; }

        public override string ToString()
        {
            return string.Format("{0} [{1}, {2}, {3}, {4}, {5}]", this.GetType().Name
                , this.Name, this.Breed, this.Weight, this.LivingRegion, this.FoodEaten);
        }
    }
}
