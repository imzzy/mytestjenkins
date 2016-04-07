using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace LPWebObjects.Controls
{
    [Guid("2C2CCFED-185E-4C27-A88D-E372A360B671")]
    [TypeLibType(4160)]
    public interface IWebContainer
    {
        [DispId(1)]
        [return: MarshalAs(UnmanagedType.Interface)]
        WebButton WebButton(string nodeName);

        [DispId(2)]
        [return: MarshalAs(UnmanagedType.Interface)]
        WebEdit WebEdit(string nodeName);

        [DispId(3)]
        [return: MarshalAs(UnmanagedType.Interface)]
        WebLink WebLink(string nodeName);

        [DispId(4)]
        [return: MarshalAs(UnmanagedType.Interface)]
        WebImageLink WebImageLink(string nodeName);

        [DispId(5)]
        [return: MarshalAs(UnmanagedType.Interface)]
        WebImage WebImage(string nodeName);

        [DispId(6)]
        [return: MarshalAs(UnmanagedType.Interface)]
        WebCheckBox WebCheckBox(string nodeName);

        [DispId(7)]
        [return: MarshalAs(UnmanagedType.Interface)]
        WebRadioGroup WebRadioGroup(string nodeName);

        [DispId(8)]
        [return: MarshalAs(UnmanagedType.Interface)]
        WebFile WebFile(string nodeName);

        [DispId(9)]
        [return: MarshalAs(UnmanagedType.Interface)]
        WebArea WebArea(string nodeName);

        [DispId(10)]
        [return: MarshalAs(UnmanagedType.Interface)]
        WebVideo WebVideo(string nodeName);

        [DispId(11)]
        [return: MarshalAs(UnmanagedType.Interface)]
        WebTable WebTable(string nodeName);

        [DispId(12)]
        [return: MarshalAs(UnmanagedType.Interface)]
        WebForm WebForm(string nodeName);

        [DispId(13)]
        [return: MarshalAs(UnmanagedType.Interface)]
        WebPlugin WebPlugin(string nodeName);

        [DispId(14)]
        [return: MarshalAs(UnmanagedType.Interface)]
        WebList WebList(string nodeName);



       
    }
}
