SELECT
       person.name AS name,
       person.surname AS surname,
       round(avg(order_details.price_with_discount * order_details.product_amount),2) AS avg_purchase,
        m.ss AS sum_purchase
  FROM order_details
 
       INNER JOIN
       customer_order ON customer_order.id = order_details.customer_order_id
       LEFT JOIN
       customer ON customer.person_id = customer_order.customer_id
       LEFT JOIN
       person ON customer.person_id = person.id 
       Left JOIN
       (
           SELECT customer_order.customer_id AS customerid,
                  sum(f.order_sum) AS ss
             FROM customer_order
                  INNER JOIN
                  (
                      SELECT order_details.customer_order_id AS id,
                             sum(order_details.price_with_discount * order_details.product_amount) AS order_sum
                        FROM order_details
                        
                       GROUP BY order_details.customer_order_id
                  )
                  AS f ON customer_order.id = f.id
            GROUP BY customer_order.customer_id
       )
       AS m ON  (m.customerid = customer_order.customer_id or (m.customerid IS NULL and customer_order.customer_id IS NULL))
        where order_details.id>0
 GROUP BY customer_order.customer_id
HAVING avg_purchase > 70
 ORDER BY sum_purchase,
          surname