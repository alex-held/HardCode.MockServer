using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Http;
using NinjaTools.FluentMockServer.API.Models;

namespace NinjaTools.FluentMockServer.API.Infrastructure
{
    public interface ISetupRepository
    {
        IEnumerable<Setup> GetAll();

        void Add(Setup setup);

        public Setup? TryGetMatchingSetup(HttpContext context);
        public IOrderedEnumerable<Match> GetMatches(HttpContext context);
    }


    [DebuggerDisplay("Score={Score}; Setup={Setup}; Rank={Rank};")]
    public class Match
    {
        public Match(Setup setup, int score)
        {
            Setup = setup;
            Score = score;
        }

        public Setup Setup { get; }
        public int Score { get; }
        public int Rank => Setup.Score;
    }
}
