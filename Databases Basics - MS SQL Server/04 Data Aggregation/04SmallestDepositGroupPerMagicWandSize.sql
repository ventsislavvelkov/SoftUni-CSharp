SELECT TOP(2) DepositGroup
      FROM  WizzardDeposits AS w
      GROUP BY  w.DepositGroup
      ORDER BY  AVG(MagicWandSize)