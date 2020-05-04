  SELECT Username,
		 SUBSTRING (
		 Email,
		 CHARINDEX('@', Email) + 1, -- Email is the string to cut from, charindex takes the first letter after @
		 LEN(Email) - CHARINDEX('@', Email) -- Len takes all symbols after @
		 )
	  AS [Email Provider]
          FROM Users
          ORDER BY [Email Provider],Username