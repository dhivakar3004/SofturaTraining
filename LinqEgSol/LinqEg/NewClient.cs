using LinqEg.pubsModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LinqEg
{
    class NewClient
    {
        public static PubsContext db = new PubsContext();
        public static void Main()
        {
            List<Movie> movies = db.TblMovie.ToList();
            var result =(from i in movie
                         where i.Id)
                }
    }
}
