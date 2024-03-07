using System.Runtime.InteropServices;


public class Clicker
{
    [DllImport("user32.dll")]
    static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, IntPtr dwExtraInfo);//mouse click

    [DllImport("user32.dll")]
    static extern short GetAsyncKeyState(int key);//hotkey
    const uint LEFT_DOWN = 0x02;
    const uint LEFT_UP = 0x04;
    const int HOTKEY = 0x2D;
    bool flag = false;

    Clicker()
    {
        while (true)
        {
            if (GetAsyncKeyState(HOTKEY) < 0)
            {
                flag = !flag;
                Thread.Sleep(150);
            }

            if (flag)
            {
                mouse_event(LEFT_DOWN, 0, 0, 0, IntPtr.Zero);
                mouse_event(LEFT_UP, 0, 0, 0, IntPtr.Zero);
            }

            Thread.Sleep(5);
        }
    }

    static void Main(string[] args)
    {
        Clicker clicker = new();
    }
}