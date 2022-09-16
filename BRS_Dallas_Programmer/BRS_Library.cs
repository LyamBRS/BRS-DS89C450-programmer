//#############################################//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO.Ports;
using System.Management;
using System.Management.Instrumentation;
using System.Threading;
//#############################################//
namespace BRS
{
    /// <summary>
    /// Debugging class. Toggle debugging on using ToggleDebug(true).
    /// Use Header to start and end a main function's debugging.
    /// Don't use headers in functions you know will be called by others.
    /// Use Comment to describe what your code is either about to do, or has done.
    /// </summary>
    public partial class Debug
    {
        public static bool DEBBUG_CONSOLE = false;
        private static int InitialStackSize = 0;
        private static int PreviousIndent = 0;
        private static int RemoveIndent = 0;
        //#########################################################//
        /// <summary>
        /// Enables all the BRS.Debug.Comment to print in
        /// Console.WriteLine(). DISABLED BY DEFAULT
        /// </summary>
        /// <param name="debugToggled">default to false, set to true to enable comment's printing</param>
        //#########################################################//
        public static void ToggleDebug(bool debugToggled)
        {
            DEBBUG_CONSOLE = debugToggled;
        }
        //#########################################################//
        /// <summary>
        /// Debug comment shown, and automatically indented in console
        /// if ToggleDebug was set to true.
        /// Used as a standard //Comment replacement. Which allows
        /// a live debugging of your code's current execution step.
        /// This function automatically adds the name of the function
        /// it was called in.
        /// </summary>
        /// <param name="message">What is your code doing</param>
        //#########################################################//
        public static void Comment(string message)
        {
            if (DEBBUG_CONSOLE)
            {
                //Check to see where we are in the stack
                StackTrace stackTrace = new StackTrace();
                StackFrame[] stackFrames = stackTrace.GetFrames();

                //Get how deep we are in the form stack
                int tabs = stackFrames.Length - InitialStackSize - RemoveIndent;

                //Get the function name
                string functionName = "";
                try
                {
                    functionName = stackFrames[1 + RemoveIndent].GetMethod().Name;
                }
                catch
                {
                }

                //Create debugging indentation
                string indentation = "";
                for (int i = 0; i < tabs; i++)
                {
                    indentation = indentation + "|\t";
                }

                //See if we need a empty seperator because stack got smaller
                if (PreviousIndent > tabs)
                {
                    Console.Write(indentation + "|\t\n");
                }

                // Stack increased, show function name
                if (PreviousIndent < tabs)
                {
                    Console.Write(indentation + "[" + functionName + "]:\n");
                }

                if (PreviousIndent != tabs)
                {
                    PreviousIndent = tabs;
                }

                // Create the string
                Console.Write(indentation + "|\t" + message + "\n");
            }
        }
        //#########################################################//
        /// <summary>
        /// Comment with automatically added [! SUCCESS !]:
        /// to remove some text from your debug comment in your
        /// script. This is to say your process was Success,
        /// and not aborted nor was there an error.
        /// </summary>
        /// <param name="message">What is your code doing</param>
        //#########################################################//
        public static void Success(string message)
        {
            if (DEBBUG_CONSOLE)
            {
                Console.ForegroundColor = ConsoleColor.Green;

                RemoveIndent = 1;
                Debug.Comment("[! SUCCESS !]: " + message);
                RemoveIndent = 0;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        //#########################################################//
        /// <summary>
        /// Comment with automatically added [* ABORTED *]:
        /// to remove some text from your debug comment in your
        /// script. This is to say your process was aborted.
        /// </summary>
        /// <param name="message">Why was it aborted</param>
        //#########################################################//
        public static void Aborted(string message)
        {
            if (DEBBUG_CONSOLE)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;

                RemoveIndent = 1;
                Debug.Comment("[* ABORTED *]: " + message);
                RemoveIndent = 0;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        //#########################################################//
        /// <summary>
        /// Comment with automatically added [? ERROR ?]:
        /// to remove some text from your debug comment in your
        /// script.  This is to say your process ran in an error.
        /// </summary>
        /// <param name="message">Why is there an error?</param>
        //#########################################################//
        public static void Error(string message)
        {
            if (DEBBUG_CONSOLE)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                RemoveIndent = 1;
                Debug.Comment("[## ERROR ##]: " + message);
                RemoveIndent = 0;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        //#########################################################//
        /// <summary>
        /// Returns true if the toggledebug was initialised at
        /// some point
        /// </summary>
        /// <returns></returns>
        //#########################################################// 
        public static bool CheckIfDebugging()
        {
            return DEBBUG_CONSOLE;
        }
        //#########################################################//
        /// <summary>
        /// Break lines at the start and end of a big function.
        /// Avoid placing these in functions called by multiple functions.
        /// </summary>
        /// <param name="start"> set to true when starting your main function debug. Set to false to close the debug</param>
        //#########################################################//
        public static void Header(bool start)
        {
            if (DEBBUG_CONSOLE)
            {
                //Check to see where we are in the stack
                StackTrace stackTrace = new StackTrace();
                StackFrame[] stackFrames = stackTrace.GetFrames();

                InitialStackSize = stackFrames.Length;
                PreviousIndent = InitialStackSize;

                string functionName = stackFrames[1].GetMethod().Name;

                string header = start ? "|/__|/__|/__|/__|/__|/__|/__|/__|/__|/__|/__|/__|/__|/__|/__|/__|/ " :
                                        "/|__/|__/|__/|__/|__/|__/|__/|__/|__/|__/|__/|__/|__/|__/|__/|__/| ";

                // Create the string
                Console.WriteLine(header + "[" + functionName + "]: " + (start ? "START" : "END"));

                //line return on header end
                if (start == false)
                {
                    Console.WriteLine("");
                }
            }
        }
    }
    //#########################################################//
    /// <summary>
    /// Class handling pop up messages.
    /// Made using MessageBox.
    /// Those are prefab message boxes that helps uniformize
    /// standard pop up messages in your applications
    /// while reducing the amount of shown code in your scripts.
    /// </summary>
    //#########################################################//
    public class PopUp
    {
        //#########################################################//
        /// <summary>
        /// Displays an error textbox, with an OK button.
        /// First parameter is the error message wanted for display
        /// and the second is the pop up header
        /// </summary>
        /// <param name="message">Message inside the box</param>
        /// <param name="caption">Box title or header</param>
        //#########################################################//
        public static void Error(string message, string caption)
        {
            BRS.Debug.Comment("[BRS]: Poping error box on user screen...");
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            BRS.Debug.Comment("[BRS]: Error box closed!");
        }
        //#########################################################//
        /// <summary>
        /// Pop up a warning box for your user.
        /// Has a warning icon
        /// and returns true if the user pressed on "OK"
        /// Buttons shown are "OK" and "Cancel"
        /// </summary>
        /// <param name="message">Message inside the box</param>
        /// <param name="caption">Box title or header</param>
        /// <returns> true if used clicked on OK</returns>
        //#########################################################//        
        public static bool UserWarning(string message, string caption)
        {
            BRS.Debug.Comment("[BRS]: Poping warning messagebox on user screen...");
            return (MessageBox.Show(message, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK);
        }
        //#########################################################//
        /// <summary>
        /// Pop up an information box for your user.
        /// Has an "i" information icon
        /// does not return true.
        /// Button showed is "OK"
        /// </summary>
        /// <param name="message">Message inside the box</param>
        /// <param name="caption">Box title or header</param>
        //#########################################################//
        public static void Info(string message, string caption)
        {
            BRS.Debug.Comment("[BRS]: Poping information box on user screen...");
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            BRS.Debug.Comment("[BRS]: Info box closed!");
        }
        //#########################################################//
        /// <summary>
        /// Pop up a question box for your user.
        /// Has an "?" question icon
        /// returns true if user selected "yes"
        /// Button showed is "Yes" and "No"
        /// </summary>
        /// <param name="message">Message inside the box</param>
        /// <param name="caption">Box title or header</param>
        //#########################################################//
        public static bool Question(string message, string caption)
        {
            BRS.Debug.Comment("[BRS]: Poping question box on user screen...");
            return (MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
        }
    }
    //#########################################################//
    /// <summary>
    ///  Class handling windows file saving or opening window.
    ///  They do not handle paths, they will return the file
    ///  path or ABORT if the user ended their dialogs
    /// </summary>
    //#########################################################//
    public class Dialog
    {
        //#########################################################//
        /// <summary>
        /// Handles the entire save file dialog event for you.
        /// The input filter will define the type of file ot save.
        /// And will create the path returned. If ABORT is returned
        /// it means the user canceled the saving process
        /// </summary>
        /// <param name="header">Title of your windows pop up window</param>
        /// <param name="filter">string being the filter your dialog will have when looking through files</param>
        /// <returns>file path or "ABORT"</returns>
        //#########################################################// 
        public static string SaveTextFile(string header, string filter)
        {
            BRS.Debug.Comment("Creating a new SaveFileDialog");
            SaveFileDialog SFD = new SaveFileDialog();

            BRS.Debug.Comment("Setting dialogs settings to:");
            BRS.Debug.Comment("Filter: " + filter);
            SFD.Filter = filter;
            BRS.Debug.Comment("Header: " + header);
            SFD.Title = header;

            //////////////////////////////////////////////////////////////////////////// - [ checks ]
            BRS.Debug.Comment("Showing dialog and waiting for user confirmation...");
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                BRS.Debug.Success("Dialog processed by user");
                BRS.Debug.Comment("Executing precautionary checks on the file path...");
                // Check if directory path exist
                if (SFD.CheckPathExists)
                {
                    if (!SFD.CheckFileExists)
                    {
                        // If name was empty
                        if (SFD.FileName.Contains("among us"))
                        {
                            BRS.Debug.Aborted("Unallowed file name used. among us is not valid");
                            BRS.PopUp.Error("Your file cannot be an imposter", "Saving Error");
                        }
                        else
                        {
                            BRS.Debug.Success("Path tests is correct.");
                            BRS.Debug.Comment("Returning the file's path name.");

                            return (SFD.FileName);
                        }
                    }
                    else
                    {
                        BRS.Debug.Error("File is a duplicate");
                        BRS.PopUp.Error("This file already exist", "Saving Error");
                    }
                }
                else
                {
                    BRS.Debug.Error("Specified path is invalid");
                    BRS.PopUp.Error("Invalid directory path", "Saving Error");
                }
            }

            BRS.Debug.Aborted("Dialog terminated by user. Returning: ABORT");
            return ("ABORT");
        }
        //#########################################################//
        /// <summary>
        /// Handles the entire open file dialog event for you.
        /// The input filter will define the type of file that can be opened.
        /// Will get the path of said file and return it. 
        /// If aborted by user, "ABORT" is returned
        /// </summary>
        /// <param name="header">Title of your windows pop up window</param>
        /// <param name="filter">string being the filter your dialog will have when looking through files</param>
        /// <returns>file path or "ABORT"</returns>
        //#########################################################// 
        public static string OpenFile(string header, string filter)
        {
            string result = "ABORT";

            BRS.Debug.Comment("Creating new open file dialog");
            OpenFileDialog OFD = new OpenFileDialog();

            // Set filters for an RTF documents
            BRS.Debug.Comment("Setting dialogs settings to:");
            BRS.Debug.Comment("Setting filter to: " + filter);
            try
            {
                OFD.Filter = filter;
                BRS.Debug.Success("");
            }
            catch
            {
                BRS.Debug.Error("FILTER IS NOT VALID");
                BRS.Debug.Error("FILTER IS NOT VALID");
                BRS.Debug.Error("FILTER IS NOT VALID");
                return ("ABORT");
            }
            BRS.Debug.Comment("Header: " + header);
            OFD.Title = header;

            BRS.Debug.Comment("Poping up dialog to the user. Awaiting input");
            //////////////////////////////////////////////////////////////////////////// - [ checks ]
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                BRS.Debug.Success("Dialog processed by user");
                BRS.Debug.Comment("Executing precautionary checks on the file path...");

                // If name was sus
                if (OFD.FileName.Contains("among us"))
                {
                    BRS.Debug.Aborted("Unallowed file name used. among us is not valid");
                    BRS.PopUp.Error("Your file cannot be an imposter", "Saving Error");
                }
                else
                {
                    //Check if file is .rtf
                    if (true)
                    {
                        BRS.Debug.Success("Precautionary tests on path");
                        BRS.Debug.Comment("Setting result to file path");
                        //////////////////////////////////////////////////////////// - [Create new RTF file]
                        result = OFD.FileName;
                        ////////////////////////////////////////////////////////////
                    }
                    else
                    {
                        BRS.PopUp.Error("If you see this, cry.", "if(true) was false...");
                        return ("ABORT");
                    }
                }
            }
            BRS.Debug.Comment("Returning: " + result);
            return (result);
        }
    }
    //#########################################################//
    /// <summary>
    ///  Class helping the handling of communication ports
    ///  Or SerialPorts.
    /// </summary>
    //#########################################################//
    public class ComPorts
    {
        public static SerialPort FTDIPort = new SerialPort();
        public static string ConnectedFTDI = "No Device";
        public static string FTDIComName = "No Device"; //COM4 COM5 ect

        static ManagementClass processClass = new ManagementClass("Win32_PnPEntity");

        //#########################################################//
        /// <summary>
        /// Lists all the USB ports, no matter their types for 
        /// debugging purposes
        /// </summary>
        //#########################################################//
        public static void ListUSBPorts()
        {
            //####################################################################### From Gaurav Sangwan 2017
            ManagementObjectCollection Ports = processClass.GetInstances();

            BRS.Debug.Comment("[BRS]: Printing all available ports:");
            foreach (ManagementObject prop in Ports)
            {
                if (prop.GetPropertyValue("Name") != null)
                {
                    if (prop.GetPropertyValue("Name").ToString().Contains("USB") ||
                        prop.GetPropertyValue("Name").ToString().Contains("COM"))
                    {
                        BRS.Debug.Comment("\t" + prop.GetPropertyValue("Name").ToString() + "\t" + Convert.ToString(prop));
                    }
                }
            }
            //#######################################################################
            BRS.Debug.Comment("[BRS]: Printing all available properties:");
            PropertyDataCollection properties = processClass.Properties;
            foreach (PropertyData property in properties)
            {
                BRS.Debug.Comment("\t" + property.Name);

                foreach (QualifierData q in property.Qualifiers)
                {
                    BRS.Debug.Comment("\t\t" + Convert.ToString(q.Name));
                    if (q.Name.Equals("Description"))
                    {
                        BRS.Debug.Comment(Convert.ToString(q));
                    }
                }
            }
        }
        //#########################################################//
        /// <summary>
        /// Creates the thread which checks for changes in the serial ports
        /// and then calls LookForFTDI once a change occured
        /// </summary>
        //#########################################################// 
        public static void startFTDIUpdater()
        {
            BRS.Debug.Comment("Creating FTDI thread");
            Thread FTDIThread = new Thread(LookForSerialChanges);
            BRS.Debug.Comment("Starting thread!");
            FTDIThread.Start();
        }
        //#########################################################//
        /// <summary>
        /// Thread function looking for changes in serial ports
        /// </summary>
        //#########################################################// 
        private static void LookForSerialChanges()
        {
            WqlEventQuery query = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent");
            ManagementEventWatcher watcher = new ManagementEventWatcher(query);

            watcher.EventArrived += new EventArrivedEventHandler(HandleSerialChanges);

            // Start listening for events
            watcher.Start();

            // Do something while waiting for events
            System.Threading.Thread.Sleep(500);

            // Stop listening for events
            //watcher.Stop();
        }
        private static void HandleSerialChanges(object sender, EventArrivedEventArgs e)
        {
            ConnectedFTDI = LookForFTDI();
            try
            {
                FTDIComName = ConnectedFTDI.Split('(', ')')[1];
            }
            catch
            {
                FTDIComName = "No Device";
            }
        }
        //#########################################################//
        /// <summary>
        /// Searches all PnPEntities and returns the com port name
        /// of the first detected port which has FTDI as the
        /// manufacturer.
        /// </summary>
        /// <returns>Name of the FTDI port, or "No Device"</returns>
        //#########################################################// 
        public static string LookForFTDI()
        {

            ManagementObjectCollection Ports = processClass.GetInstances();

            //Update the list of  ports
            //BRS.Debug.Comment("[BRS]: Updating ManagementObjectCollection...");
            processClass = new ManagementClass("Win32_PnPEntity");
            //BRS.Debug.Success("");

            //ittering the list of USB ports
            //BRS.Debug.Comment("[BRS]: Looking for FTDI manufacturer in the given list...");
            foreach (ManagementObject prop in Ports)
            {
                if (prop.GetPropertyValue("Manufacturer") != null)
                {

                    if (prop.GetPropertyValue("Name").ToString().Contains("USB") &&
                        prop.GetPropertyValue("Name").ToString().Contains("COM") &&
                        prop.GetPropertyValue("Manufacturer").Equals("FTDI")
                        )
                    {
                        //BRS.Debug.Success("[BRS]: FTDI found: " + prop.GetPropertyValue("Name").ToString());
                        return (prop.GetPropertyValue("Name").ToString());
                    }
                }
            }
            return ("No Device");
        }

        public static bool SendHexFileDS89(string HexString)
        {
            BRS.Debug.Comment("Checking if FTDI Port is opened");
            if(FTDIPort.IsOpen)
            {
                string result = "";
                BRS.Debug.Comment("Sending ENTER...");
                FTDIPort.Write("\r");
                Thread.Sleep(10);

                result = BRS.ComPorts.ReadPort(FTDIPort,10,100);
                BRS.Debug.Comment(result);

                BRS.Debug.Comment("Sending KILL value");
                FTDIPort.Write("K\r");
                Thread.Sleep(100);
                BRS.Debug.Comment("Parsing Dallas's response...");

                result = BRS.ComPorts.ReadPort(FTDIPort, 10, 100);
                BRS.Debug.Comment(result);
                BRS.Debug.Comment("[FINISHED]");

                BRS.Debug.Comment("Checking for >");
                if(!result.Contains(">"))
                {
                    BRS.Debug.Error("No appropriate answers from FTDI");
                    return(false);
                }
                BRS.Debug.Success("[FINISHED]");

                Thread.Sleep(100);
                BRS.Debug.Comment("Sending L value");
                FTDIPort.Write("L\r");
                Thread.Sleep(100);
                BRS.Debug.Comment("Parsing Dallas's response...");

                result = BRS.ComPorts.ReadPort(FTDIPort, 10, 100);
                BRS.Debug.Comment(result);
                BRS.Debug.Comment("[FINISHED]");

                BRS.Debug.Comment("Sending hex file");
                FTDIPort.Write(HexString);
                BRS.Debug.Success("Sent!");
                return (true);
            }
            return (false);
        }
        //#########################################################// 
        /// <summary>
        /// Reads a com port, and outputs a string as the result.
        /// This will continuously read until said com port
        /// stops sending values, or this process times out.
        /// TimeOut IS AN AMOUNT OF INTERVALS
        /// </summary>
        /// <param name="port"> defined and initialised serial port to read from </param>
        /// <param name="readingIntervals">intervals in ms at which readings are done</param>
        /// <param name="TimeOut"> amount of intervals before exiting while loop</param>
        /// <returns></returns>
        //#########################################################//  
        public static string ReadPort(SerialPort port, int readingIntervals, int TimeOut)
        {
            string result = "";

            if (port.IsOpen)
            {
                BRS.Debug.Comment("Starting COM reading...");
                if (readingIntervals > 0)
                {
                    if (TimeOut > readingIntervals)
                    {
                        BRS.Debug.Success("Passed reading tests");
                        BRS.Debug.Comment("Initiating while loop...");

                        string buffer = "A";
                        while (!buffer.Equals(""))
                        {
                            buffer = port.ReadExisting();

                            if (!buffer.Equals(""))
                            {
                                result = result + buffer;
                            }

                            Thread.Sleep(readingIntervals);
                            TimeOut--;

                            if (TimeOut <= 0)
                            {
                                BRS.Debug.Error("Reading timedOut!");
                                buffer = "";
                            }
                        }
                        BRS.Debug.Success("Exited while loop, sending result...");
                        return (result);
                    }
                    else
                    {
                        BRS.Debug.Error("TimeOut Cannot be 0");
                        result = "[ERROR] TimeOut can't be 0";
                        return (result);
                    }
                }
                else
                {
                    BRS.Debug.Error("Interval cannot be below 0ms");
                    result = "[ERROR] Interval can't be 0";
                    return (result);
                }
            }
            else
            {
                BRS.Debug.Error("Attempted to read closed port");
                return ("");
            }
            result = "[ERROR] COM reading never occured.";
            BRS.Debug.Error("Something went wrong");
            return (result);
        }
    }
    //#########################################################//
    /// <summary>
    ///  Class handling windows file saving or opening window.
    ///  They do not handle paths, they will return the file
    ///  path or ABORT if the user ended their dialogs
    /// </summary>
    //#########################################################//
    public class FileWatcher
    {
        private static string FileLocation = "empty";
        private static FileSystemWatcher watcher;
        public static bool FileChanged = false;
        //#########################################################//
        /// <summary>
        /// Sets the path for the checker to perform change checks
        /// </summary>
        /// <param name="path">File path</param>
        //#########################################################// 
        public static void SetFileLocation(string path)
        {
            FileLocation = path;
        }

        public static void CreateFileWatcher()
        {
            string result = "";
            BRS.Debug.Comment("Checking if path is valid...");
            if(File.Exists(FileLocation))
            {
                BRS.Debug.Success("Path is valid, getting directory path");
                result = Path.GetDirectoryName(FileLocation);
            }
            else
            {
                BRS.Debug.Error("Path invalid");

                return;
            }

            BRS.Debug.Comment("Overwriting file watcher using new location");
            watcher = new FileSystemWatcher(@result);

            BRS.Debug.Comment("Setting notification parameters...");
            watcher.NotifyFilter = NotifyFilters.LastWrite;

            BRS.Debug.Comment("Creating watcher handler...");
            watcher.Changed += OnChanged;
            watcher.Filter = "*.hex";

            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;
        }

        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }
            BRS.Debug.Comment("HEX file has changed");
            FileChanged = true;
        }
    }
}
