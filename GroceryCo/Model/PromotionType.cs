using System;

namespace GroceryCo.Model
{
    public abstract class PromotionType : Enumeration
    {
        public static readonly PromotionType OnSale = new OnSalePromotion(1, "OnSale");
        public static readonly PromotionType GroupSale = new GroupSalePromotion(2, "GroupSale");
        public static readonly PromotionType BOGOFree = new BOGOFreePromotion(3, "BOGOFree");
        public static readonly PromotionType BOGOPercent = new BOGOPercentPromotion(4, "BOGOPercent");

        protected PromotionType(int value, string displayName)
			: base(value, displayName)
		{
        }

        public class OnSalePromotion : PromotionType
        {
            public OnSalePromotion(int value, string displayName) : base(value, displayName)
            {
            }
        }

        public class GroupSalePromotion : PromotionType
        {
            public GroupSalePromotion(int value, string displayName) : base(value, displayName)
            {
            }
        }

        public class BOGOFreePromotion : PromotionType
        {
            public BOGOFreePromotion(int value, string displayName) : base(value, displayName)
            {
            }
        }

        public class BOGOPercentPromotion : PromotionType
        {
            public BOGOPercentPromotion(int value, string displayName) : base(value, displayName)
            {
            }
        }
    }
}