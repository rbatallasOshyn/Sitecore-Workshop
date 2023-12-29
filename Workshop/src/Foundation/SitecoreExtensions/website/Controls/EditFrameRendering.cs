using System;
using System.IO;
using System.Web.UI;
using Sitecore.Web.UI.WebControls;

namespace Workshop.Foundation.SitecoreExtensions.Controls
{
    public class EditFrameRendering : IDisposable
    {
        private readonly EditFrame editFrame;
        private readonly HtmlTextWriter htmlWriter;

        public EditFrameRendering(TextWriter writer, string dataSource, string buttons)
        {
            this.htmlWriter = new HtmlTextWriter(writer);
            this.editFrame = new EditFrame
            {
                DataSource = dataSource,
                Buttons = buttons
            };
            this.editFrame.RenderFirstPart(this.htmlWriter);
        }

        public void Dispose()
        {
            this.editFrame.RenderLastPart(this.htmlWriter);
            this.htmlWriter.Dispose();
        }
    }
}