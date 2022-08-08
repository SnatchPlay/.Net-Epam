 SELECT m.product_id as id,m.title,m.count_with_discount_5,m.count_without_discount_5,
      ifnull( round( (1.0 * (count_with_discount_5 - count_without_discount_5) / (count_with_discount_5 + count_without_discount_5) ) * 100, 2),0.0) AS difference
  FROM (
           SELECT product.id AS product_id,
                  product.comment AS title,
                  IFNULL(sum(other.amount), 0) AS count_with_discount_5,
                  IFNULL(sum(g.amount), 0) AS count_without_discount_5
             FROM product
                  LEFT JOIN
                  (
                      SELECT g.pid AS pid,
                             g.title,
                             sum(g.amount) AS amount
                        FROM (
                                 SELECT product.comment AS title,
                                        order_details.product_id AS pid,
                                        order_details.product_amount AS amount,
                                        order_details.price AS price,
                                        order_details.price_with_discount AS price_with_discount,
                                        round((100 - ( (order_details.price_with_discount * 100) / order_details.price) ),2) AS percentage
                                   FROM order_details
                                        INNER JOIN
                                        product ON product.id = order_details.product_id
                                  WHERE percentage <= 5
                             )
                             AS g
                       GROUP BY g.pid
                  )
                  AS g ON g.pid = product_id
                  LEFT JOIN
                  (
                      SELECT g.pid AS pid,
                             g.title,
                             sum(g.amount) AS amount
                        FROM (
                                 SELECT product.comment AS title,
                                        order_details.product_id AS pid,
                                        order_details.product_amount AS amount,
                                        order_details.price AS price,
                                        order_details.price_with_discount AS price_with_discount,
                                        round((100 - ( (order_details.price_with_discount * 100) / order_details.price) ),2) AS percentage
                                   FROM order_details
                                        INNER JOIN
                                        product ON product.id = order_details.product_id
                                  WHERE percentage > 5
                             )
                             AS g
                       GROUP BY g.pid
                  )
                  AS other ON product_id = other.pid
            GROUP BY product_id
       )
       AS m
 ORDER BY m.product_id;