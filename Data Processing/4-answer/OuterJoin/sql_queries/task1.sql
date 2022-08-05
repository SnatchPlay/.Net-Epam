SELECT product_category.name AS category,
       product_title.title AS product
  FROM product_title
       LEFT JOIN
       product_category ON product_category.id = product_title.product_category_id
       INNER JOIN
       product ON product.product_title_id = product_title.id
 WHERE product.id NOT IN (
           SELECT order_details.product_id
             FROM order_details
       )
 ORDER BY product.id
