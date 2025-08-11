| classes | methods                      | scenario                                         | output  |
|---------|------------------------------|--------------------------------------------------|---------|
| Basket  | Add(int Id)                  | Add spesific type of bagel to basket             | bool    |
| Basket  | Remove(int Id)               | Remove bagel from basket                         | bool    |
| Basket  | CheckFull                    | check if the basket is full when adding          | bool    |
| Basket  | ChangeCapacity(int Capacity) | change capacity of a basket                      | bool    |
| Basket  | CheckIfExist(int Id)         | check if the item to be removed is in the basket | bool    |
| Basket  | BasketTotal                  | returns the total price of basket                | double  |
| Basket  | ShowBagelPrice(int id)       | show the cost of a bagel before adding           | double  |
| Bagel   | AddFilling(IProduct filling) | choose filling for a bagel                       | bool    |
| Basket  | ShowFillingPrice(int id)     | Show the price of filling before adding          | double  |
| Basket  | CheckInventory(int id)       | Check if item is in inventory before adding      | bool    |