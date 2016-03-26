using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Salon_Management
{
    public static class Receipt_Format
    {
        public static StringBuilder Header(string workerID, string ticketNumber)
        {
            StringBuilder textToPrint = new StringBuilder();
            textToPrint.AppendLine(string.Format("{0,-27}", DateTime.Now.ToString()));
            textToPrint.AppendLine("-".PadRight(27, '-'));
            textToPrint.AppendLine(string.Format("{0,-24}{1,3}", workerID, ticketNumber));
            textToPrint.AppendLine("-".PadRight(27, '-'));
            return textToPrint;
        }
    }
}
