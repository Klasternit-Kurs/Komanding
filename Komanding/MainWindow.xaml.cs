using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Komanding
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			ObservableCollection<String> lst = new ObservableCollection<string>();
			lst.Add("jen");
			lst.Add("dva");
			lst.Add("tri");
			dg.ItemsSource = lst;

			RoutedUICommand komanda = new RoutedUICommand();
			CommandBinding cb = new CommandBinding();
			cb.Executed += Foo;
			cb.CanExecute += Test;
			cb.Command = komanda;
			dugme.Command = komanda;
			dugme.CommandTarget = dg;
			dugme.CommandParameter = lst;
			
			this.CommandBindings.Add(cb);

		}

		public void Test(object s, CanExecuteRoutedEventArgs a)
		{
			
			if ((a.Source as DataGrid).SelectedItem != null)
				a.CanExecute = true;
			else
				a.CanExecute = false;
		}

		public void Foo(object s, ExecutedRoutedEventArgs a)
		{
			(a.Parameter as ObservableCollection<string>).
				Remove((a.Source as DataGrid).SelectedItem as string);
			
		}
	}
}
