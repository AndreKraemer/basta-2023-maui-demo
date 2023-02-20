using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceMauiDemo
{
    public static class CSharpMarkupExtensions
    {
        public static TBindable ToolTip<TBindable>(this TBindable bindable, string text) where TBindable : BindableObject
        {
            ToolTipProperties.SetText(bindable, text);
            return bindable;
        }

        public static TBindable ContextMenu<TBindable>(this TBindable bindable, FlyoutBase flyout) where TBindable : BindableObject
        {
            FlyoutBase.SetContextFlyout(bindable, flyout);
            return bindable;
        }
    }
}
