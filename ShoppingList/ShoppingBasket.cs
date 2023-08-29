using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList
{
    /// <summary>
    /// Shopping Basket is the class referred for the basket
    /// that will contain de shopping items. Each item is 
    /// defined by its own class and has the name and the 
    /// weight of the item.
    /// 
    /// In this class we defined the ShoppingBasket in the 
    /// constructor allowing the user to modify the maximum
    /// weight of the basket when declaring the new Object.
    /// 
    /// In this example I think about declaring the weight as
    /// a constant value but it does not make sense if you
    /// want to change the shopping basket max weight in the
    /// future you will need to change and also, you will not
    /// be allowed to declare multiple weight baskets.
    /// </summary>
    public class ShoppingBasket : List<ShoppingItem>
    {
        /// <summary>
        /// Maximum Weight of basket in kilograms
        /// </summary>
        public double MaxWeight { get; set; }

        public double CurrentWeight { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="weight">Maximum weight for the basket</param>
        public ShoppingBasket(double weight)
        {
            this.MaxWeight = weight;
        }

    }
}
