using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarManager.Core.Domain;

namespace CarManager.Service.CarInfos
{
    public interface ICarInfoService
    {
        void CreateCarInfo(CarInfo car);
        void UpdateCarInfo(CarInfo car);
        void DeleteCarInfo(CarInfo car);
        List<CarInfo> GetCarInfos();
    }
}
