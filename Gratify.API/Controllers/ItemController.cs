using Gratify.Business;
using Gratify.Domain;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gratify.API.Controllers
{
    [Route("api/lists")]
    public class ItemController : Controller
    {
        private IItemBusiness _itemBusiness;
        private IWishListBusiness _wishListBusiness;

        public ItemController(IWishListBusiness wishListBusiness, IItemBusiness itemBusiness)
        {
            _wishListBusiness = wishListBusiness;
            _itemBusiness = itemBusiness;
        }

        [HttpGet("{listId}/items")]
        public async Task<IActionResult> GetItems(int listId)
        {
            if (await _wishListBusiness.GetAsync(listId) == null)
                return NotFound();

            IList<Item> items = await _itemBusiness.Query().Where(i => i.WishList.Id == listId).ToListAsync();

            if (items == null)
                return NotFound();

            return Ok(items);
        }

        [HttpGet("{listId}/items/{itemId}")]
        public async Task<IActionResult> GetItems(int listId, int itemId)
        {
            if (await _wishListBusiness.GetAsync(listId) == null)
                return NotFound();

            Item item = await _itemBusiness.Query().Where(i => i.Id == itemId).FirstOrDefaultAsync();

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost("{listId}/Items")]
        public async Task<IActionResult> PostItems(int listId, [FromBody] Item item)
        {
            item.WishList.Id = listId;

            if (await _itemBusiness.InsertAsync(item) == false)
                return StatusCode(500, "Failed to Save entity");

            return Created($"api/lists/{item.Id}", item);
        }

        [HttpPut("{listId}/Items/{itemId}")]
        public async Task<IActionResult> PutItem(int listId, int itemId, [FromBody] Item item)
        {
            var wishList = await _wishListBusiness.Query().Include(w => w.Items).FirstOrDefaultAsync(w => w.Id == listId);
            if (wishList == null)
                return NotFound();

            if (wishList.Items.FirstOrDefault(i => i.Id == itemId) == null)
                return BadRequest(@"List does not contains Item with id {itemId}");

            if (await _itemBusiness.GetAsync(itemId) == null)
                return NotFound();

            item.Id = itemId;

            await _itemBusiness.UpdateAsync(item);

            return NoContent();
        }

        [HttpPatch("{listId}/items/{itemId}")]
        public async Task<IActionResult> PatchItem(int listId, int itemId, [FromBody] JsonPatchDocument<Item> patchDoc)
        {
            if (patchDoc == null)
                return BadRequest();

            var wishList = await _wishListBusiness.Query().Include(w => w.Items).FirstOrDefaultAsync(w => w.Id == listId);
            if (wishList == null)
                return NotFound();

            if (wishList.Items.FirstOrDefault(i => i.Id == itemId) == null)
                return BadRequest(@"List does not contains Item with id {itemId}");

            var itemEntity = await _itemBusiness.GetAsync(itemId);
            if (itemEntity == null)
                return NotFound();

            patchDoc.ApplyTo(itemEntity, ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _itemBusiness.UpdateAsync(itemEntity) == false)
                return StatusCode(500);

            return NoContent();
        }

        [HttpDelete("{listId}/items/{itemId}")]
        public async Task<IActionResult> DeleteItem(int listId, int itemId)
        {
            var wishList = await _wishListBusiness.Query().Include(w => w.Items).FirstOrDefaultAsync(w => w.Id == listId);
            if (wishList == null)
                return NotFound();

            if (wishList.Items.FirstOrDefault(i => i.Id == itemId) == null)
                return BadRequest(@"List does not contains Item with id {itemId}");

            var itemEntity = await _itemBusiness.GetAsync(itemId);
            if (itemEntity == null)
                return NotFound();

            if (await _itemBusiness.RemoveAsync(itemEntity) == false)
                return StatusCode(500);

            return NoContent();
        }
    }
}