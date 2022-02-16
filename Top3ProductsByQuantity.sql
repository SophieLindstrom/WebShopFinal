SELECT TOP(3) SUM(Order_details.quantity) AS qty, Product.product_name
FROM Order_details
JOIN Product ON (Order_details.product_id = Product.id)
GROUP BY Product.product_name
ORDER By qty DESC