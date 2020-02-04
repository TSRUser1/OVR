﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OVR
{
    public class MSGCommand : ICommand
    {
        public void Execute(object parameter)
        {
            MessageBox.Show(parameter.ToString());
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }
}
