﻿namespace Contracts;
public class Order
{
    public int OrderId { get; set; }
    public int UserId { get; set; }
    public decimal Amount { get; set; }
    public DateTime OrderDateTime { get; set; }
}