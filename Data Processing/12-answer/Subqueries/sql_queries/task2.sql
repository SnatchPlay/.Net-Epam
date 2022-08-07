SELECT person.surname AS surname,
       person.name AS name,
       sum(order_details.price_with_discount * order_details.product_amount) AS total_expenses
  FROM person
       INNER JOIN
       customer_order ON customer_order.customer_id = person.id
       INNER JOIN
       order_details ON order_details.customer_order_id = customer_order.id
 WHERE person.birth_date >= '2000-01-01' AND 
       person.birth_date <= '2010-12-31'
 GROUP BY person.id
HAVING total_expenses > (
                            SELECT avg(sum) 
                              FROM (
                                       SELECT sum(order_details.price_with_discount * order_details.product_amount) AS sum
                                         FROM person
                                              INNER JOIN
                                              customer_order ON customer_order.customer_id = person.id
                                              INNER JOIN
                                              order_details ON order_details.customer_order_id = customer_order.id
                                        GROUP BY person.id
                                   )
                        )
 ORDER BY total_expenses,
          surname;