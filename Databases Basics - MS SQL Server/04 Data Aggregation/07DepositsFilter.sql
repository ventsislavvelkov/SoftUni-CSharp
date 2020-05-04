 SELECT w.DepositGroup, SUM (DepositAmount) AS [TotalSum]
    FROM WizzardDeposits AS w
    WHERE w.MagicWandCreator = 'Ollivander family'
    GROUP BY w.DepositGroup
    HAVING SUM(DepositAmount) < 150000
    ORDER BY [TotalSum] DESC