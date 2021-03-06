﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Common.Models;

namespace Participants.Views
{
    /// <summary>
    /// Interaction logic for ParticipantNavigationView.xaml
    /// </summary>
    public partial class ParticipantNavigationView : UserControl, IParticipantNavigationView
    {
        public ParticipantNavigationView()
        {
            InitializeComponent();
        }

        public IViewModel ViewModel
        {
            get { return (IViewModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
