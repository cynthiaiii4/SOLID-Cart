#region

using System;

#endregion

namespace replace_condition_logic_with_strategy
{
    public class Cart
    {
        private class GoodsFeeInfo
        {
            public double Length { get; set; }
            public double Width { get; set; }
            public double Height { get; set; }
            public double Weight { get; set; }

        }
        public double ShippingFee(string shipper, double length, double width, double height, double weight)
        {
            double finalFee;
            var goodsFeeInfo = new GoodsFeeInfo
            {
                Length = length,
                Width = width,
                Height = height,
                Weight = weight,
            };

            if (shipper.Equals("black cat"))
            {
                finalFee = BlackCatFee(goodsFeeInfo);
            }
            else if (shipper.Equals("hsinchu"))
            {
                finalFee = Hsinchu(goodsFeeInfo);
            }
            else if (shipper.Equals("post office"))
            {
                finalFee = PostOffice(goodsFeeInfo);
            }
            else
            {
                throw new ArgumentException("shipper not exist");
            }
            return finalFee;
        }

        private double BlackCatFee(GoodsFeeInfo goodsFeeInfo)
        {
            if (goodsFeeInfo.Weight > 20)
            {
                return 500;
            }
            else
            {
                return 100 + goodsFeeInfo.Weight * 10;
            }
        }

        private double Hsinchu(GoodsFeeInfo goodsFeeInfo)
        {
            double size = goodsFeeInfo.Length * goodsFeeInfo.Width * goodsFeeInfo.Height;
            if (goodsFeeInfo.Length > 100 || goodsFeeInfo.Width > 100 || goodsFeeInfo.Height > 100)
            {
                return size * 0.00002 * 1100 + 500;
            }
            else
            {
                return size * 0.00002 * 1200;
            }
        }

        private double PostOffice(GoodsFeeInfo goodsFeeInfo)
        {
            double feeByWeight = 80 + goodsFeeInfo.Weight * 10;
            double size = goodsFeeInfo.Length * goodsFeeInfo.Width * goodsFeeInfo.Height;
            double feeBySize = size * 0.00002 * 1100;
            return feeByWeight < feeBySize ? feeByWeight : feeBySize;
        }
    }
}