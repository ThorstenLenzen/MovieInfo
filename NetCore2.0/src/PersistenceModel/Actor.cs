using System;

namespace Toto.MovieInfo.PersistenceModel
{
    public class Actor
    {
        public string Key { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
