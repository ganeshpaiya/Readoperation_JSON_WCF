using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CURD_JSON_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service.svc or Service.svc.cs at the Solution Explorer and start debugging.
    public class Service : IService
    {
        public bool create(details details)
        {
            using (MyEntities md = new MyEntities())
            {
                try
                {
                    details pe = new details();
                   // MyEntities pe = new MyEntities();
                    pe.ID = details.ID;
                    pe.name = details.name;
                    return true;
                }
                catch
                {
                    return false;
                }

            };
        }

        public bool delete(details details)
        {
            throw new NotImplementedException();
        }

        public bool edit(details details)
        {
            throw new NotImplementedException();
        }

        public details find(string id)
        {

            using (MyEntities md = new MyEntities())
            {
                int id1 = Convert.ToInt32(id);
                return md.tests.Where(pe => pe.ID==id1).Select(Pe=> new details
                {
                    ID =Pe.ID,
                    name =Pe.name
                }).First();

            }
        }

        public List<details> findall()
        {
           using(MyEntities md=new MyEntities())
            {
                return md.tests.Select(pe => new details {
                    ID=pe.ID,
                    name=pe.name
                }).ToList();

            }
        }
    }
}
