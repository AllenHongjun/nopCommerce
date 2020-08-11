﻿using Nop.Core.Caching;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Orders;
using Nop.Services.Caching;

namespace Nop.Services.Catalog.Caching
{
    /// <summary>
    /// Represents a product cache event consumer
    /// </summary>
    public partial class ProductCacheEventConsumer : CacheEventConsumer<Product>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(Product entity)
        {
            RemoveByPrefix(_staticCacheManager.PrepareKeyPrefix(NopCatalogDefaults.ProductManufacturersByProductPrefix, entity));
            Remove(NopCatalogDefaults.ProductsHomepageCacheKey);
            RemoveByPrefix(_staticCacheManager.PrepareKeyPrefix(NopCatalogDefaults.ProductPricePrefix, entity));
            RemoveByPrefix(NopEntityCacheDefaults<ShoppingCartItem>.AllPrefix);
        }
    }
}
