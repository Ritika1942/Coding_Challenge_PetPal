namespace PetPals.Model
{
    internal class Dog : Pet
    {
        private string? _dogBreed;
        public Dog(int petID, string? name, int? age, string? breed, string? type, bool availableForAdoption, string? dogBreed)
            : base() 
        {
            PetID = petID;
            Name = name;
            Age = age ?? 0;
            Breed = breed;
            Type = type;
            AvailableForAdoption = availableForAdoption;
            _dogBreed = dogBreed;
        }
        public string? DogBreed
        {
            get { return _dogBreed; }
            set { _dogBreed = value; }
        }
        public override string ToString()
        {
            return base.ToString() + $", Dog Breed: {(string.IsNullOrEmpty(DogBreed) ? "Not Provided" : DogBreed)}";
        }
    }
}
