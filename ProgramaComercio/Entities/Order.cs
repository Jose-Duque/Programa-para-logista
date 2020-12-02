using System;
using System.Collections.Generic;
using System.Text;
using ProgramaComercio.Entities.Enums;

namespace ProgramaComercio.Entities
{
    class Order
    {
        public DateTime Moment { get; set; } = DateTime.Now;
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order()
        {
        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public double Total()
        {
            double sum = 0;
            foreach (OrderItem item in Items)
            {
                double total = item.SubTotal();
                sum += total;               
            }

            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Order Summary: ");
            sb.Append("Order moment: " + Moment);
            sb.Append("Order status: " + Status);
            sb.Append("Client: " + Client.Name + " (" +  Client.BirthDate.ToString("dd/MM/yyyy") +") " + " - " + Client.Email);
            sb.AppendLine("Order items: ");
            foreach (OrderItem item in Items)
            {
                sb.AppendLine($"{item.Product.NameProduct}, ${item.Price} Qunatity: {item.Quantity}, SubTotal: {item.SubTotal()}");
            }
            sb.Append("Total price: " + Total().ToString("F2"));
            return sb.ToString();
        }
    }
}
