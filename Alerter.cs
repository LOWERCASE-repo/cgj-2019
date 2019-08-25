using System;
using System.Runtime.InteropServices;

public class Alerter {
  
  [System.Runtime.InteropServices.DllImport("user32.dll")]
  private static extern System.IntPtr GetActiveWindow();
  
  [DllImport("user32.dll", SetLastError = true)]
  internal static extern int MessageBox(IntPtr hwnd, String lpText, String lpCaption, uint uType);
  
  public void Alert(string text, string title) {
    
    // uint MB_ABORTRETRYIGNORE = (uint)(0x00000002L | 0x00000010L);
    // uint MB_CANCELTRYCONTINUE = (uint)(0x00000006L | 0x00000030L);
    // uint MB_HELP = (uint)(0x00004000L | 0x00000040L);
    // uint MB_OK = (uint)(0x00000000L | 0x00000040L);
    // uint MB_OKCANCEL = (uint)(0x00000001L | 0x00000040L);
    // uint MB_RETRYCANCEL = (uint)0x00000005L;
    // uint MB_YESNO = (uint)(0x00000004L | 0x00000040L);
    // uint MB_YESNOCANCEL = (uint)(0x00000003L | 0x00000040L);
    
    MessageBox(GetActiveWindow(), text, title, (uint)(0x00000000L));
  }
  
  public void Error() {
    MessageBox(GetActiveWindow(), "", "", (uint)(0x00000010L));
  }
}