using System;

namespace GroceryCo.Model
{
    public class Promotion : Entity
    {
        public Promotion(string name, string itemName, PromotionType type, DateTime? beginDate, int daysValid, DateTime dateExpiring, decimal discount, int requiredItems)
        {
            Name = name;
            ItemName = itemName;
            Type = type;
            BeginDate = beginDate;
            DaysValid = daysValid;
            DateExpiring = dateExpiring;
            Discount = discount;
            RequiredItems = requiredItems;
        }

        public string Name { get; private set; }
        public string ItemName { get; private set; }
        public PromotionType Type { get; private set; }
        public DateTime? BeginDate { get; private set; }
        public int DaysValid { get; private set; }
        public DateTime DateExpiring { get; private set; }
        public decimal Discount { get; private set; }
        public int RequiredItems { get; private set; }

        public DateTime CalculateExpirationDate()
        {
            return BeginDate.Value.AddDays(DaysValid);
        }
    }
}
