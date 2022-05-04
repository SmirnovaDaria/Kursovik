﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Kursovik
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ZooparkEntities Context;

        void ApplicationStart(object sender, StartupEventArgs args)
        {
            Context = new ZooparkEntities();
        }
    }
}
