using System.Runtime.InteropServices;
using System.Text.Json;
using System.Windows.Forms;

namespace StyleLibrary;

internal static class ThemeReceiver
{
    public static bool TryHandle(ref Message m, BaseStyledForm form)
    {
        if (m.Msg != NativeMethods.WM_COPYDATA) return false;

        var cds = Marshal.PtrToStructure<NativeMethods.COPYDATASTRUCT>(m.LParam);

        // Чужое WM_COPYDATA — не наше, пусть обрабатывает base.WndProc.
        if (cds.dwData != new IntPtr(ThemeBroadcaster.MagicDataId)) return false;
        if (cds.lpData == IntPtr.Zero || cds.cbData <= 0) return false;

        try
        {
            var json = Marshal.PtrToStringUTF8(cds.lpData, cds.cbData);
            if (!string.IsNullOrWhiteSpace(json))
            {
                var settings = JsonSerializer.Deserialize<StyleSettings>(json);
                if (settings is not null)
                {
                    form.ApplyStyle(settings);
                    m.Result = (IntPtr)1; // подтверждаем отправителю
                    return true;
                }
            }
        }
        catch
        {
            // Битые данные — молча игнорируем.
        }

        m.Result = IntPtr.Zero;
        return true;
    }
}
