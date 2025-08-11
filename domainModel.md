| classes | methods                      | scenario                                         | output  |
|---------|------------------------------|--------------------------------------------------|---------|
| Basket  | Add(IProduct product)                  | Add spesific type of bagel to basket             | bool    |
| Basket  | Remove(IProduct product)               | Remove bagel from basket, false if item is not in basket                        | bool    |
| Basket  | CheckFull                    | check if the basket is full when adding          | bool    |
| Basket  | ChangeCapacity(int Capacity) | change capacity of a basket                      | bool    |
| Basket  | BasketTotal                  | returns the total price of basket                | double  |
| Basket  | ShowBagelPrice(string SKU)       | show the cost of a bagel before adding           | double  |
| Bagel   | AddFilling(IProduct filling) | choose filling for a bagel                       | bool    |
| Basket  | ShowFillingPrice(string SKU)     | Show the price of filling before adding          | double  |
| Basket  | CheckInventory(string SKU)       | Check if item is in inventory before adding      | bool    |

