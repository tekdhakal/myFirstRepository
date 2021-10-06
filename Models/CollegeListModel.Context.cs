// Name: Pushpa Dhakal, Course: C# .NET
//Code Louisville @ Bellarmine University, Mondays 6:00PM to 8:00PM
//Spring 2020
//Instructor: Steve England
//------------------------------------------------------------------------------

namespace CollegeListOfAmerica.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class UniversitiesEntities : DbContext
    {
        public UniversitiesEntities()
            : base("name=UniversitiesEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<InstituteCampuses_> InstituteCampuses_ { get; set; }
    
        public virtual int spColleges()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spColleges");
        }
    }
}
