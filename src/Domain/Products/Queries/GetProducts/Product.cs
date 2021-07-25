namespace Domain.Products.Queries.GetProducts
{
    public class Product
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public decimal Price { get; init; }
        public string Description { get; init; }

        public void Deconstruct(out string id, out string name, out decimal price, out string description) =>
            (id, name, price, description) = (this.Id, this.Name, this.Price, this.Description);
    }
}