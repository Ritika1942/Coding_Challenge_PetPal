namespace PetPals.Model
{
    internal class Pets
    {
        private int _petId;
        private string _name;
        private int _age;
        private string _breed;
        private string _type;
        private bool _availableForAdoption;

        public Pets(int petId, string name, int age, string breed, string type, bool availableForAdoption)
        {
            _petId = petId;
            _name = name;
            _age = age;
            _breed = breed;
            _type = type;
            _availableForAdoption = availableForAdoption;
        }

        public int PetID
        {
            get { return _petId; }
            set { _petId = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public string Breed
        {
            get { return _breed; }
            set { _breed = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public bool AvailableForAdoption
        {
            get { return _availableForAdoption; }
            set { _availableForAdoption = value; }
        }

        public override string ToString()
        {
            return $"Pet ID: {PetID}, Name: {Name}, Age: {Age}, Breed: {Breed}, Type: {Type}, Available for Adoption: {AvailableForAdoption}";
        }
    }
}
