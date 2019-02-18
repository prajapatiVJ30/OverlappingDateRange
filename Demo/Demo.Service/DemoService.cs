using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.Model;
using Demo.Data;
using System.Threading.Tasks;

namespace Demo.Service
{
    public class DemoService : IDemoService
    {
        public readonly IDemoRepository _demoRepository;
        public DemoService()
        {
            _demoRepository = new DemoRepository();
        }
        public int Save(DemoModel model)
        {
            return _demoRepository.Save(model);
        }
        public  List<DemoModel> Load()
        {
            return  _demoRepository.Load();
        }
    }
}
