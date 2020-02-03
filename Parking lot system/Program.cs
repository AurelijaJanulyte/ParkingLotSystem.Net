using System;

namespace Parking_lot_system
{
    class Program
    {
        static void Main(string[] args)
        {
            var floor = new ParkingLotSystem();
            Console.WriteLine("Enter car plate");
            var type = floor.GetType(Console.ReadLine().ToUpper());
            Console.WriteLine("Enter car floor from -2 to 6");
            var entryFloor =Convert.ToInt32(Console.ReadLine());

            var parkingFloor = floor.GetFloorToPark(ConvertFromInputFloor(entryFloor), type);

            if (parkingFloor.HasValue)
            {
                Console.WriteLine($"You can park in {ConvertToInputFloor(parkingFloor.Value)} ");
            }
            else
            {
                Console.WriteLine("There isn't any free space, you must wait");
            }
        }

        public static int ConvertFromInputFloor(int floor) 
        {
            return floor + 2;
        }

        public  static int ConvertToInputFloor(int floor) 
        {
            return floor - 2;
        }
    }
}
