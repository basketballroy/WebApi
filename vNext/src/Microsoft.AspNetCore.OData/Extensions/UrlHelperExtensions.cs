﻿// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.WebApiCompatShim;
using Microsoft.AspNetCore.OData.Common;
using Microsoft.AspNetCore.OData.Routing;
using Microsoft.AspNetCore.Routing;

namespace Microsoft.AspNetCore.OData.Extensions
{
    /// <summary>
    /// Provides extension methods for the <see cref="UrlHelper"/> class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class UrlHelperExtensions
    {
        /// <summary>
        /// Generates an OData link using the request's OData route name and path handler and given segments.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="segments">The OData path segments.</param>
        /// <returns>The generated OData link.</returns>
        public static string CreateODataLink(this IUrlHelper urlHelper, params ODataPathSegment[] segments)
        {
            return CreateODataLink(urlHelper, segments as IList<ODataPathSegment>);
        }

        /// <summary>
        /// Generates an OData link using the request's OData route name and path handler and given segments.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="segments">The OData path segments.</param>
        /// <returns>The generated OData link.</returns>
        public static string CreateODataLink(this IUrlHelper urlHelper, IList<ODataPathSegment> segments)
        {
			//if (urlHelper == null)
			//{
			//	throw Error.ArgumentNull("urlHelper");
			//}

			//HttpRequestMessage request = urlHelper.ActionContext.HttpContext.GetHttpRequestMessage();
			//Contract.Assert(request != null);
	  //      var odataProperties = urlHelper.ActionContext.HttpContext.ODataProperties();
			////string routeName = odataProperties.RouteName;
			////if (String.IsNullOrEmpty(routeName))
			////{
			////	throw Error.InvalidOperation(SRResources.RequestMustHaveODataRouteName);
			////}

			//IODataPathHandler pathHandler = urlHelper.ActionContext.HttpContext.ODataPathHandler();
			//return CreateODataLink(urlHelper, null, pathHandler, segments);
			return "http://service-root/";
        }

   //     /// <summary>
   //     /// Generates an OData link using the given OData route name, path handler, and segments.
   //     /// </summary>
   //     /// <param name="urlHelper">The URL helper.</param>
   //     /// <param name="routeName">The name of the OData route.</param>
   //     /// <param name="pathHandler">The path handler to use for generating the link.</param>
   //     /// <param name="segments">The OData path segments.</param>
   //     /// <returns>The generated OData link.</returns>
   //     public static string CreateODataLink(this IUrlHelper urlHelper, string routeName, IODataPathHandler pathHandler,
   //         IList<ODataPathSegment> segments)
   //     {
			//if (urlHelper == null)
			//{
			//	throw Error.ArgumentNull("urlHelper");
			//}

			//if (pathHandler == null)
			//{
			//	throw Error.ArgumentNull("pathHandler");
			//}

			//string odataPath = pathHandler.Link(new ODataPath(segments));
			//return urlHelper.Link(
			//	 "ODataRoute",
			//	 new RouteValueDictionary() { { "odataPath", odataPath } });
			//return "http://service-root/";
   //     }
    }
}
