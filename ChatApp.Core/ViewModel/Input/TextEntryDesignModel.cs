using System;
using System.Windows.Input;

namespace ChatApp.Core
{
    /// <summary>
    /// View model for any string editing entry
    /// </summary>
    public class TextEntryDesignModel : TextEntryViewModel
    {
        public static TextEntryDesignModel Instance => new TextEntryDesignModel();

        public TextEntryDesignModel()
        {
            Label = "Name";
            OriginalText = "Redwinter";
            EditedText = "Editing";
        }
    }
}
