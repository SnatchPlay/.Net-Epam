UPDATE product
   SET price = price-(price*25/100)
 WHERE product_title_id IN (
    SELECT id
      FROM product_title
     WHERE product_category_id = 1 OR 
           product_category_id = 3
);