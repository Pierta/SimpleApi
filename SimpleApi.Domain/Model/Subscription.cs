using System;

namespace SimpleApi.Domain.Model
{
    public class Subscription
    {
        public static Guid DefaultId = new Guid("00000000-AAAA-0000-0000-000000000000");
        public static Guid FullSubscriptionId = new Guid("00000000-BBBB-0000-0000-000000000000");

        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}