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
    public class GetOrderDetailQuery : IRequest<Orders>
    {
        public int Id { get; set; }
    }


    public class GetOrderDetailQueryHandler : IRequestHandler<GetOrderDetailQuery, Orders>
    {
        private readonly IRepository<Orders> _repository;
      


        public GetOrderDetailQueryHandler(IRepository<Orders> repository)
        {
            _repository = repository;
        }

        public async Task<Orders> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken)
        {
            return await _repository.FindAsync(request.Id);
        }
    }
}
