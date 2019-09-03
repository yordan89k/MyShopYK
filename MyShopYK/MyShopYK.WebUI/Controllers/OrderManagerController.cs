﻿using MyShopYK.Core.Contracts;
using MyShopYK.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShopYK.WebUI.Controllers
{
    public class OrderManagerController : Controller
    {
        IOrderService orderService;

        public OrderManagerController(IOrderService OrderService)
        {
            this.orderService = OrderService;

        }

        // GET: OrderManager
        public ActionResult Index()
        {
            List<Order> orders = orderService.GetOrderList();

            return View();
        }

        public ActionResult UpdateOrder(string Id)
        {
            Order order = orderService.GetOrder(Id);
            return View(order);
        }

        public ActionResult UpdateOrder(Order updatedOrder, string Id)
        {
            Order order = orderService.GetOrder(Id);

            order.OrderStatus = updatedOrder.OrderStatus;
            orderService.UpdateOrder(order);

            return RedirectToAction("Index");
        }
    }
}