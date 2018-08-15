using Gratify.Business;
using Gratify.Domain;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gratify.API.Controllers
{
    [Route("api/lists")]
    public class WishListsController : Controller
    {
        private IWishListBusinesss _wishListBusiness;

        public WishListsController(IWishListBusinesss wishListBusiness)
        {
            _wishListBusiness = wishListBusiness;
        }

        [HttpGet]
        public async Task<IActionResult> GetWishLists()
        {
            IList<WishList> wishList = await _wishListBusiness.Query().Include(w => w.Owner).ToListAsync();

            if (wishList == null)
                return NotFound();

            return Ok(wishList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWishLists(int id)
        {
            return new JsonResult(await _wishListBusiness.GetAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostWishLists([FromBody] WishList wishList)
        {
            if (await _wishListBusiness.InsertAsync(wishList) == false)
                return StatusCode(500, "Failed to Save entity");

            return Created($"api/lists/{wishList.Id}", wishList);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutWishList(int id, [FromBody] WishList wishList)
        {
            if (await _wishListBusiness.GetAsync(id) == null)
                return NotFound();

            wishList.Id = id;

            await _wishListBusiness.UpdateAsync(wishList);

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchWishList(int id, [FromBody] JsonPatchDocument<WishList> patchDoc)
        {
            if (patchDoc == null)
                return BadRequest();

            var wishlistEntity = await _wishListBusiness.GetAsync(id);
            if (wishlistEntity == null)
                return NotFound();

            patchDoc.ApplyTo(wishlistEntity, ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _wishListBusiness.UpdateAsync(wishlistEntity) == false)
                return StatusCode(500);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWishList(int id)
        {
            var wishList = await _wishListBusiness.GetAsync(id);
            if (wishList == null)
                return NotFound();

            if (await _wishListBusiness.RemoveAsync(wishList) == false)
                return StatusCode(500);

            return NoContent();
        }
    }
}