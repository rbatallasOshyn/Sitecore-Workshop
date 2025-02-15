﻿using System;
using Sitecore;
using Sitecore.Annotations;
using Sitecore.Mvc.Presentation;

namespace Workshop.Foundation.SitecoreExtensions.Extensions
{
    public static class RenderingExtensions
    {
        public static int GetIntegerParameter(this Rendering rendering, string parameterName, int defaultValue = 0)
        {
            if (rendering == null)
            {
                throw new ArgumentNullException(nameof(rendering));
            }

            var parameter = rendering.Parameters[parameterName];
            if (string.IsNullOrEmpty(parameter))
            {
                return defaultValue;
            }

            int returnValue;
            return !int.TryParse(parameter, out returnValue) ? defaultValue : returnValue;
        }

        public static bool GetUseStaticPlaceholderNames([NotNull] this Rendering rendering)
        {
            return MainUtil.GetBool(rendering.Parameters[Constants.DynamicPlaceholdersLayoutParameters.UseStaticPlaceholderNames], false);
        }
    }
}