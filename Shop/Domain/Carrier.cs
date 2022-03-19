using System;

namespace Shop.Domain
{
    public class Carrier
    {
        public Guid Id { get; }

        public string Name { get; }

        public string Telephone { get; }

        public Carrier(Guid id, string name, string telephone)
        {
            Id = id;
            Name = name;
            Telephone = telephone;
        }
    }
}