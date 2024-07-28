using bs_domain.Entities;
using bs_domain.Repositories;
using bs_service.DTO;
using bs_service.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace bs_service
{
    public class PriceTableService
    {
        private readonly PriceTableReporitory _repository;
        public PriceTableService(PriceTableReporitory repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PriceTableDTO>> GetAll()
        {
            var priceTables = await _repository.GetAll();
            return priceTables.Select(x => PriceTableMapper.FromEntity(x));
        }

        public async Task<PriceTableDTO> Create(PriceTableDTO dto)
        {
            var priceTable = PriceTableMapper.FromDTO(dto);
            priceTable = await _repository.Create(priceTable);

            return PriceTableMapper.FromEntity(priceTable);
        }

        public async Task<PriceTableDTO> Update(PriceTableDTO dto)
        {
            var priceTable = PriceTableMapper.FromDTO(dto);
            priceTable = await _repository.Update(priceTable);

            return PriceTableMapper.FromEntity(priceTable);
        }

        public async Task Delete(long code)
        {
            var priceTable = await _repository.GetById(code);
            await _repository.Delete(priceTable);
        }
    }
}
