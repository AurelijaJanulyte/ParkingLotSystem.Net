using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking_lot_system
{
    public class ParkingLotSystem
    {

        public int[] vanFloors = { 0,1 };
        public int[] electricFloors = { 7,8};
        public int[] dieselFloors = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        public int[] freeSpacesInFloor = { 0, 1, 34, 4, 0, 8, 0, 1, 0 };

        public int? GetFloorToPark(int entryFloor, CarType type)
        {
            if (entryFloor > freeSpacesInFloor.Length -1 || entryFloor < 0) 
            {
                throw new ArgumentOutOfRangeException(nameof(entryFloor));
            }

            if (freeSpacesInFloor[entryFloor] > 0 && GetAvailableFloor(type).Contains(entryFloor))
            {
                return entryFloor;
            }
            else 
            {
                for (int i = 1; i < freeSpacesInFloor.Length; i++) 
                {
                    var upperFlor = entryFloor + i;

                    if (upperFlor >= 0 && upperFlor < freeSpacesInFloor.Length)
                    {
                        if (freeSpacesInFloor[upperFlor] > 0 && GetAvailableFloor(type).Contains(upperFlor))
                        {
                            return upperFlor;
                        }
                    }

                    var lowerFloor = entryFloor - i;

                    if (lowerFloor >= 0 && lowerFloor < freeSpacesInFloor.Length)
                    {
                        if (freeSpacesInFloor[lowerFloor] > 0 && GetAvailableFloor(type).Contains(lowerFloor))
                        {
                            return lowerFloor;
                        }
                    }
                }
            }

            return null;
        }

        public int[] GetAvailableFloor(CarType type)
        {
            switch (type)
            {
                case CarType.Diesel:
                    return dieselFloors;

                case CarType.Electric:
                    return electricFloors;

                case CarType.Van:
                    return vanFloors;
                default:
                    throw new ArgumentException("unknow type");

            }
        }

        public CarType GetType(string plate)
        {
            if (plate.Contains("W"))
            {
                return CarType.Electric;
            }
            else if (plate.Contains("A"))
            {
                return CarType.Diesel;
            }
            else
                return CarType.Van;
        }
    }

    public enum CarType
    {
        Diesel,
        Electric,
        Van
    }
}
