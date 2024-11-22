namespace PetPals.Model
{
    internal class Shelter
    {
        private int _shelterID;
        private string? _name;
        private string? _location;
        public int ShelterID
        {
            get { return _shelterID; }
            set { _shelterID = value; }
        }
        public string? Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string? Location
        {
            get { return _location; }
            set { _location = value; }
        }
        public override string ToString()
        {
            return $"Shelter ID: {ShelterID}, " +
                   $"Name: {(string.IsNullOrEmpty(Name) ? "Not Provided" : Name)}, " +
                   $"Location: {(string.IsNullOrEmpty(Location) ? "Not Provided" : Location)}";
        }
    }
}
