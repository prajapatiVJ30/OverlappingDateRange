using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.Model;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace Demo.Data
{
    public class DemoRepository : IDemoRepository
    {

        public int Save(DemoModel model)
        {
            using (DemoDBContext dbcontext = new DemoDBContext())
            {
                dbcontext.Demoes.Add(model);
                dbcontext.SaveChanges();
            }
            return model.ID;
        }
        public List<DemoModel> Load()
        {
            using (DemoDBContext dbcontext = new DemoDBContext())
            {
                return  dbcontext.Demoes.ToList();
            }
        }
    }
}
