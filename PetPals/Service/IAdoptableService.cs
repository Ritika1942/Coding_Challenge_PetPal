using PetPals.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Service
{
    public interface IAdoptableService
    {
        void AddAdoptable(AdoptableService adoptable);
        AdoptableService GetAdoptableById(int participantId);
        List<AdoptableService> GetAllAdoptables();
        void UpdateAdoptable(AdoptableService adoptable);
        void DeleteAdoptable(int participantId);
        void Adopt(int adoptableId, int adopterId);
    }
}
