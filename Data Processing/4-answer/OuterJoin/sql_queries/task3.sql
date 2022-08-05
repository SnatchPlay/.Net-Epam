SELECT person.surname,
       person.name,
       SUM(order_details.price_with_discount * product_amount) AS sum
  FROM order_details
       INNER JOIN
       customer_order ON order_details.customer_order_id = customer_order.id
       LEFT JOIN
       person ON customer_order.customer_id = person.id
 GROUP BY person.surname,
          person.name
UNION
SELECT person.surname,
       person.name,
       0
  FROM customer
       INNER JOIN
       person ON customer.person_id = person.id
       LEFT JOIN
       customer_order ON customer.person_id = customer_order.customer_id
 WHERE customer_order.customer_id IS NULL
 ORDER BY sum,
          person.surname;
