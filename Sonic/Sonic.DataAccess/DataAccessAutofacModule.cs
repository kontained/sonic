using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Sonic.DataAccess.Extended.Orders.Processor.Taxes;

namespace Sonic.DataAccess
{
    public class DataAccessAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DATaxRateService>().As<IDATaxRateService>();
        }
    }
}
