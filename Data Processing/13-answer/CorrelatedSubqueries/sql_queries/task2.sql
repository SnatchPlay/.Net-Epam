SELECT product_category.id AS id,
       product_category.name AS name
  FROM product_category
       INNER JOIN
       (
           SELECT product_category.id AS subid,
                  product_category.name AS name
             FROM product_category
            WHERE id NOT IN (
                      SELECT product_title.product_category_id AS title_id
                        FROM product_title
                       WHERE product_title.id IN (
                                 SELECT product.product_title_id AS product_id
                                   FROM product
                                  WHERE product.id NOT IN (
                                            SELECT DISTINCT order_details.product_id
                                              FROM order_details
                                        )
                             )
                  )
       )
       AS subb ON subb.subid = id
 WHERE id IN (
           SELECT DISTINCT product_title.product_category_id AS id
             FROM product_title
            WHERE product_title.id IN (
                      SELECT product.product_title_id AS id
                        FROM product
                       WHERE product.id IN (
                                 SELECT DISTINCT order_details.product_id AS id
                                   FROM order_details
                             )
                  )
       )
 ORDER BY id;
