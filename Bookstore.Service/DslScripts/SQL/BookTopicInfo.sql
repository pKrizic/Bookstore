SELECT 
	b.ID,
	NumberOfTopic = COUNT(t.ID)
FROM 
	Bookstore.Book b
	LEFT JOIN Bookstore.BookTopic t
	  on b.ID = t.BookID
GROUP BY
	b.ID
;