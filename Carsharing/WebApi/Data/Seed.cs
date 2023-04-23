using Domain;
using Persistence;

namespace WebApi.Data
{
    public class Seed
    {
        public static void Initialize(CarsharingDbContext context)
        {
            //Cars
            var carId1 = Guid.Parse("041343ea-0f3d-458b-9fb6-7bd6700d69e8");
            var car1 = context.Cars.FirstOrDefault(x => x.CarId == carId1);
            if (car1 == null)
                car1 = new Car
                {
                    CarId = carId1,
                    Brand = "Toyota",
                    Model = "Camry",
                    LicensePlate = "",
                    YearOfIssue = 2018,
                    IsAvailable = true,
                    Image = "https://cars.usnews.com/static/images/Auto/izmo/i33960654/2018_toyota_camry_angularfront.jpg",
                    Level = 3
                };
            var car2 = new Car
            {
                CarId = Guid.Parse("11fd62be-dd30-11ed-b5ea-0242ac120002"),
                Brand = "Ford",
                Model = "Mustang",
                LicensePlate = "",
                YearOfIssue = 2021,
                IsAvailable = true,
                Image = "https://cdn.motor1.com/images/mgl/XpwQ2/s1/2021-ford-mustang-mach-1.jpg",
                Level = 3
            };
            var car3 = new Car
            {
                CarId = Guid.Parse("43b7fe4a-dd30-11ed-b5ea-0242ac120002"),
                Brand = "Chevrolet",
                Model = "Corvette",
                LicensePlate = "",
                YearOfIssue = 2022,
                IsAvailable = true,
                Image = "https://springerfachmedien.azureedge.net/sfm-trucker/thumb_945x532/media/5172/chevrolet-corvette-z06-01.jpg",
                Level = 4
            };
            var car4 = new Car
            {
                CarId = Guid.Parse("4cf0cbb8-dd30-11ed-b5ea-0242ac120002"),
                Brand = "Honda",
                Model = "Civic",
                LicensePlate = "",
                YearOfIssue = 2019,
                IsAvailable = true,
                Image = "https://images.hgmsites.net/hug/2019-honda-civic-sdn_100677004_h.jpg",
                Level = 3
            };
            var car5 = new Car
            {
                CarId = Guid.Parse("583adac2-dd30-11ed-b5ea-0242ac120002"),
                Brand = "BMW",
                Model = "M5",
                LicensePlate = "",
                YearOfIssue = 2020,
                IsAvailable = true,
                Image = "https://images.prismic.io/shacarlacca/NWRkZGJmYTAtZGU1Yy00YmVmLThlYWItMDRjOGUxYTAyNmI5__10.jpg?auto=compress%2Cformat&rect=0%2C0%2C1600%2C900&w=1200&h=1200",
                Level = 4
            };
            var car6 = new Car
            {
                CarId = Guid.Parse("5c957ab4-dd30-11ed-b5ea-0242ac120002"),
                Brand = "Mercedes-Benz",
                Model = "S-Class",
                LicensePlate = "",
                YearOfIssue = 2021,
                IsAvailable = true,
                Image = "https://www.topgear.com/sites/default/files/2022/03/1-Mercedes-S-Class-plug-in.jpg",
                Level = 4
            };
            var car7 = new Car
            {
                CarId = Guid.Parse("61efd3f6-dd30-11ed-b5ea-0242ac120002"),
                Brand = "Audi",
                Model = "A4",
                LicensePlate = "",
                YearOfIssue = 2022,
                IsAvailable = true,
                Image = "https://hips.hearstapps.com/hmg-prod/images/medium-6802-audia4-1654633069.jpg",
                Level = 4
            };
            var car8 = new Car
            {
                CarId = Guid.Parse("991ac980-dd30-11ed-b5ea-0242ac120002"),
                Brand = "Tesla",
                Model = "Model S",
                LicensePlate = "",
                YearOfIssue = 2021,
                IsAvailable = true,
                Image = "https://cdn.drivek.com/configurator-imgs/cars/de/original/TESLA/MODEL-S/40582_SCHRAGHECKLIMOUSINE-5-TURER/tesla-model-s-2021-font-side-1.jpg",
                Level = 4
            };
            var car9 = new Car
            {
                CarId = Guid.Parse("9e9eaa34-dd30-11ed-b5ea-0242ac120002"),
                Brand = "Lamborghini",
                Model = "Huracan",
                LicensePlate = "",
                YearOfIssue = 2022,
                IsAvailable = true,
                Image = "https://www.motortrend.com/uploads/2022/04/001-2022-Lamborghini-Huracan-Technica-1-2.jpg",
                Level = 5
            };
            var car10 = new Car
            {
                CarId = Guid.Parse("a384e64e-dd30-11ed-b5ea-0242ac120002"),
                Brand = "Porsche",
                Model = "911",
                LicensePlate = "",
                YearOfIssue = 2020,
                IsAvailable = true,
                Image = "https://cdn.motor1.com/images/mgl/XB3q7k/s3/2023-porsche-911-carrera-t-in-python-green.jpg",
                Level = 5
            };
            context.Cars.AddRange(car1, car2, car3, car4, car5, car6, car7, car8, car9, car10);
        }
    }
}
