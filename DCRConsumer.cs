using ABP_AddDC.Models;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddProduct
{
    public class DCRConsumer : IConsumer<AddDCR>
    {
        public async Task Consume(ConsumeContext<AddDCR> context)
        {
            var data = context.Message;
        }
    }
}
