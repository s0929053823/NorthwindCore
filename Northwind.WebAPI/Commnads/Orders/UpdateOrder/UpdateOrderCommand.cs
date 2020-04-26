using AutoMapper;
using MediatR;
using Northwind.DbModels.Model;
using Northwind.WebAPI.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Northwind.WebAPI.Commnads
{
    public class UpdateOrderCommand : IRequest
    {
        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? ShipVia { get; set; }
        public decimal? Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }

     

    }

    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {

        private readonly IRepository<Orders> _repository;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(IRepository<Orders> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Orders>(request);

            await _repository.UpdateAsync(entity);

            return Unit.Value;
        }
    }
}
