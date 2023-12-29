using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Resources.Media;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Workshop.Foundation.SitecoreExtensions.Extensions
{
    public static class FieldExtensions
    {
        public static List<string> AccountNames(this Field securityField)
        {
            var result = new List<string>();
            if (securityField != null && securityField.HasValue)
            {
                //raw value format
                //au|car\Anonymous|pe|-item:read|pd|-item:read|au|extranet\Anonymous|pe|-item:read|pd|-item:read|
                var entries = securityField.Value
                    .Split(new[] { "au" }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(e => e.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries));

                result.AddRange(entries
                    .Where(entry => !string.IsNullOrEmpty(entry[0]))
                    .Select(entry => entry[0]));
            }

            return result;
        }

        public static string ImageUrl(this ImageField imageField)
        {
            if (imageField?.MediaItem == null)
            {
                throw new ArgumentNullException(nameof(imageField));
            }

            var options = Sitecore.Links.UrlBuilders.MediaUrlBuilderOptions.Empty;
            int width, height;

            if (int.TryParse(imageField.Width, out width))
            {
                options.Width = width;
            }

            if (int.TryParse(imageField.Height, out height))
            {
                options.Height = height;
            }
            return imageField.ImageUrl(options);
        }

        public static string ImageUrl(this ImageField imageField, Sitecore.Links.UrlBuilders.MediaUrlBuilderOptions options)
        {
            if (imageField?.MediaItem == null)
            {
                throw new ArgumentNullException(nameof(imageField));
            }

            return options == null ? imageField.ImageUrl() : HashingUtils.ProtectAssetUrl(MediaManager.GetMediaUrl(imageField.MediaItem, options));
        }

        public static string GetDroplinkValues(this Item item, ID fieldId, ID TargetId)
        {
            if (item != null && !string.IsNullOrEmpty(fieldId.ToString()) && !string.IsNullOrEmpty(TargetId.ToString()))
            {
                if (((Sitecore.Data.Fields.ReferenceField)item.Fields[fieldId]).TargetItem != null)
                    return ((Sitecore.Data.Fields.ReferenceField)item.Fields[fieldId]).TargetItem.Fields[TargetId].Value;
            }
            return null;
        }


        public static Item GetDroplinkTargetItem(this Item item, ID fieldId)
        {
            if (item != null && !string.IsNullOrEmpty(fieldId.ToString()))
            {
                if (((Sitecore.Data.Fields.ReferenceField)item.Fields[fieldId]).TargetItem != null)
                    return ((Sitecore.Data.Fields.ReferenceField)item.Fields[fieldId]).TargetItem;
            }
            return null;
        }

        public static bool IsChecked(this Field checkboxField)
        {
            if (checkboxField == null)
            {
                throw new ArgumentNullException(nameof(checkboxField));
            }
            return MainUtil.GetBool(checkboxField.Value, false);
        }
    }
}