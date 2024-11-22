using System;

namespace PetPals.Model
{
    internal class Dog : Pets
    {
        private string _dogBreed;
        public Dog(string name, int age, string breed, string dogBreed) : base(name, age, breed)
        {
            _dogBreed = dogBreed;
        }
        public string DogBreed
        {
            get { return _dogBreed; }
            set { _dogBreed = value; }
        }
        public override string ToString()
        {
            return $"{base.ToString()}, Dog Breed: {DogBreed}";
        }
    }
}
