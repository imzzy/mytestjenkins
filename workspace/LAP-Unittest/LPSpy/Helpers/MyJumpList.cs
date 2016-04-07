using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Taskbar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace LPSpy
{
    public class MyJumplist
    {
        [ComImport,
        Guid("000214F9-0000-0000-C000-000000000046"),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface IShellLinkW { }

        [DllImport("shell32.dll")]
        internal static extern void SHAddToRecentDocs(
            ShellAddToRecentDocs flags,
            [MarshalAs(UnmanagedType.Interface)] IShellLinkW link);

        internal enum ShellAddToRecentDocs
        {
            Pidl = 0x1,
            PathA = 0x2,
            PathW = 0x3,
            AppIdInfo = 0x4,       // indicates the data type is a pointer to a SHARDAPPIDINFO structure 
            AppIdInfoIdList = 0x5, // indicates the data type is a pointer to a SHARDAPPIDINFOIDLIST structure 
            Link = 0x6,            // indicates the data type is a pointer to an IShellLink instance 
            AppIdInfoLink = 0x7,   // indicates the data type is a pointer to a SHARDAPPIDINFOLINK structure  
        }

        /// <summary>
        /// Creating a JumpList for the application
        /// </summary>
        /// <param name="windowHandle"></param>
        public MyJumplist(IntPtr windowHandle)
        {
            //TaskbarManager.Instance.ApplicationId = "8d1bb6e92918a830";
            //list = JumpList.CreateJumpListForIndividualWindow(TaskbarManager.Instance.ApplicationId, windowHandle);
            /*
            list = JumpList.CreateJumpListForIndividualWindow("abc", windowHandle);
            list.KnownCategoryToDisplay = JumpListKnownCategoryType.Recent | JumpListKnownCategoryType.Frequent;
            BuildList();*/
        }
        /*
        public void AddToRecent(string destination)
        {

            list.AddToRecent(destination);
            list.Refresh();
        }


        /// <summary>
        /// Builds the Jumplist
        /// </summary>
        private void BuildList()
        {
            JumpListCustomCategory userActionsCategory = new JumpListCustomCategory("Actions");
            JumpListLink userActionLink = new JumpListLink(Assembly.GetEntryAssembly().Location, "Clear History");
            userActionLink.Arguments = "-1";

            userActionsCategory.AddJumpListItems(userActionLink);
            list.AddCustomCategories(userActionsCategory);

            string notepadPath = Path.Combine(Environment.SystemDirectory, "notepad.exe");
            JumpListLink jlNotepad = new JumpListLink(notepadPath, "Notepad");
            jlNotepad.IconReference = new IconReference(notepadPath, 0);

            string calcPath = Path.Combine(Environment.SystemDirectory, "calc.exe");
            JumpListLink jlCalculator = new JumpListLink(calcPath, "Calculator");
            jlCalculator.IconReference = new IconReference(calcPath, 0);

            string mspaintPath = Path.Combine(Environment.SystemDirectory, "mspaint.exe");
            JumpListLink jlPaint = new JumpListLink(mspaintPath, "Paint");
            jlPaint.IconReference = new IconReference(mspaintPath, 0);

            list.AddUserTasks(jlNotepad);
            list.AddUserTasks(jlPaint);
            list.AddUserTasks(new JumpListSeparator());
            list.AddUserTasks(jlCalculator);

            list.AddToRecent("Hello.txt");
            list.AddToRecent("World.txt");

            // Create a JumpListLink with the path of the application and the name of the file 
            // the name is displayed in the recent items list 
            JumpListLink link = new JumpListLink(@"c:\windows\notepad.exe", "bbc");
            link.Arguments = @"c:\Users\RJB\Desktop\file.txt"; //any argument for the stating application 
            link.IconReference = new IconReference(@"c:\windows\notepad.exe", 0); //set an icon for the link
            
            list.AddUserTasks(link);

            list.Refresh();
        }*/

        private static MethodInfo nativeShellLinkGetMethod;

        public static void AddToRecent(JumpListLink link)
        {
            if (nativeShellLinkGetMethod == null)
            {
                //find the NativeShellLink property on the JumpListLink 
                Type jumpListLinkType = typeof(JumpListLink);
                PropertyInfo nativeShellLinkProperty = jumpListLinkType.GetProperty("NativeShellLink",
                        System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

                if (nativeShellLinkProperty == null)
                    throw new InvalidOperationException();

                //Save the Method info for later use, so we have to do the reflection only once. 
                nativeShellLinkGetMethod = nativeShellLinkProperty.GetGetMethod(true);
            }

            //Get the value of the NativeShellLink property. 
            //Cast this to our own implementation of IShellLinkW because it is using COM interop. 
            IShellLinkW nativeShellLink = (IShellLinkW)nativeShellLinkGetMethod.Invoke(link, null);

            // Now make the call to Win32 to add the link to the recent items 
            SHAddToRecentDocs(ShellAddToRecentDocs.Link, nativeShellLink);
        }

        public static void ClearRecent()
        {
            SHAddToRecentDocs(0, null);
        }
    }
}
