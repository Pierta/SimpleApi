using SimpleApi.Infrastructure.Cqs.Interfaces;
using System;

namespace SimpleApi.Infrastructure.Cqs.Impl
{
    public abstract class Request : IRequest
    {
        public Guid RequestId { get; set; }

        protected Request()
        {
            RequestId = Guid.NewGuid();
        }
    }
}