SELECT customer_order.id as order_id,
       count() AS items_count
  FROM customer_order
       INNER JOIN
       order_details ON order_details.customer_order_id = customer_order.id
 WHERE customer_order.operation_time BETWEEN '2021-01-01' AND '2021-12-31'
 GROUP BY order_details.customer_order_id
HAVING items_count > (
                         SELECT avg(items) 
                           FROM (
                                    SELECT count(order_details.id) AS items
                                      FROM customer_order
                                           INNER JOIN
                                           order_details ON order_details.customer_order_id = customer_order.id
                                     GROUP BY order_details.customer_order_id
                                )
                     )
 ORDER BY items_count,
          order_id;
