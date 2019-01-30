using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Sonic.Business.Extended.Orders;
using Sonic.Business.Extended.Orders.Processor;
using Sonic.Business.Extended.Orders.Processor.Taxes;
using Sonic.Business.Extended.Orders.Processor.Strategy;
using Sonic.Business.Extended.Orders.Processor.Strategy.Factory;

namespace Sonic.Business
{
    public class BusinessAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OrderService>().As<IOrderService>();
            builder.RegisterType<OrderProcessor>().As<IOrderProcessor>();
            builder.RegisterType<TaxRateService>().As<ITaxRateService>();
            builder.RegisterType<MaterialOrderItemProcessingStrategy>().Named<IOrderItemProcessingStrategy>("material");
            builder.RegisterType<ServiceOrderItemProcessingStrategy>().Named<IOrderItemProcessingStrategy>("service");
            builder.Register<IOrderItemStrategyFactory>(x => 
            new OrderItemStrategyFactory(x.ResolveNamed<IOrderItemProcessingStrategy>("material"), x.ResolveNamed<IOrderItemProcessingStrategy>("service")));
        }
    }
}
