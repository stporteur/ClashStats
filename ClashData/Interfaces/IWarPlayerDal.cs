using ClashEntities;
using System.Collections.Generic;

namespace ClashData
{
    public interface IWarPlayerDal : ICrudActions<WarPlayer>
    {
        List<WarPlayer> LoadCurrentWarPlayers(int clanWarId);
    }
}