namespace PetPals.Model
{
    public class AdoptionEvent
    {
        private int _eventId;
        private string _eventName;
        private DateTime _eventDate;
        private string _location;
        public AdoptionEvent(int eventId, string eventName, DateTime eventDate, string location)
        {
            _eventId = eventId;
            _eventName = eventName;
            _eventDate = eventDate;
            _location = location;
        }

        public AdoptionEvent() { }
        public int EventId
        {
            get { return _eventId; }
            set { _eventId = value; }
        }
        public string EventName
        {
            get { return _eventName; }
            set { _eventName = value; }
        }
        public DateTime EventDate
        {
            get { return _eventDate; }
            set { _eventDate = value; }
        }
        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }
        public override string ToString()
        {
            return $"Event ID: {EventId}, " +
                $"Name: {EventName}, " +
                $"Date: {EventDate:MM/dd/yyyy}, " +
                $"Location: {Location}";
        }
    }
}
