using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Management;
using System.Diagnostics;

namespace C10L3WpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow:Window
    {
        ManagementEventWatcher watcher = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        public static ManagementEventWatcher GetWatcher(EventArrivedEventHandler handler)
        {
            //Create event query to be notified within  1 second of a change in a service

            WqlEventQuery query = new WqlEventQuery("__InstanceModificationEvent", new TimeSpan(0, 0, 1), "TargetInstance isa 'Win32_LocalTime' AND TargetInstance.Second = 0");

            //Initialize an event watcher and subscribe to events that match this query
            ManagementEventWatcher watcher = new ManagementEventWatcher(query);

            //Attach the arrived property to EventArrivedEventHandler method with the required handler to allow watcher object communicate to the application
            watcher.EventArrived += new EventArrivedEventHandler(handler);
            return watcher;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.Listeners.Add(new TextWriterTraceListener(@"C:\Listener.txt"));
            //Debug.Listeners.Add(new ConsoleTraceListener());
            Debug.AutoFlush = true;
            Debug.WriteLine("Loading Window");            

            //Event receiver is a user defined class
            Debug.WriteLine("Instantiate EventReceiver Class to receive the event");
            Trace.WriteLine("Instantiate EventReceiver Class to receive the event");
            EventReceiver receiver = new EventReceiver();

            //Here we create the watcher and register the callback whit it in one shot
            watcher = GetWatcher(new EventArrivedEventHandler(receiver.OnEventArrived));

            //Watcher starts to listen to the management Events.
            watcher.Start();
        }

        private void Window_Closed(object sender, EventArgs e)
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            watcher.Stop();
        }
    }

    public class EventReceiver
    {
        public void OnEventArrived(object sender, EventArrivedEventArgs e)
        {
            ManagementBaseObject evt = e.NewEvent;

            //Display information from the event
            string time = string.Format("{0}:{1:00}",
                ((ManagementBaseObject)evt["TargetInstance"])["Hour"],
                ((ManagementBaseObject)evt["TargetInstance"])["Minute"]);

            MessageBox.Show(time, "Current Time", MessageBoxButton.OK);
        }
    }
}
