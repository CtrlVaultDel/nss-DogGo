using DogGo.Models;
using System.Collections.Generic;

namespace DogGo.Repositories
{
    public interface IWalkerRepository
    {
        List<Walker> GetAllWalkers();
        List<Walker> GetWalkersInNeighborhood(int neighborhoodId);
        Walker GetWalkerById(int id);
        List<Walk> GetWalksByWalkerId(int id);
    }
}