using System;

namespace PersistenceModel.SqlServer
{
    public partial class Actor
    {
        public Guid Id { get; set; }
        public string Key { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
    }
}
