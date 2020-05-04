SELECT DepositGroup, SUM (DepositAmount) AS [TotalSum]
    FROM WizzardDeposits AS w
    GROUP BY w.DepositGroup