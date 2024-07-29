using bs_domain.Entities;
using bs_service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bs_service.Mappers
{
    public static class PriceTableMapper
    {
        public static PriceTableDTO FromEntity(PriceTable priceTable)
        {
            return new PriceTableDTO
            {
                Code = priceTable.Code,
                Description = priceTable.Description,
            };
        }

        public static PriceTable FromDTO(PriceTableDTO priceTable)
        {
            return new PriceTable
            {
                Code = priceTable.Code ?? 0,
                Description =priceTable.Description,
            };
        }
    }
}
