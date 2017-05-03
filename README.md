# GroceryCo
The following is a Prototype Check-Out System created within a 3-day coding exercise.

### NuGet Packages Used:
- **Newtonsoft.Json**, for reading in PriceCatalog.json and Promotions.json files
- **NUnit 3.6.1**, for Unit Testing
- **NUnit 3 Test Adapter**, for running Unit Tests in Visual Studio 2015

### Installation/Notes:
- Project Solution can be opened in Visual Studio 2015
- Main is found at Kiosk.cs
- (/Files/Basket/---.json) contains 4 grocery lists that are read in at (/Services/CashierConsole.cs --> GetBasketContents()) and can be changed. Each grocery list contains enough items to view promotion cases.
- (/Files/PriceCatalog.json) contains the current prices of each unique grocery item that exists at GroceryCo.
- (/Files/Promotions.json) contains the current unique promotions that exist at GroceryCo.

### Limitations:
- Advanced promotions (GroupSale, BOGOFree, BOGOPercent) have been added to the Promotions Model, calculations on applying the discount exist at (Cashier --> ApplyPromotions()) but return 0 (not implemented). My goal was to start small scale, getting OnSale promotions working fully. When reaching the advanced promotions afterwards my roadblock was on how to keep a clean group count of every individual basket item. But I feel there exists a better way, more research is needed to come up with a better idea.  

### Unit Testing
- First hand try writing unit tests with NUnit, therefore UnitTests are lacking. Focused on (Cashier --> ApplyPromotion) to strengthen that method as applying promotions to items is an important function for GroceryCo.

### Assumptions Made:
- Unordered list of Basket items (/Files/Basket/---.json) are assumed to be formatted by one item per line.
- A grocery item cannot have more than one promotion applied to it.
- There is no UI for adding/changing promotions, development would need to be involved to change the current promotion list. The file (/Files/Promotions.json) if viewed by GroceryCo staff should be readable for them.

### Notable Decisions:
###### Behavioural
- There is no user dialog/UI to choose which shopping basket to present, basket-01 is chosen and read-in as the default, basket-02 contains the longest and more varied list and can be changed manually within (/Services/CashierConsole.cs --> GetBasketContents()) using development's help.
- The program outputs/prints the grocery list into a receipt-like structure but the receipt is not stored/outputted into a 'receipt.txt' file, further development would be needed for this feature.

###### Design
- It was considered that, instead of using many lists for storing Item/Promotions a sort of IRepository implementation seemed like a good solution for extensibility, but my knowledge to implement that correctly as of late would require more time.
