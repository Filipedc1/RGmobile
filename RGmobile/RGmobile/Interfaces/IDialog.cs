using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RGmobile.Interfaces
{
    public interface IDialog
    {
        Task ShowDialog(string title, string message, string cancel);
        Task ShowDialog(string title, string message, string accept, string cancel);
    }
}
