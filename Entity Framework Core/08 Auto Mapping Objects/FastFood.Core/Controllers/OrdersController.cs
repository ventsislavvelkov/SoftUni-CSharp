using AutoMapper.QueryableExtensions;
using FastFood.Models;
using FastFood.Models.Enums;

namespace FastFood.Core.Controllers
{
    using System;
    using System.Linq;
    using AutoMapper;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Orders;

    public class OrdersController : Controller
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public OrdersController(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            var viewOrder = new CreateOrderViewModel
            {
                Employees = this.context
                    .Employees
                    .Select(x => x.Name)
                    .ToList(),
                Items = this.context
                    .Items
                    .Select(x => x.Name)
                    .ToList(),
            };

            return this.View(viewOrder);
        }

        [HttpPost]
        public IActionResult Create(CreateOrderInputModel model)
        {
            var item = this.context.Items
                .FirstOrDefault(i => i.Name == model.ItemName);

            model.ItemId = item.Id;

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            var order = this.mapper.Map<Order>(model);

            order.DateTime = DateTime.UtcNow;
            order.Type = Enum.Parse<OrderType>(model.OrderType, true);

            order.OrderItems.Add(new OrderItem
            {
                ItemId = model.ItemId,
                Order = order,
                Quantity = model.Quantity
            });

            var employee = this.context.Employees
                .FirstOrDefault(e => e.Name == model.EmployeeName);

            order.EmployeeId = employee.Id;

            this.context.Orders.Add(order);

            this.context.SaveChanges();

            return this.RedirectToAction("All", "Orders");
        }

        public IActionResult All()
        {
            var orders = this.context.Orders
                .ProjectTo<OrderAllViewModel>(mapper.ConfigurationProvider)
                .ToList();

            return this.View(orders);
        }
    }
}
