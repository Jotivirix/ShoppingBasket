// See https://aka.ms/new-console-template for more information
using ShoppingList;

//Define Shopping Basket with maximum weight of 20KG
ShoppingBasket basket = new ShoppingBasket(20.0);

//Adding Multiple Items - Multiple ones
basket.AddRange(new ShoppingBasket(20.0) {
    new ShoppingItem("Vegetables", 0.300, 3),
    new ShoppingItem("Beers", 0.5, 4),
    new ShoppingItem("Coke Zero", 2.0, 2),
    new ShoppingItem("Water", 2.0, 2),
    new ShoppingItem("Pizza", 0.350, 2),
    new ShoppingItem("Yoghurt", 0.1256, 6),
    new ShoppingItem("Orange Juice", 1.0, 1),
    new ShoppingItem("Milk", 1.0, 6),
    new ShoppingItem("Rice", 1.0, 1),
    new ShoppingItem("Chicken", 1.475, 1),
    new ShoppingItem("Fish", 1.325, 1),
    new ShoppingItem("Meat", 0.823, 1),
    new ShoppingItem("Fruit", 0.250, 6),
    new ShoppingItem("ShowerGel", 0.750, 1),
    new ShoppingItem("Chocolate", 0.500, 3)
});


Console.WriteLine("Original Shopping List...");

foreach (var item in basket)
{
    Console.WriteLine($"{item.Name} - {item.Units} units - Total Weight: {item.TotalWeight} kg");
}

//Sorting list by max weight first
List<ShoppingItem> orderedList = basket.OrderByDescending(t => t.TotalWeight).ToList();

//Cleaning original basket
basket.Clear();

//If the weight is allowed to be introduced we put the item in the basket
foreach(var item in orderedList)
{
    if (basket.MaxWeight >= item.TotalWeight)
    {
        basket.MaxWeight -= item.TotalWeight;
        basket.CurrentWeight += item.TotalWeight;
        basket.Add(item);

    }
}

Console.WriteLine("\n\n------------------------------------------\n\n");

//Final Basket
Console.WriteLine($"Shopping Basket -- Total Weight: {basket.CurrentWeight} kg");
foreach(var item in basket)
{
    Console.WriteLine($"{item.Name} - {item.Units} units - Total Weight: {item.TotalWeight} kg");
}

