SELECT CountryName AS [Country Name],
          IsoCode AS [ISO Code]
    	  FROM Countries
    	  WHERE LEN(CountryName) - LEN(REPLACE(CountryName, 'A', '')) >= 3
 	  ORDER BY IsoCode

  SELECT CountryName AS [Country Name], 
         IsoCode AS [ISO Code]
    	 FROM Countries
  	 WHERE CountryName LIKE '%a%a%a%'
	 ORDER BY IsoCode