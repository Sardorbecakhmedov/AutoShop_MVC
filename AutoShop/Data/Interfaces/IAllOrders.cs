﻿using AutoShop.Data.Models;

namespace AutoShop.Data.Interfaces;

public interface IAllOrders
{
    void CreateOrder(Order order);
}