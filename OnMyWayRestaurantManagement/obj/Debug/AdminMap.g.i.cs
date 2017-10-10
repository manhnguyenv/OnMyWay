﻿#pragma checksum "..\..\AdminMap.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0D4AF8658BD6E7B539A6A30D704F6832"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.34014
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Controls;
using FirstFloor.ModernUI.Windows.Converters;
using FirstFloor.ModernUI.Windows.Navigation;
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


namespace OnMyWayRestaurantManagement {
    
    
    /// <summary>
    /// AdminMap
    /// </summary>
    public partial class AdminMap : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\AdminMap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid TableMapGrid;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\AdminMap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas TableMapCanvas;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\AdminMap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Expander TableInfo;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\AdminMap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TableIdTextBlock;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\AdminMap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TableStatus;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\AdminMap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock XPosition;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\AdminMap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock YPosition;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\AdminMap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveTableButton;
        
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
            System.Uri resourceLocater = new System.Uri("/OnMyWayRestaurantManagement;component/adminmap.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AdminMap.xaml"
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
            this.TableMapGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.TableMapCanvas = ((System.Windows.Controls.Canvas)(target));
            return;
            case 3:
            this.TableInfo = ((System.Windows.Controls.Expander)(target));
            return;
            case 4:
            this.TableIdTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.TableStatus = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.XPosition = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.YPosition = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.SaveTableButton = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\AdminMap.xaml"
            this.SaveTableButton.Click += new System.Windows.RoutedEventHandler(this.SaveTableChanges);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 48 "..\..\AdminMap.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddNewTable);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

