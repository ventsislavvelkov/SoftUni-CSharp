SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) AS [MinDepositCharge]
    FROM WizzardDeposits AS w
    GROUP BY w.DepositGroup, w.MagicWandCreator
    ORDER BY w.MagicWandCreator, w.DepositGroup