using Android.App;
using Android.Runtime;
using Microsoft.Maui.Handlers;

namespace NeoOrder.OneGate.Platforms.Android;

[Application]
public class MainApplication(IntPtr handle, JniHandleOwnership ownership) : MauiApplication(handle, ownership)
{
    protected override MauiApp CreateMauiApp()
    {
        EditorHandler.Mapper.AppendToMapping("ReadOnlyCopyable", (handler, view) =>
        {
            if (view.IsReadOnly)
            {
                var editText = handler.PlatformView;
                editText.SetTextIsSelectable(true);
                editText.ShowSoftInputOnFocus = false;
                editText.Focusable = true;
                editText.FocusableInTouchMode = true;
                editText.Clickable = true;
                editText.LongClickable = true;
            }
        });
        return MauiProgram.CreateMauiApp();
    }
}
