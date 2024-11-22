namespace PetPals.Model
{
    internal class Pet
    {
        private int _petID;
        private string? _name;
        private int _age;
        private string? _breed;
        private string? _type;
        private bool _availableForAdoption;
        private string? _color;  // Added field for color

        public int PetID
        {
            get { return _petID; }
            set { _petID = value; }
        }

        public string? Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public string? Breed
        {
            get { return _breed; }
            set { _breed = value; }
        }

        public string? Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public bool AvailableForAdoption
        {
            get { return _availableForAdoption; }
            set { _availableForAdoption = value; }
        }

        public string? Color  // Added Color property
        {
            get { return _color; }
            set { _color = value; }
        }

        public override string ToString()
        {
            return $"Pet ID: {PetID}, " +
                   $"Name: {(string.IsNullOrEmpty(Name) ? "Not Provided" : Name)} , " +
                   $"Age: {Age}, " +
                   $"Breed: {(string.IsNullOrEmpty(Breed) ? "Not Provided" : Breed)}, " +
                   $"Type: {(string.IsNullOrEmpty(Type) ? "Not Provided" : Type)}, " +
                   $"Color: {(string.IsNullOrEmpty(Color) ? "Not Provided" : Color)}, " +  // Included Color in ToString
                   $"Available for Adoption: {(AvailableForAdoption ? "Yes" : "No")}";
        }
    }
}
