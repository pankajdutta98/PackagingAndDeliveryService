namespace PackagingAndDeliveryService.Repository.IRepository
{
    public interface IPackagingAndDeliveryRepo
    {
        double CalculatePackagingAndDeliveryCharges(char ComponentType, int? Qty);
    }
}
