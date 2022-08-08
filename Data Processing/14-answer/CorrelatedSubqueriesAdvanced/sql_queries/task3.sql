SELECT s.ptid AS product_id,
       s.ptitle AS title,
       s.mid AS manufacturer_id,
       s.mtitle AS manufacturer
  FROM (
           SELECT sum(f.amount) AS sum,
                  f.ptid AS ptid,
                  f.ptitle AS ptitle,
                  f.mid AS mid,
                  f.mtitle AS mtitle
             FROM (
                      SELECT order_details.product_id AS pid,
                             product_title.title AS ptitle,
                             manufacturer.name AS mtitle,
                             order_details.product_amount AS amount,
                             product_title.id AS ptid,
                             manufacturer.id AS mid
                        FROM order_details
                             INNER JOIN
                             product ON order_details.product_id = product.id
                             INNER JOIN
                             manufacturer ON manufacturer.id = product.manufacturer_id
                             INNER JOIN
                             product_title ON product_title.id = product.product_title_id
                  )
                  AS f
            GROUP BY f.pid
       )
       AS s
 GROUP BY product_id
HAVING max(s.sum) 
UNION
SELECT product_title.id AS product_id,
       product_title.title AS title,
       NULL AS manufacturer_id,
       NULL AS manufacturer
  FROM product_title
 WHERE product_title.id NOT IN (
           SELECT DISTINCT product.product_title_id
             FROM product
       )
 ORDER BY product_id;