﻿#pragma checksum "..\..\..\Frames\GroupsInformation.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "09F9B65829AEE182E06A8BD590965D22B15C4B844F64719AA8F0B19E75AE4BAA"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Progect_accounting.Frames;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Progect_accounting.Frames {
    
    
    /// <summary>
    /// GroupsInformation
    /// </summary>
    public partial class GroupsInformation : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\Frames\GroupsInformation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DGrid;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Frames\GroupsInformation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DelBtn;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Frames\GroupsInformation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditBtn;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Frames\GroupsInformation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddBtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Progect accounting;component/frames/groupsinformation.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Frames\GroupsInformation.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.DGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.DelBtn = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\Frames\GroupsInformation.xaml"
            this.DelBtn.Click += new System.Windows.RoutedEventHandler(this.Del_group);
            
            #line default
            #line hidden
            return;
            case 3:
            this.EditBtn = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\Frames\GroupsInformation.xaml"
            this.EditBtn.Click += new System.Windows.RoutedEventHandler(this.Edit_group);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AddBtn = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\Frames\GroupsInformation.xaml"
            this.AddBtn.Click += new System.Windows.RoutedEventHandler(this.Add_group);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

