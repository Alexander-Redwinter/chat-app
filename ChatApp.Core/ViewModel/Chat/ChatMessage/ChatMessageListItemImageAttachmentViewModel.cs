using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Core
{
    public class ChatMessageListItemImageAttachmentViewModel : BaseViewModel
    {
        public string Title { get; set; }
        public string FileName { get; set; }
        //file size in bytes
        public long FileSize { get; set; }

        string thumbnailUrl;
        public string ThumbnailUrl
        {
            get => thumbnailUrl;
            set
            {
                if (value == thumbnailUrl)
                    return;

                thumbnailUrl = value;

                Task.Delay(100).ContinueWith(t => LocalFilePath = "/img/matsuri4.jpg");
                //TODO download image
                // save file to local storage cache
                // set local file path value
            }
        }

        public string LocalFilePath { get; set; }

        public bool NewItem { get; set; }

        public bool ImageLoaded => LocalFilePath != null;



    }

}
