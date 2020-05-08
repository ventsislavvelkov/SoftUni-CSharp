SELECT COUNT(c.CountryCode) AS [CountryCode]
FROM MountainsCountries AS mc
     RIGHT JOIN Countries AS c ON mc.CountryCode = c.CountryCode
WHERE mc.MountainId IS NULL