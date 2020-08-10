namespace CounterStrike.Models.Guns
{
    public class Rifle :Gun
    {
        private const int BULLETS_SHOOT = 10;

        public Rifle(string name, int bulletsCount) 
            : base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            if (this.BulletsCount < BULLETS_SHOOT)
            {
                return 0;
            }

            this.BulletsCount -= BULLETS_SHOOT;

            return BULLETS_SHOOT;
        }
    }
}