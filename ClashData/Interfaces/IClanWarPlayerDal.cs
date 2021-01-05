using ClashEntities;
using System.Collections.Generic;

namespace ClashData
{
    public interface IClanWarPlayerDal
    {
        List<ClanWarPlayer> LoadCurrentWarPlayers(int clanWarId);
    }
}