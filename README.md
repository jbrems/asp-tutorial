## REST API

Visit `https://localhost:5001/products` to retrieve a list of all products.

Visit `https://localhost:5001/products/{productId}` to retrieve a single product.
E.g.: `https://localhost:5001/products/jenlooper-cactus`

Visit `https://localhost:5001/products/{productId}/ratings` to fetch the ratings of a product.
E.g.: `https://localhost:5001/products/jenlooper-cactus/ratings`

To add a rating send a POST request to `/products/{productId}/ratings` with the rating in the form-urlencoded request body.
E.g.: `curl -X POST https://localhost:5001/products/jenlooper-cactus/ratings -d 'rating=6'`