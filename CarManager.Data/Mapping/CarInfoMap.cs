using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using CarManager.Core.Domain;

namespace CarManager.Data.Mapping
{
    public class CarInfoMap:EntityTypeConfiguration<CarInfo>
    {
        public CarInfoMap()
        {
            this.ToTable("TB_CarInfo");
            this.HasKey(c=>c.Id);
            this.Property(c=>c.Name).HasMaxLength(20);
            this.Property(c => c.Comment).HasMaxLength(200);

        }
    }
}
