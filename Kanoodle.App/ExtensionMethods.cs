using System;
using System.Collections.Generic;
using System.Text;

namespace Kanoodle.App
{
    public static class ExtensionMethods
    {
        public static string FormatForBoardPrint(this char v)
        {
            return v switch
            {
                'A' => $"[bold palegreen3]{v}[/]",
                'B' => $"[bold yellow]{v}[/]",
                'C' => $"[bold blue1]{v}[/]",
                'D' => $"[bold steelblue1]{v}[/]",
                'E' => $"[bold red]{v}[/]",
                'F' => $"[bold fuchsia]{v}[/]",
                'G' => $"[bold darkgreen]{v}[/]",
                'H' => $"[bold white]{v}[/]",
                'I' => $"[bold darkorange]{v}[/]",
                'J' => $"[bold lightpink1]{v}[/]",
                'K' => $"[bold grey70]{v}[/]",
                'L' => $"[bold purple4]{v}[/]",
                '-' => $"[bold grey39]{v}[/]",
                _ => " ",
            };
        }
    }
}
