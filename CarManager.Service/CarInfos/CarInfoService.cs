using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarManager.Core.Domain;
using CarManager.Core.Data;
using CarManager.Core.Cache;

namespace CarManager.Service.CarInfos
{
    public class CarInfoService:ICarInfoService
    {
        private readonly IRepository<CarInfo, string> carRepository;
        private readonly ICacheManager cacheManager;
        public const string CarInfosCacheKey = "CarInfoService"+"CarInfo";

        public CarInfoService(IRepository<CarInfo, string> carRepository, ICacheManager cacheManager)
        {
            this.carRepository = carRepository;
            this.cacheManager = cacheManager;
        }
        public void CreateCarInfo(Core.Domain.CarInfo car)
        {
            carRepository.Insert(car);
        }

        public void UpdateCarInfo(Core.Domain.CarInfo car)
        {
            carRepository.Update(car);
        }

        public void DeleteCarInfo(Core.Domain.CarInfo car)
        {
            carRepository.Delete(car);
        }

        public List<Core.Domain.CarInfo> GetCarInfos()
        {
            List<CarInfo> cars = null;
            if (cacheManager.Contains(CarInfosCacheKey))
            {
                cars = cacheManager.Get<List<CarInfo>>(CarInfosCacheKey);
            }
            else
            {
                cars = carRepository.Table.ToList();
                cacheManager.Set(CarInfosCacheKey,cars,TimeSpan.FromHours(1));
            }
            return cars;
        }
    }
}
