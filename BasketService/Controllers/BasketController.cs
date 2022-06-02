using BasketService.Model.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService basketService;
        public BasketController(IBasketService basketService )
        {
            this.basketService = basketService;
        }

        [HttpGet]
        public IActionResult Get(string UserId)
        {
            var basket = basketService.GetOrCreateBasketForUser(UserId);
            return Ok(basket);
        }

        [HttpPost]
        public IActionResult AddItemToBasket(AddItemToBasketDto request, string UserId)
        {
            var basket = basketService.GetOrCreateBasketForUser(UserId);
            request.basketId = basket.Id;
            basketService.AddItemToBasket(request);
            var basketData = basketService.GetBasket(UserId);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Remove(Guid ItemId)
        {
            basketService.RemoveItemFromBasket(ItemId);
            return Ok();
        }

        [HttpPut]
        public IActionResult SetQuantity(Guid basketItemId, int quantity)
        {
            basketService.SetQuantities(basketItemId, quantity);
            return Ok();
        }
    }
}
