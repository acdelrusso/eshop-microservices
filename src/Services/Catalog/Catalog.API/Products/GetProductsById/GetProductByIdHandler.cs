﻿namespace Catalog.API.Products.GetProductsById;

public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;

public record GetProductByIdResult(Product Product);

public class GetProductByQueryIdHandler
    (IDocumentSession session, ILogger<GetProductByIdResult> logger)
    : IRequestHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductByIdHandler.Handle called with {@Query}", query);

        var product = await session.LoadAsync<Product>(query.Id, cancellationToken);

        if (product == null)
        {
            throw new ProductNotFoundException(query.Id);

        }

        return new GetProductByIdResult(product);
    }
}
