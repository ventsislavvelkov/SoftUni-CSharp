SELECT mp.CountryCode, 
       COUNT(mp.MountainId) AS [MountainRanges]
FROM MountainsCountries AS mp
WHERE mp.CountryCode IN('BG', 'RU', 'US')
GROUP BY mp.CountryCode