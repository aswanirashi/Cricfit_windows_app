﻿#pragma checksum "C:\Users\Kriti\Documents\Visual Studio 2010\Projects\Channel9\myChannel9\Control_News.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9D7B8BEB8DDCF424B56CE598027E4B47"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
    
    
    public partial class Control_News : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.ListBox lboNews;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/myChannel9;component/Control_News.xaml", System.UriKind.Relative));
            this.lboNews = ((System.Windows.Controls.ListBox)(this.FindName("lboNews")));
            this.lblLoading = ((System.Windows.Controls.TextBlock)(this.FindName("lblLoading")));
        }
    }
}

