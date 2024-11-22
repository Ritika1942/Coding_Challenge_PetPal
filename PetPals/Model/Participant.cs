using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Model
{
    internal class Participant
    {
        private int _participantID;
        private string? _participantName; 
        private string? _participantType; 
        private int? _eventID; 
        public int ParticipantID
        {
            get { return _participantID; }
            set { _participantID = value; }
        }
        public string? ParticipantName
        {
            get { return _participantName; }
            set { _participantName = value; }
        }
        public string? ParticipantType
        {
            get { return _participantType; }
            set { _participantType = value; }
        }
        public int? EventID
        {
            get { return _eventID; }
            set { _eventID = value; }
        }
        public override string ToString()
        {
            return $"Participant ID: {ParticipantID}, " +
                   $"Name: {(string.IsNullOrEmpty(ParticipantName) ? "Not Provided" : ParticipantName)} , " +
                   $"Type: {(string.IsNullOrEmpty(ParticipantType) ? "Not Provided" : ParticipantType)}, " +
                   $"Event ID: {(EventID.HasValue ? EventID.ToString() : "Not Assigned")}";
        }
    }
}

