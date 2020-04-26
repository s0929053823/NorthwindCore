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
    public class DeleteOrderCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IRepository<Orders> _repository;

        public DeleteOrderCommandHandler(IRepository<Orders>  repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);

            return Unit.Value;
        }
    }
}
