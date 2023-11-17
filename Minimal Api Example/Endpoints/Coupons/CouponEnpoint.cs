using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MinimalAPI.CouponApi.Data;
using MinimalAPI.CouponApi.Models;

namespace MinimalAPI.CouponApi.Endpoints.Coupons
{
    public class CouponEnpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder endpoint)
        {
            var coupons = CouponSeed.coupons;

            var couponRoute = endpoint.MapGroup("v1/coupon").WithTags("Coupons");

            // GET v1/coupon
            couponRoute.MapGet("", (IMapper _mapper) => {
                var couponList = _mapper.Map<IEnumerable<CouponDto>>(coupons);

                return Results.Ok(couponList);
            }).WithName("get-coupons").Produces<IEnumerable<CouponDto>>(200);

            // GET v1/coupon/{id}
            couponRoute.MapGet("{id:int}", (IMapper _mapper, [FromRoute] int id) => {
                var coupon = _mapper.Map<CouponDto>(coupons.FirstOrDefault(x => x.Id == id));

                return coupon == null ? Results.NotFound(new { code = "not_found", message = "Coupon not found"}) : Results.Ok(coupon);
            }).WithName("get-coupon-by-id").Produces<CouponDto>(200).Produces(404);

            // POST v1/coupon
            couponRoute.MapPost("", async (IMapper _mapper,[FromBody] CreateCouponDto dto, IValidator<CreateCouponDto> _validator) => {

                var validate = await _validator.ValidateAsync(dto);

                if (!validate.IsValid)
                {
                    return Results.BadRequest(new { code = "error", message = validate.Errors[0].ToString() });
                }

                if (coupons.FirstOrDefault(x => x.Name.ToLower() == dto.Name.ToLower()) != null)
                {
                    return Results.BadRequest("Name already exists");
                }

                var coupon = _mapper.Map<Coupon>(dto);

                coupon.Id = coupons.MaxBy(x => x.Id)?.Id + 1 ?? 1;
                coupon.Created = DateTime.Now;
                coupons.Add(coupon);

                var couponDto = _mapper.Map<CouponDto>(coupon);

                return Results.CreatedAtRoute("get-coupon-by-id", new { id = couponDto.Id }, couponDto);
            }).WithName("create-coupon").Produces<CouponDto>(201).Produces(400);

            // PUT v1/coupon/{id}
            couponRoute.MapPut("{id:int}", async (IValidator <UpdateCouponDto> _validator, IMapper _mapper, [FromRoute] int id, [FromBody] UpdateCouponDto dto) =>
            {
                var coupon = coupons.FirstOrDefault(x => x.Id == id);
                if (coupon == null)
                {
                    return Results.NotFound(new { code = "not_found", message = "Coupon Not Found" });
                }

                var validate = await _validator.ValidateAsync(dto);

                if (!validate.IsValid)
                {
                    return Results.BadRequest(new { code = "error", message = validate.Errors[0].ToString() });
                }

                coupon.Update(dto.Name, dto.Percent, dto.IsActive);

                return Results.Ok(new { code = "success", message = "Coupon updated" });

            }).WithName("update-coupon").Produces<CouponDto>(200).Produces(400).Produces(404);

            // DEL v1/coupon/{id}
            couponRoute.MapDelete("{id:int}", ([FromRoute] int id) =>
            {
                var coupon = coupons.FirstOrDefault(x => x.Id == id);
                if (coupon == null)
                {
                    return Results.NotFound(new { code = "not_found", message = "Coupon Not Found" });
                }

                coupons.Remove(coupon);

                return Results.Ok(new { code = "success", message = "Coupon deleted" });
            }).WithName("delete-coupon").Produces(200).Produces(404);
        }
    }
}
