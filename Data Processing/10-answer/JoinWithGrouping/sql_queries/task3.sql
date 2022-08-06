SELECT person.surname AS surname,
       person.name AS name,
       person.birth_date AS birth_date,
       sum(order_details.price * order_details.product_amount) AS sum
  FROM person
       INNER JOIN
       customer ON customer.person_id = person.id
       INNER JOIN
       customer_order ON customer_order.customer_id = customer.person_id
       INNER JOIN
       order_details ON order_details.customer_order_id = customer_order.id
 WHERE customer_order.operation_time BETWEEN '2021-01-01' AND '2021-12-31'
 GROUP BY customer.discount
HAVING discount = 0
 ORDER BY sum,
          surname;