SELECT TOP (5) c.CountryName, 
               MAX(p.Elevation) AS [HighestPeakElevation], 
               MAX(r.[Length]) AS [LongestRiverLength]
FROM MountainsCountries AS mp
     LEFT JOIN Peaks AS p ON mp.MountainId = p.MountainId
     LEFT JOIN Countries AS c ON mp.CountryCode = c.CountryCode
     LEFT JOIN CountriesRivers AS cr ON mp.CountryCode = cr.CountryCode
     LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
GROUP BY c.CountryName
ORDER BY [HighestPeakElevation] DESC, 
         [LongestRiverLength] DESC, 
         c.CountryName