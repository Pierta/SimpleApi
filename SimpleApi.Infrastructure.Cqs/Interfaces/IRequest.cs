using System;

namespace SimpleApi.Infrastructure.Cqs.Interfaces
{
    public interface IRequest
    {
        Guid RequestId { get; set; }
    }
}