DROP TABLE IF EXISTS spartans;
CREATE TABLE spartans (
	title VARCHAR(20),
	first_name VARCHAR(20),
	last_name VARCHAR(20),
	university VARCHAR(50),
	course VARCHAR(20),
	mark VARCHAR(20),
);
INSERT INTO spartans (
    title, first_name, last_name,
	university, course, mark
) VALUES (
    'Mr', 'Davy', 'Jones', 'Warwick', 'business', '2.0'
);

SELECT *
FROM spartans;