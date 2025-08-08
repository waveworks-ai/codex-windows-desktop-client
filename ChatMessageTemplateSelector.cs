using System.Windows;
using System.Windows.Controls;

namespace codex_windows_desktop_client;

public class ChatMessageTemplateSelector : DataTemplateSelector
{
    public DataTemplate? UserTemplate { get; set; }
    public DataTemplate? CodexTemplate { get; set; }

    public override DataTemplate? SelectTemplate(object item, DependencyObject container)
    {
        if (item is ChatMessage message)
        {
            return message.IsUser ? UserTemplate : CodexTemplate;
        }

        return base.SelectTemplate(item, container);
    }
}
