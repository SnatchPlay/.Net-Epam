SELECT product.id AS id,
       product_title.title AS product,
       product.price AS price
  FROM product
       INNER JOIN
       product_title ON product.product_title_id = product_title.id
 WHERE price > 2 * (
                       SELECT min(price) 
                         FROM product
                   )
 ORDER BY price,
          product;