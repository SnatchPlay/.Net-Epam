SELECT person.surname,
       person.name,
       person.birth_date
  FROM customer
       LEFT JOIN
       person ON customer.person_id = person.id
 WHERE person.id NOT IN (
           SELECT DISTINCT customer_id
             FROM customer_order
                  INNER JOIN
                  customer ON customer_order.customer_id = customer.person_id
       )
 ORDER BY surname,
          birth_date;