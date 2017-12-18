using System.Collections.Generic;
using ProviderProcessing.ProcessReports;
using ProviderProcessing.ProviderDatas;

namespace ProviderProcessing.Refactored
{
    public class ProductValidator
    {
        private readonly IProductsReference productsReference;
        private readonly IMeasureUnitsReference measureUnitsReference;

        public ProductValidator(IProductsReference productsReference, IMeasureUnitsReference measureUnitsReference)
        {
            this.productsReference = productsReference;
            this.measureUnitsReference = measureUnitsReference;
        }

        public IList<ProductValidationResult> ValidateProduct(ProductData product)
        {
            var res = new List<ProductValidationResult>();
            if (!productsReference.FindCodeByName(product.Name).HasValue)
                res.Add(new ProductValidationResult(product,
                    "Unknown product name", ProductValidationSeverity.Error));

            if (product.Price <= 0)
                res.Add(new ProductValidationResult(product, "Bad price", ProductValidationSeverity.Warning));
            if (measureUnitsReference.FindByCode(product.MeasureUnitCode) == null)
                res.Add(new ProductValidationResult(product, "Bad units of measure", ProductValidationSeverity.Warning));
            return res;
        }
    }
}