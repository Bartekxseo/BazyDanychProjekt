using BD.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BD.Services.House
{
    public interface IHouseService
    {
        HouseInfo getHouse(int id);

        List<HouseInfo> getAllHouses();

        void addOrUpdateHouse(HouseInfo houseInfo);

        void deleteHouse(int id);

    }
}
