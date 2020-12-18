using ClashEntities;
using System.Collections.Generic;

namespace ClashData
{
    public interface IClansWarPlayerDal
    {
        List<ClansWarPlayer> LoadCurrentWarPlayers(int clansWarId);
    }
}