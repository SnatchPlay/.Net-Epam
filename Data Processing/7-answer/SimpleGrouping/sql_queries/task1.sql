﻿SELECT count(discount) AS customer_count,
       discount
  FROM customer
 GROUP BY discount
 ORDER BY discount;

