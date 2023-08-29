using ShoppingList;

namespace ShoppingListTest
{
    public class ShoppingListUnitTest
    {

        ShoppingBasket basket10kg;
        ShoppingBasket basket20kg;
        ShoppingBasket basket30kg;

        List<ShoppingItem> items;

        [SetUp]
        public void Setup()
        {
            basket10kg = new ShoppingBasket(10.0);
            basket20kg = new ShoppingBasket(20.0);
            basket30kg = new ShoppingBasket(30.0);

            items = new List<ShoppingItem>();

            //Items
            ShoppingItem item1 = new ShoppingItem("Vegetables", 0.300, 3);
            ShoppingItem item2 = new ShoppingItem("Beers", 0.5, 4);
            ShoppingItem item3 = new ShoppingItem("Coke Zero", 2.0, 2);
            ShoppingItem item4 = new ShoppingItem("Water", 2.0, 2);
            ShoppingItem item5 = new ShoppingItem("Pizza", 0.350, 2);
            ShoppingItem item6 = new ShoppingItem("Yoghurt", 0.1256, 6);
            ShoppingItem item7 = new ShoppingItem("Orange Juice", 1.0, 1);
            ShoppingItem item8 = new ShoppingItem("Milk", 1.0, 6);
            ShoppingItem item9 = new ShoppingItem("Rice", 1.0, 1);
            ShoppingItem item10 = new ShoppingItem("Chicken", 1.475, 1);
            ShoppingItem item11 = new ShoppingItem("Fish", 1.325, 1);
            ShoppingItem item12 = new ShoppingItem("Meat", 0.823, 1);
            ShoppingItem item13 = new ShoppingItem("Fruit", 0.250, 6);
            ShoppingItem item14 = new ShoppingItem("ShowerGel", 0.750, 1);
            ShoppingItem item15 = new ShoppingItem("Chocolate", 0.500, 3);
            ShoppingItem item16 = new ShoppingItem("Watermelon", 5.5, 1);
            ShoppingItem item17 = new ShoppingItem("Flowers", 0.500, 1);

            items.AddRange(new List<ShoppingItem>()
            {
                new ShoppingItem("Vegetables", 0.300, 3),
                new ShoppingItem("Beers", 0.5, 4),
                new ShoppingItem("Coke Zero", 2.0, 2),
                new ShoppingItem("Water", 2.0, 2),
                new ShoppingItem("Pizza", 0.350, 2),
                new ShoppingItem("Yoghurt", 0.125, 6),
                new ShoppingItem("Orange Juice", 1.0, 1),
                new ShoppingItem("Milk", 1.0, 6),
                new ShoppingItem("Rice", 1.0, 1),
                new ShoppingItem("Chicken", 1.475, 1),
                new ShoppingItem("Fish", 1.325, 1),
                new ShoppingItem("Meat", 0.823, 1),
                new ShoppingItem("Fruit", 0.250, 6),
                new ShoppingItem("ShowerGel", 0.750, 1),
                new ShoppingItem("Chocolate", 0.500, 3),
                new ShoppingItem("Watermelon", 5.5, 1),
                new ShoppingItem("Flowers", 0.500, 1)
            });
        }

        [Test]
        public void TestFillBasketItems()
        {
            foreach(var item in items)
            {
                basket10kg.Add(item);
                basket20kg.Add(item);
                basket30kg.Add(item);
            }

            //Check that baskets are with items
            Assert.IsNotEmpty(basket10kg);
            Assert.IsNotEmpty(basket20kg);
            Assert.IsNotEmpty(basket30kg);
        }

        [Test]
        public void TestBasketItems()
        {
            int pos = 0;
            int positionHeaviestItem = 0;
            double heaviestWeight = items[0].TotalWeight;
            foreach (var item in items)
            {
                basket10kg.Add(item);
                basket20kg.Add(item);
                basket30kg.Add(item);
                if (item.TotalWeight > heaviestWeight)
                {
                    heaviestWeight = item.TotalWeight;
                    positionHeaviestItem = pos;
                }
                pos++;
            }

            //Finding the 
            Assert.That(positionHeaviestItem != 0);
        }

        [Test]
        public void TestBasketIsFillByLowest()
        {
            //Ordering the items
            items = items.OrderBy(t => t.TotalWeight).ToList();
            
            //Lightest Weight is the first one
            double lightestWeight = items[0].TotalWeight;
            int position = 0;
            int positionLightestItem = 0;


            //Adding the items to each basket
            foreach(var item in items)
            {
                basket10kg.Add(item);
                basket20kg.Add(item);
                basket30kg.Add(item);                
                //Check if the first element is the lightest
                if(item.TotalWeight < lightestWeight)
                {
                    positionLightestItem = position;
                }
                position++;
            }
            Assert.That (positionLightestItem == 0);
            
        }


        [Test]
        public void TestBasketIsFillByHeaviest()
        {
            //Ordering the items
            items = items.OrderByDescending(t => t.TotalWeight).ToList();

            //Lightest Weight is the first one
            double heaviestWeight = items[0].TotalWeight;
            int position = 0;
            int positionHeaviestItem = 0;

            //Adding the items to each basket
            foreach (var item in items)
            {
                basket10kg.Add(item);
                basket20kg.Add(item);
                basket30kg.Add(item);
                //Check if the first element is the lightest
                if (item.TotalWeight > heaviestWeight)
                {
                    positionHeaviestItem = position;
                }
                position++;
            }
            Assert.That(positionHeaviestItem == 0);
        }

        [Test]
        public void TestBasket10KgNotOverweight()
        {
            //Ordering the items
            items = items.OrderByDescending(t => t.TotalWeight).ToList();

            //Adding the items to each basket
            foreach (var item in items)
            {
                //First basket
                if(basket10kg.CurrentWeight + item.TotalWeight <= basket10kg.MaxWeight)
                {
                    //Add the item
                    basket10kg.Add(item);
                    //Sum the weight
                    basket10kg.CurrentWeight += item.TotalWeight;
                }
            }
            Assert.That(basket10kg.CurrentWeight <= basket10kg.MaxWeight);
        }

        [Test]
        public void TestBasketNotOverweight()
        {
            //Ordering the items
            items = items.OrderByDescending(t => t.TotalWeight).ToList();

            //Adding the items to each basket
            foreach (var item in items)
            {
                //First basket
                if (basket20kg.CurrentWeight + item.TotalWeight <= basket20kg.MaxWeight)
                {
                    //Add the item
                    basket20kg.Add(item);
                    //Sum the weight
                    basket20kg.CurrentWeight += item.TotalWeight;
                }
            }
            Assert.That(basket20kg.CurrentWeight <= basket20kg.MaxWeight);
        }
    }
}