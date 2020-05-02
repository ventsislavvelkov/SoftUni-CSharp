using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using P07.MilitaryElite.Contracts;
using P07.MilitaryElite.Exceptions;
using P07.MilitaryElite.IO.Constracts;
using P07.MilitaryElite.Models;

namespace P07.MilitaryElite.Core
{
   public  class Engine :IEngine
   {
       private IReader reader;
       private IWriter writer;

       private ICollection<ISoldier> soldiers;

       private Engine()
       {
           this.soldiers = new List<ISoldier>();
       }

       public Engine(IReader reader, IWriter writer)
           : this()
       {
           this.reader = reader;
           this.writer = writer;
       }

       public void Run()
       {
           string command;

           while ((command = this.reader.ReadLine()) != "End")
           {
               string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

               string soldierType = cmdArgs[0];
               int id = int.Parse(cmdArgs[1]);
               string firstName = cmdArgs[2];
               string lastName = cmdArgs[3];

               ISoldier soldier = null;

               if (soldierType == "Private")
               {
                   decimal salary = decimal.Parse(cmdArgs[4]);
                   soldier = new Private(id, firstName, lastName, salary);
               }
               else if (soldierType == "LieutenantGeneral")
               {
                   soldier = AddGeneral(cmdArgs, id, firstName, lastName);
               }
               else if (soldierType == "Engineer")
               {
                   decimal salary = decimal.Parse(cmdArgs[4]);
                   string corps = cmdArgs[5];
                   try
                   {
                       IEngineer engineer = CreateEngineer(id, firstName, lastName, salary, corps, cmdArgs);

                       soldier = engineer;
                   }
                   catch (InvalidCorpsException )
                   {
                       continue;
                   }

               }
               else if (soldierType == "Commando")
               {
                   decimal salary = decimal.Parse(cmdArgs[4]);
                   string corps = cmdArgs[5];

                   try
                   {
                       ICommando  commando = new Commando(id,firstName,lastName,salary,corps);
                       string[] missionArgs = cmdArgs.Skip(6).ToArray();

                       for (int i = 0; i < missionArgs.Length; i += 2)
                       {
                           try
                           {
                               string missionCodeName = missionArgs[i];
                               string missionState = missionArgs[i + 1];

                               IMission mission = new Mission(missionCodeName, missionState);
                               commando.AddMission(mission);
                           }
                           catch (InvalidMissionStateException )
                           {
                               continue;
                           }
                       }
                       soldier = commando;
                   }
                   catch (InvalidCorpsException ice)
                   {
                      continue;
                   }
               }
               else if (soldierType == "Spy")
               {
                   int codeNumber = int.Parse(cmdArgs[4]);

                   soldier = new Spy(id,firstName,lastName,codeNumber);
               }

               if (soldier != null)
               {
                   this.soldiers.Add(soldier);
               }
              
           }

           foreach (var solder in this.soldiers)
           {
               this.writer.WriteLine(solder.ToString());
           }
       }

       private ISoldier AddGeneral(string[] cmdArgs, int id, string firstName, string lastName)
       {
           ISoldier soldier;
           decimal salary = decimal.Parse(cmdArgs[4]);
           ILieutenantGeneral general = new LieutenantGeneral(id, firstName, lastName, salary);

           foreach (var pid in cmdArgs.Skip(5))
           {
               ISoldier privateToAdd = this.soldiers.First(s => s.Id == int.Parse(pid));

               general.AddPrivate(privateToAdd);
           }

           soldier = general;
           return soldier;
       }


       private static IEngineer CreateEngineer(int id, string firstName, string lastName, decimal salary, string corps,
           string[] cmdArgs)
       {
           IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);

           string[] repairArgs = cmdArgs.Skip(6).ToArray();

           for (int i = 0; i < repairArgs.Length; i += 2)
           {
               string partName = repairArgs[i];
               int hoursWorked = int.Parse(repairArgs[i + 1]);

               IRepair repair = new Repair(partName, hoursWorked);
               engineer.AddRepair(repair);
           }

           return engineer;
       }
   }
}
