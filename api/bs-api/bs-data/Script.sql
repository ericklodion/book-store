CREATE OR REPLACE VIEW "BookView" AS
SELECT 
	B."Code",
	B."Title",
	B."Publisher",
	B."Edition",
	B."Year",
	A."Code" AS "AuthorCode",
	A."Name" AS "AuthorName",
	S."Code" AS "SubjectCode",
	S."Description" AS "SubjectDescription",
	P."Code" AS "PriceTableCode",
	P."Description" AS "PriceTableDescription",
	BP."Price" AS "Price"
FROM "Book" B
LEFT JOIN "BookAuthor" BA ON BA."BookCode" = B."Code"
LEFT JOIN "Author" A ON A."Code" = BA."AuthorCode"
LEFT JOIN "BookPriceTable" BP ON BP."BookCode" = B."Code"
LEFT JOIN "PriceTable" P ON P."Code" = BP."PriceTableCode"
LEFT JOIN "BookSubject" BS ON BS."BookCode" = B."Code"
LEFT JOIN "Subject" S ON S."Code" = BS."SubjectCode";