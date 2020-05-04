SELECT d.DepositGroup, MAX(MagicWandSize) AS LongestMagicWand
    FROM WizzardDeposits AS d
    GROUP BY d.DepositGroup
