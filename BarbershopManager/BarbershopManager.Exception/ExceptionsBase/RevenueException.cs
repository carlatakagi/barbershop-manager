using System;
using System.Collections.Generic;

namespace BarbershopManager.BarbershopManager.Exception.ExceptionsBase
{
    public abstract class RevenueException : SystemException
    {
        protected RevenueException(string message) : base(message)
        {
        }

        public abstract int StatusCode { get; }
        public abstract List<string> GetErrors();
    }
}