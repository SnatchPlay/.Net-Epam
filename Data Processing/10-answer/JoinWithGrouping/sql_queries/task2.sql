SELECT city.name as city,
       sum(order_details.price_with_discount * order_details.product_amount) AS income
  FROM city
       INNER JOIN
       street ON street.city_id = city.id
       INNER JOIN
       supermarket ON supermarket.street_id = street.id
       INNER JOIN
       customer_order ON customer_order.supermarket_id = supermarket.id-- group by customer_order.supermarket_id
       INNER JOIN
       order_details ON order_details.customer_order_id = customer_order.id
 WHERE customer_order.operation_time BETWEEN '2020-11-01' AND '2020-11-30'
 GROUP BY city.id
 ORDER BY income,
          city.name;