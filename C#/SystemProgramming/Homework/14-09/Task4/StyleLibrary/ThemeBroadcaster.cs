using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;

namespace StyleLibrary;

public static class ThemeBroadcaster
{
    public const string TargetWindowTitle = "Styled WinForms App";

    public const int MagicDataId = 0x5354; // 'S','T'

    public static void Send(StyleSettings settings)
    {
        var hwnd = NativeMethods.FindWindow(null, TargetWindowTitle);
        if (hwnd == IntPtr.Zero || !NativeMethods.IsWindow(hwnd))
            throw new InvalidOperationException(
                $"Окно \"{TargetWindowTitle}\" не найдено. Запустите App1.");

        var json = JsonSerializer.Serialize(settings);
        var bytes = Encoding.UTF8.GetBytes(json);

        // Буфер должен жить до возврата из SendMessage — получатель читает его напрямую.
        var ptr = Marshal.AllocHGlobal(bytes.Length);
        try
        {
            Marshal.Copy(bytes, 0, ptr, bytes.Length);

            var cds = new NativeMethods.COPYDATASTRUCT
            {
                dwData = new IntPtr(MagicDataId),
                cbData = bytes.Length,
                lpData = ptr
            };

            var result = NativeMethods.SendMessage(
                hwnd,
                NativeMethods.WM_COPYDATA,
                IntPtr.Zero,
                ref cds);

            if (result == IntPtr.Zero)
                throw new InvalidOperationException("App1 отклонил сообщение стиля.");
        }
        finally
        {
            Marshal.FreeHGlobal(ptr);
        }
    }
}
