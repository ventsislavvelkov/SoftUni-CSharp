using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace P07.MilitaryElite.Contracts
{
   public interface ISoldier
    {
        string Id { get; }
        string FirstName { get; }
        string   LastName { get; }
    }
}
