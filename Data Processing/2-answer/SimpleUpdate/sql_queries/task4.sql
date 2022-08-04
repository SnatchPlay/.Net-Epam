UPDATE product
   SET price = price + (price * 30 / 100) 
 WHERE product_title_id IN (
    SELECT id
      FROM product_title
     WHERE product_category_id = 5
);