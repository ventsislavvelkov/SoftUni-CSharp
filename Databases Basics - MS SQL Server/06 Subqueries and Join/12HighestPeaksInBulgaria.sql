SELECT mp.CountryCode, 
       m.MountainRange, 
       p.PeakName, 
       p.Elevation
FROM Peaks AS p
     INNER JOIN Mountains AS m ON p.MountainId = m.Id
     INNER JOIN MountainsCountries AS mp ON p.MountainId = mp.MountainId
WHERE mp.CountryCode = 'BG'
      AND p.Elevation > 2835
ORDER BY p.Elevation DESC