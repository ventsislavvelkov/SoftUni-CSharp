namespace CounterStrike.Models.Guns
{
    public class Pistol :Gun
    {
        private const int BULLETS_SHOOT = 1;

        public Pistol(string name, int bulletsCount) 
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