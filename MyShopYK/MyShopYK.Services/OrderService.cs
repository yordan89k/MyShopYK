﻿using MyShopYK.Core.Contracts;
using MyShopYK.Core.Models;
using MyShopYK.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopYK.Services
{
    public class OrderService : IOrderService
    {
        IRepository<Order> orderContext;
        public OrderService(IRepository<Order> orderContext)
        {
            this.orderContext = orderContext;
        }

        public void CreateOrder(Order baseOrder, List<BasketItemViewModel> basketItems)
        {
            foreach (var item in basketItems)
            {
                baseOrder.OrderItems.Add(new OrderItem()
                {
                    ProductId = item.Id,
                    Image = item.Image,
                    Price = item.Price,
                    ProductName = item.ProductName,
                    Quantity = item.Quantity
                });
            }

            orderContext.Insert(baseOrder);
            orderContext.Commit();

        }

        public List<Order> GetOrderList()
        {
            return orderContext.Collection().ToList();
        }

        public Order GetOrder(string Id)
        {
            return orderContext.Find(Id);
        }

        public void UpdateOrder(Order updateOrder)
        {
            orderContext.Update(updateOrder);
            orderContext.Commit();
        }
    }
}
