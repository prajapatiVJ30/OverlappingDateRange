using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Model;
namespace Demo.Data
{
    public interface IDemoRepository
    {
        int Save(DemoModel model);
        List<DemoModel> Load();
    }
}
