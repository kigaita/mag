using System.Data.Entity.Infrastructure;

namespace UwbItContest.Web.DAL
{
    public class UwbContestContextFactory : IDbContextFactory<UwbContestContext>
    {
        public UwbContestContext Create() => new UwbContestContext("UwbContestContext");
    }
}