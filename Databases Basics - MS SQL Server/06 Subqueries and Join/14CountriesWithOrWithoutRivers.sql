SELECT TOP (5) c.CountryName, 
               r.RiverName
FROM CountriesRivers AS cr
     JOIN Rivers AS r ON cr.RiverId = r.Id
     RIGHT JOIN Countries AS c ON cr.CountryCode = c.CountryCode
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName