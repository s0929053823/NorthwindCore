using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Northwind.DbModels.Model;
using Northwind.WebAPI.Repositorys;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace Northwind.WebAPI.Commnads
{
    public class CreateOrderCommand : IRequest
    {
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

    public class CreateOrderCommnadHandler : IRequestHandler<CreateOrderCommand, Unit>
    {
        private readonly IRepository<Orders> _repository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CreateOrderCommnadHandler(IRepository<Orders> repository, IMediator mediator, IMapper mapper)
        {
            _repository = repository;
            _mediator = mediator;
            _mapper = mapper;
        }



        public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Orders>(request);

            await _repository.InsertAsync(entity);

            await _mediator.Publish(new OrderCreated { OrderId = entity.OrderId});

            return Unit.Value;
        }

   
    }

    public class OrderCreated : INotification
    {
        public int OrderId { get; set; }

        public class OrderCreatedHandler : INotificationHandler<OrderCreated>
        {

            public Task Handle(OrderCreated notification, CancellationToken cancellationToken)
            {
                return Task.Delay(0);
            }
        }

    }


}
