SELECT 
	b.ID,
	b.Title
FROM Bookstore.Book b
WHERE b.AuthorID is null