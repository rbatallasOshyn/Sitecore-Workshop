﻿using System;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Mvc;
using Sitecore.Mvc.Helpers;
using Sitecore.Data.Fields;
using Sitecore;
using Workshop.Foundation.SitecoreExtensions.Controls;
using Workshop.Foundation.SitecoreExtensions.Attributes;

namespace Workshop.Foundation.SitecoreExtensions.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static HtmlString ImageField(this SitecoreHelper helper, ID fieldID, int mh = 0, int mw = 0, string cssClass = null, bool disableWebEditing = false)
        {
            return helper.Field(fieldID.ToString(), new
            {
                mh,
                mw,
                DisableWebEdit = disableWebEditing,
                @class = cssClass ?? ""
            });
        }

        public static HtmlString ImageField(this SitecoreHelper helper, ID fieldID, Item item, int mh = 0, int mw = 0, string cssClass = null, bool disableWebEditing = false)
        {
            return helper.Field(fieldID.ToString(), item, new
            {
                mh,
                mw,
                DisableWebEdit = disableWebEditing,
                @class = cssClass ?? ""
            });
        }

        public static HtmlString ImageField(this SitecoreHelper helper, string fieldName, Item item, int mh = 0, int mw = 0, string cssClass = null, bool disableWebEditing = false)
        {
            return helper.Field(fieldName, item, new
            {
                mh,
                mw,
                DisableWebEdit = disableWebEditing,
                @class = cssClass ?? ""
            });
        }

        public static EditFrameRendering BeginEditFrame<T>(this HtmlHelper<T> helper, string dataSource, string buttons)
        {
            var frame = new EditFrameRendering(helper.ViewContext.Writer, dataSource, buttons);
            return frame;
        }

        public static HtmlString DynamicPlaceholder(this SitecoreHelper helper, string placeholderName, bool useStaticPlaceholderNames = false)
        {
            return useStaticPlaceholderNames ? helper.Placeholder(placeholderName) : helper.DynamicPlaceholder(placeholderName);
        }

        public static HtmlString Field(this SitecoreHelper helper, ID fieldID)
        {
            Assert.ArgumentNotNullOrEmpty(fieldID, nameof(fieldID));
            return helper.Field(fieldID.ToString());
        }

        public static HtmlString Field(this SitecoreHelper helper, ID fieldID, object parameters)
        {
            Assert.ArgumentNotNullOrEmpty(fieldID, nameof(fieldID));
            Assert.IsNotNull(parameters, nameof(parameters));
            return helper.Field(fieldID.ToString(), parameters);
        }

        public static HtmlString Field(this SitecoreHelper helper, ID fieldID, Item item, object parameters)
        {
            Assert.ArgumentNotNullOrEmpty(fieldID, nameof(fieldID));
            Assert.IsNotNull(item, nameof(item));
            Assert.IsNotNull(parameters, nameof(parameters));
            return helper.Field(fieldID.ToString(), item, parameters);
        }

        public static HtmlString Field(this SitecoreHelper helper, ID fieldID, Item item)
        {
            Assert.ArgumentNotNullOrEmpty(fieldID, nameof(fieldID));
            Assert.IsNotNull(item, nameof(item));
            return helper.Field(fieldID.ToString(), item);
        }

        /// <summary>
        /// Generates a hidden form field for use with form validation
        /// Required for the <see cref="ValidateRenderingIdAttribute">ValidateRenderingIdAttribute</see> to work
        /// </summary>
        /// <param name="htmlHelper">Html Helper class</param>
        /// <returns>Hidden form field with unique ID</returns>
        public static MvcHtmlString AddUniqueFormId(this HtmlHelper htmlHelper)
        {
            var uid = htmlHelper.Sitecore().CurrentRendering?.UniqueId;
            return !uid.HasValue ? null : htmlHelper.Hidden(ValidateRenderingIdAttribute.FormUniqueid, uid.Value);
        }

        public static MvcHtmlString ValidationErrorFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string error)
        {
            return htmlHelper.HasError(ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData), ExpressionHelper.GetExpressionText(expression)) ? new MvcHtmlString(error) : null;
        }

        public static string RenderDate(this SitecoreHelper helper, ID fieldID, Item item, string format)
        {
            if (item != null && !string.IsNullOrEmpty(fieldID.ToString()) && !string.IsNullOrEmpty(item.Fields[fieldID].Value))
            {
                var dateField = (DateField)item.Fields[fieldID];
                return dateField != null ? DateUtil.ToServerTime(dateField.DateTime).ToString(format) : "";
            }
            return string.Empty;
        }

        public static DateTime RenderDate(this SitecoreHelper helper, ID fieldID, Item item)
        {
            if (item != null && !string.IsNullOrEmpty(fieldID.ToString()) && !string.IsNullOrEmpty(item.Fields[fieldID].Value))
            {
                var dateField = (DateField)item.Fields[fieldID];
                if (dateField != null)
                    return DateUtil.ToServerTime(dateField.DateTime);
            }
            return DateTime.MinValue;
        }

        public static bool HasError(this HtmlHelper htmlHelper, ModelMetadata modelMetadata, string expression)
        {
            var modelName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(expression);
            var formContext = htmlHelper.ViewContext.FormContext;
            if (formContext == null)
            {
                return false;
            }

            if (!htmlHelper.ViewData.ModelState.ContainsKey(modelName))
            {
                return false;
            }

            var modelState = htmlHelper.ViewData.ModelState[modelName];
            var modelErrors = modelState?.Errors;
            return modelErrors?.Count > 0;
        }
    }
}