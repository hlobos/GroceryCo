# GroceryCo
The following is a Prototype Check-Out System created within a 3-day coding exercise.

###NuGet Packages Used:
- **Newtonsoft.Json**, for reading in PriceCatalog.json and Promotions.json files.

###Installation/Notes:
- Project Solution can be opened in Visual Studio 2015
- Main is found at Kiosk.cs
- (/Files/Basket/---.json) contains 4 grocery lists that are read in at (/Services/CashierConsole.cs -> GetBasketContents()) and can be changed. Each grocery list contains enough items to view promotion cases.
- (/Files/PriceCatalog.json) contains the current prices of each unique grocery item that exists at GroceryCo.
- (/Files/Promotions.json) contains the current unique promotions that exist at GroceryCo.

###Limitations:
- To be added.

###Assumptions Made:
- Unordered list of Basket items (/Files/Basket/---.json) are assumed to be formatted by one item per line.
- A grocery item cannot have more than one promotion applied to it.
- There is no UI for adding/changing promotions, development would need to be involved to change the current promotion but the file (/Files/Promotions.json) if viewed by GroceryCo staff would be readable.

###Notable Decisions:
###### Behavioural
- There is no user dialog/UI to choose which shopping basket to present, basket-01 is chosen and read-in as the default, basket-02 contains the longest and more varied list and can be changed manually within (/Services/CashierConsole.cs -> GetBasketContents()) using development's help.
- The program outputs/prints the grocery list into a receipt-like structure but the receipt is not stored/outputted into a 'receipt.txt' file, further development would be needed for this feature.

###### Design
- It was considered that, instead of using many lists for storing Item/Promotions a sort of IRepository implementation seemed like a good solution for extensibility, but my knowledge to implement that correctly as of late would require more time.
