#pragma checksum "..\..\ModDeCautareCuvinte.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4C9EEBA2BCF614A60D3E5547F8419C261CE88E5B86E604DF918A0BD178EE4C05"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DexOnline;
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


namespace DexOnline {
    
    
    /// <summary>
    /// ModDeCautareCuvinte
    /// </summary>
    public partial class ModDeCautareCuvinte : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\ModDeCautareCuvinte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxWord;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\ModDeCautareCuvinte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxCategory;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\ModDeCautareCuvinte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxDescription;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\ModDeCautareCuvinte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Image;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\ModDeCautareCuvinte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox givenWord;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\ModDeCautareCuvinte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listWords;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\ModDeCautareCuvinte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Category;
        
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
            System.Uri resourceLocater = new System.Uri("/DexOnline;component/moddecautarecuvinte.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ModDeCautareCuvinte.xaml"
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
            
            #line 14 "..\..\ModDeCautareCuvinte.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.textBoxWord = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.textBoxCategory = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.textBoxDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Image = ((System.Windows.Controls.Image)(target));
            return;
            case 6:
            this.givenWord = ((System.Windows.Controls.TextBox)(target));
            
            #line 22 "..\..\ModDeCautareCuvinte.xaml"
            this.givenWord.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.givenWord_TextChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.listWords = ((System.Windows.Controls.ListBox)(target));
            
            #line 23 "..\..\ModDeCautareCuvinte.xaml"
            this.listWords.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.listWords_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 24 "..\..\ModDeCautareCuvinte.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Category = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

