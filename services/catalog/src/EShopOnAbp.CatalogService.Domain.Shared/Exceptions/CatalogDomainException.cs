using System;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace EShopOnAbp.CatalogService.Exceptions
{
    public class CatalogDomainException: BusinessException
    {
        public CatalogDomainException(            
            string code = null, 
            string message = null, 
            string details = null, 
            Exception innerException = null,
            LogLevel logLevel = LogLevel.Warning): base(code, message, details, innerException, logLevel)
        {
            
        }
    }
}