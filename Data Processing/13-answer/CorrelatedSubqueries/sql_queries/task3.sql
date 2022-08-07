SELECT s1.idd AS id,
       s1.titles AS title,
       s1.prices AS price
  FROM (
           SELECT product.id AS idd,
                  product.comment AS titles,
                  product.price AS prices,
                  product_category.id AS id2
             FROM product
                  JOIN
                  product_title ON product_title.id = product.product_title_id
                  JOIN
                  product_category ON product_title.product_category_id = product_category.id
       )
       AS s1
       JOIN
       (
           SELECT avg(product.price) AS avg,
                  product_category.id AS name
             FROM product
                  JOIN
                  product_title ON product_title.id = product.product_title_id
                  JOIN
                  product_category ON product_title.product_category_id = product_category.id
            GROUP BY product_category.name
       )
       AS s ON s.name = s1.id2
 WHERE price > s.avg
 ORDER BY id;