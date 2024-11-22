namespace PetPals.Model
{
    internal class Cat : Pet
    {
        private string? _catColor;
        public Cat(int petID, string? name, int? age, string? breed, string? type, bool availableForAdoption, string? catColor)
            : base() 
        {
            PetID = petID;
            Name = name;
            Age = age ?? 0;
            Breed = breed;
            Type = type;
            AvailableForAdoption = availableForAdoption;
            _catColor = catColor;
        }
        public string? CatColor
        {
            get { return _catColor; }
            set { _catColor = value; }
        }
        public override string ToString()
        {
            return base.ToString() + $", Cat Color: {(string.IsNullOrEmpty(CatColor) ? "Not Provided" : CatColor)}";
        }
    }
}
