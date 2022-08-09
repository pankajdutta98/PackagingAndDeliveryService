using PackagingAndDeliveryService.Repository.IRepository;
using System;

namespace PackagingAndDeliveryService.Repository
{
    public class PackagingAndDeliveryRepo : IPackagingAndDeliveryRepo
    {
        public double CalculatePackagingAndDeliveryCharges(char ComponentType, int? Qty)
        {
            double packagingCharge = 0;
            try
            {
                if (ComponentType == 'I')
                {
                    //150 = Rs 100 for packing And Rs 50 for sheath Per Item
                    //Rs 200 Delivery cost per item
                    packagingCharge = ((Qty ?? 0) * 150) + ((Qty ?? 0) * 200);
                }
                else
                {
                    //100 = Rs 50 for packing And Rs 50 for sheath Per Item
                    //Rs 100 Delivery cost per item
                    packagingCharge = ((Qty ?? 0) * 100) + ((Qty ?? 0) * 100);
                }
                return packagingCharge;
            }
            catch (Exception ex)
            {
                throw new Exception("PackagingAndDeliveryService.Repository.CalculatePackagingAndDeliveryCharges", ex);
            }
        }
    }
}
