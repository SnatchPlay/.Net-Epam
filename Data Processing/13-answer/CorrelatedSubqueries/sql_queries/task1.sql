SELECT city.id AS id,
       city.name AS name
  FROM city
 WHERE id NOT IN (
           SELECT DISTINCT street.city_id
             FROM street
       )
 ORDER BY name;
