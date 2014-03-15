﻿// Copyright (c) André N. Klingsheim. See License.txt in the project root for license information.

using System;
using System.Web.Mvc;
using NWebsec.Modules.Configuration;
using NWebsec.Mvc.Helpers;

namespace NWebsec.Mvc.HttpHeaders
{
    /// <summary>
    /// Specifies whether the X-Content-Type-Options security header should be set in the HTTP response.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class XContentTypeOptionsAttribute : ActionFilterAttribute
    {
        private readonly HttpHeaderConfigurationOverrideHelper _headerConfigurationOverrideHelper;

        /// <summary>
        /// Gets or sets whether the X-Content-Type-Options security header should be set in the HTTP response. The default is true.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="XContentTypeOptionsAttribute"/> class
        /// </summary>
        public XContentTypeOptionsAttribute()
        {
            Enabled = true;
            _headerConfigurationOverrideHelper = new HttpHeaderConfigurationOverrideHelper();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _headerConfigurationOverrideHelper.SetXContentTypeOptionsOverride(filterContext.HttpContext, new SimpleBooleanConfigurationElement { Enabled = Enabled });
            base.OnActionExecuting(filterContext);
        }
    }
}
