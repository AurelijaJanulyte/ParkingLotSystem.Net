using Parking_lot_system;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class ParkingLotSystemTests
    {
        private readonly ParkingLotSystem _parkingLotSystemForCar;

        public ParkingLotSystemTests()
        {
            _parkingLotSystemForCar = new ParkingLotSystem();
        }

        [Theory]
        [InlineData(2,2)]
        [InlineData(0,1)]
        [InlineData(6,7)]
        public void GetFloorToPark_CorrectFloorForDieselCar(int entryFloor, int expectingFloor)
        {
            var result = _parkingLotSystemForCar.GetFloorToPark(entryFloor,CarType.Diesel);

            Assert.Equal(expectingFloor, result);
        }

        [Theory]
        [InlineData(0,7)]
        [InlineData(5,7)]
        [InlineData(8,7)]
        public void GetFloorToPark_CorrectFloorForElectricCar(int entryFloor, int expectingFloor)
        {
            var result = _parkingLotSystemForCar.GetFloorToPark(entryFloor,CarType.Electric);

            Assert.Equal(expectingFloor,result);
        }

        [Theory]
        [InlineData(0,1)]
        [InlineData(8,1)]
        [InlineData(5,1)]
        public void GetFloorToPark_CorrectFloorForVan(int entryFloor, int expectingFloor) 
        {
            var result = _parkingLotSystemForCar.GetFloorToPark(entryFloor,CarType.Van);

            Assert.Equal(expectingFloor,result);
        }

        [Fact]
        public void GetFloorToPark_ThrowsWhenEntryFloorOutOfRange() 
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => 
                           _parkingLotSystemForCar.GetFloorToPark(-10, CarType.Diesel));
        }

        [Fact]
        public void GetFloorToPark_NoSpaceToPark() 
        {
            var entryFloor = 2;

            _parkingLotSystemForCar.freeSpacesInFloor = new int[] {0,0,0,0,0,0,0,0,0};
            var result = _parkingLotSystemForCar.GetFloorToPark(entryFloor,CarType.Diesel);

            Assert.Null(result);
        }

    }
}
