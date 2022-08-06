SELECT sum(product_amount) AS product_total,
       sum(price_with_discount * product_amount) AS to_pay_total,
       sum(price * product_amount - price_with_discount * product_amount) AS discount_total
  FROM order_details
 WHERE price != price_with_discount;
;
