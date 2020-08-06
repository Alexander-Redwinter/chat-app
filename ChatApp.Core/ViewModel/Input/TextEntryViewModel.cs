using System;
using System.Windows.Input;

namespace ChatApp.Core
{
    /// <summary>
    /// View model for any string editing entry
    /// </summary>
    public class TextEntryViewModel : BaseViewModel
    {
        public string Label { get; set; }


        /// <summary>
        /// Saved value
        /// </summary>
        public string OriginalText { get; set; }


        /// <summary>
        /// New value
        /// </summary>
        public string EditedText { get; set; }

        /// <summary>
        /// Flag to indicate that current text is in edit mode
        /// </summary>
        public bool IsEditing { get; set; }

        /// <summary>
        /// Puts the text in edit mode
        /// </summary>
        public ICommand EditCommand { get; set; }

        /// <summary>
        /// Cancels edit mode
        /// </summary>
        public ICommand CancelCommand { get; set; }

        /// <summary>
        /// Saves the value, goes back to non-edit mode
        /// </summary>
        public ICommand SaveCommand { get; set; }

        public TextEntryViewModel()
        {
            EditCommand = new RelayCommand(Edit);
            CancelCommand = new RelayCommand(Cancel);
            SaveCommand = new RelayCommand(Save);
            IsEditing = false;

        }

        private void Save()
        {
            //TODO save content
            OriginalText = EditedText;
            IsEditing = false;
        }

        private void Cancel()
        {
            IsEditing = false;
        }

        private void Edit()
        {
            EditedText = OriginalText;
            IsEditing = true;
        }
    }
}
