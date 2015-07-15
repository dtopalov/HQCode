namespace Cooking
{
    public class Chef
    {    
        public void Cook()
        {
            Potato potato = this.GetPotato();
            this.Peel(potato);
            this.Cut(potato);
            Carrot carrot = this.GetCarrot();
            this.Peel(carrot);
            this.Cut(carrot);
            Bowl bowl = this.GetBowl();
            bowl.Add(potato);
            bowl.Add(carrot);
        }

        private Bowl GetBowl()
        {
            Bowl result = new Bowl();

            // ...
            return result;
        }

        private Carrot GetCarrot()
        {
            Carrot result = new Carrot();

            // ...
            return result;
        }

        private Potato GetPotato()
        {
            Potato result = new Potato();

            // ...
            return result;
        }

        private void Peel(Vegetable vegetable)
        {
            // some vegetable peeling logic
            vegetable.IsPeeled = true;
        }

        private void Cut(Vegetable vegetable)
        {
            // some vegetable cutting logic
            vegetable.IsCut = true;
        }
    }
}
