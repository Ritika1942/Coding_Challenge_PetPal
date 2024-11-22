using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Model
{
    internal class AdoptionEvents
    {
            private int _eventID;
            private string? _eventName;  
            private DateTime _eventDate;
            private string? _location;  
            public int EventID
        {
            get { return _eventID; }
            set { _eventID = value; }
        }
            public string? EventName
            {
                get { return _eventName; }
                set { _eventName = value; }
            }
            public DateTime EventDate
            {
                get { return _eventDate; }
                set { _eventDate = value; }
            }
            public string? Location
            {
                get { return _location; }
                set { _location = value; }
            }
            public override string ToString()
            {
                return $"Event ID: {EventID}, " +
                       $"Event Name: {(string.IsNullOrEmpty(EventName) ? "Not Provided" : EventName)}, " +
                       $"Event Date: {EventDate.ToString("yyyy-MM-dd HH:mm")}, " +
                       $"Location: {(string.IsNullOrEmpty(Location) ? "Not Provided" : Location)}";
            }
        }
    }
