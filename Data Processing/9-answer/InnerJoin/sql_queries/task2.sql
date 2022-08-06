SELECT product.id,
       product_title.title,
       product_category.name AS category,
       product.price
  FROM product
       INNER JOIN
       product_title ON product.product_title_id = product_title.id
       INNER JOIN
       product_category ON product_category.id = product_title.product_category_id
 ORDER BY product_category.name,
          product_title.title;