SELECT customer_order_id,
       sum(price * product_amount) AS to_pay
  FROM order_details
 GROUP BY customer_order_id
HAVING to_pay > 100
 ORDER BY customer_order_id;