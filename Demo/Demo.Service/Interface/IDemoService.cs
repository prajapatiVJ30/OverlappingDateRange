using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.Model;
using System.Threading.Tasks;

namespace Demo.Service
{
    public interface IDemoService
    {
        int Save(DemoModel model);
        List<DemoModel> Load();
    }
}
