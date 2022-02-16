SELECT TOP(3) COUNT(Order_details.order_id) AS cnt, Product.product_name
FROM Order_details
JOIN Product ON (Order_details.product_id = Product.id)
GROUP BY Product.product_name
ORDER By cnt DESC