class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
    public string Category { get; set; }
}
class Program
{
    static void Main()
    {
        var products = new List<Product>();
        products.Add(new Product { Name = "SmartTV", Price = 400, Category = "Electronics" });
        products.Add(new Product { Name = "Lenovo ThinkPad", Price = 1000, Category = "Electronics" });
        products.Add(new Product { Name = "Iphone", Price = 700, Category = "Electronics" });
        products.Add(new Product { Name = "Orange", Price = 2, Category = "Fruits" });
        products.Add(new Product { Name = "Banana", Price = 3, Category = "Fruits" });
        ILookup<string, Product> lookup = products.ToLookup(prod => prod.Category);
        TotalPrice(lookup);
    }

    static void TotalPrice(ILookup<string, Product> lookup)
    {

        foreach (var category in lookup)
        {
            double totalPrice = 0;
            foreach (var product in category)
            {
                Console.WriteLine($"{product.Name} {product.Price}");
                totalPrice += product.Price;
            }
            Console.WriteLine($"{category.Key} {totalPrice}");
        }
    }

}