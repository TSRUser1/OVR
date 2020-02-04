using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OVR
{
    class MyDataContext
    {
        ICommand msgcommand = new MSGCommand();
        public ICommand MessageCommand { get { return msgcommand; }  }
    }
}
