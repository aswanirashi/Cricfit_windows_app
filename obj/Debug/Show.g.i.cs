﻿#pragma checksum "C:\Users\Kriti\Documents\Visual Studio 2010\Projects\Channel9\myChannel9\Show.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FA9525595248744725D1B053A2D51D5E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace myChannel9 {
    
    
    public partial class Show : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Image imgIcon;
        
        internal System.Windows.Controls.TextBlock lblName;
        
        internal System.Windows.Controls.Image btnRefresh;
        
        internal System.Windows.Controls.ListBox lboShow;
        
        internal System.Windows.Controls.TextBlock lblLoading;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/myChannel9;component/Show.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.imgIcon = ((System.Windows.Controls.Image)(this.FindName("imgIcon")));
            this.lblName = ((System.Windows.Controls.TextBlock)(this.FindName("lblName")));
            this.btnRefresh = ((System.Windows.Controls.Image)(this.FindName("btnRefresh")));
            this.lboShow = ((System.Windows.Controls.ListBox)(this.FindName("lboShow")));
            this.lblLoading = ((System.Windows.Controls.TextBlock)(this.FindName("lblLoading")));
        }
    }
}

