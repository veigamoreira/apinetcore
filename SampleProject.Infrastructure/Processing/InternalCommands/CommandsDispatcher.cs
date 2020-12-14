using System;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SampleProject.Application.Configuration.Processing;
using SampleProject.Application.Customers;
using SampleProject.Infrastructure.Database;

namespace SampleProject.Infrastructure.Processing.InternalCommands
{
    public class CommandsDispatcher : ICommandsDispatcher
    {
        private readonly IMediator _mediator;
        private readonly Context _ordersContext;

        public CommandsDispatcher(
            IMediator mediator, 
            Context ordersContext)
        {
            this._mediator = mediator;
            this._ordersContext = ordersContext;
        }

        public async Task DispatchCommandAsync(Guid id)
        {
        }
    }
}