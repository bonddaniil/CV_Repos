#pragma checksum "..\..\TracksRed.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3D1499D662602F2AA277D8B79818FD6C519FB06A159FF6B53771979B05B09746"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Lab_4;
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


namespace Lab_4 {
    
    
    /// <summary>
    /// TracksRed
    /// </summary>
    public partial class TracksRed : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\TracksRed.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox IdTrackAdd;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\TracksRed.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TrackNameAdd;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\TracksRed.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid TracksDg;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\TracksRed.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button TrackAddBt;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\TracksRed.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DeleteTrackName;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\TracksRed.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteTrackBt;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\TracksRed.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExitBt;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\TracksRed.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ChooseGroup;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\TracksRed.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CircumsChoose;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\TracksRed.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox RecordsChoose;
        
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
            System.Uri resourceLocater = new System.Uri("/Lab_4;component/tracksred.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\TracksRed.xaml"
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
            this.IdTrackAdd = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.TrackNameAdd = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TracksDg = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.TrackAddBt = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\TracksRed.xaml"
            this.TrackAddBt.Click += new System.Windows.RoutedEventHandler(this.TrackAddBt_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.DeleteTrackName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.DeleteTrackBt = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\TracksRed.xaml"
            this.DeleteTrackBt.Click += new System.Windows.RoutedEventHandler(this.DeleteTrackBt_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ExitBt = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\TracksRed.xaml"
            this.ExitBt.Click += new System.Windows.RoutedEventHandler(this.ExitBt_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.ChooseGroup = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.CircumsChoose = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            this.RecordsChoose = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

