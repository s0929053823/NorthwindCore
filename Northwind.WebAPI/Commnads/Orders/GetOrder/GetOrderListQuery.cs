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
    public class GetOrderListQuery : IRequest<IEnumerable<Orders>>
    {

    }

    public class GetOrderListQueryHandler : IRequestHandler<GetOrderListQuery, IEnumerable<Orders>>
    {
        private readonly IRepository<Orders> _repository;


        public GetOrderListQueryHandler(IRepository<Orders> repository)
        {
            _repository = repository;
        }


        public async Task<IEnumerable<Orders>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
