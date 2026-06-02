namespace Discount.gRPC.Services;

public class DiscountService(DiscountContext dbContext, ILogger<DiscountService> logger) : DiscountProtoService.DiscountProtoServiceBase
{
    // GetDiscount from Database
    public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        var coupon = await dbContext.Coupons.FirstOrDefaultAsync(c => c.ProductName == request.ProductName);
        if(coupon is null) coupon = new Coupon { ProductName = "No Discount", Amount = 0, Description = "No Discount" };

        logger.LogInformation("Discount is retrieved for ProductName: {ProductName}, Amount: {Amount}", coupon.ProductName, coupon.Amount);

        var couponModel = coupon.Adapt<CouponModel>();
        return couponModel;
    }

    // CreateDiscount in Database
    public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {
        var coupon = request.Coupon.Adapt<Coupon>();
        if(coupon is null) throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid Coupon request object"));

        dbContext.Coupons.Add(coupon);
        await dbContext.SaveChangesAsync();

        logger.LogInformation("Discount is created for ProductName: {ProductName}, Amount: {Amount}", coupon.ProductName, coupon.Amount);
        return coupon.Adapt<CouponModel>();
    }

    // UpdateDiscount in Database
    public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        var coupon = request.Coupon.Adapt<Coupon>();
        if (coupon is null) throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid Coupon request object"));

        dbContext.Coupons.Update(coupon);
        await dbContext.SaveChangesAsync();

        logger.LogInformation("Discount is updated for ProductName: {ProductName}, Amount: {Amount}", coupon.ProductName, coupon.Amount);
        return coupon.Adapt<CouponModel>();
    }

    // DeleteDiscount from Database
    public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
    {
        var coupon = await dbContext.Coupons.FirstOrDefaultAsync(c => c.ProductName == request.ProductName);
        if(coupon is null)
        {
            throw new RpcException(new Status(StatusCode.NotFound, $"Discount not found with ProductName ={request.ProductName}"));
        }
        dbContext.Coupons.Remove(coupon);
        await dbContext.SaveChangesAsync();

        logger.LogInformation("Discount Successfully removed from database. ProductName : {ProductName}", request.ProductName);
        return new DeleteDiscountResponse { Success = true };
    }
}
