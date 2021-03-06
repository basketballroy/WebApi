﻿// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License.  See License.txt in the project root for license information.

using System.Diagnostics.Contracts;
using System.Linq;
using Microsoft.AspNetCore.OData.Common;

namespace Microsoft.AspNetCore.OData.Query
{
    internal static class HandleNullPropagationOptionHelper
    {
        private const string MicrosoftEntityFrameworkCoreQueryInternalNamespace = "Microsoft.EntityFrameworkCore.Query.Internal";
        private const string EntityFrameworkQueryProviderNamespace = "System.Data.Entity.Internal.Linq";

        private const string ObjectContextQueryProviderNamespaceEF5 = "System.Data.Objects.ELinq";
        private const string ObjectContextQueryProviderNamespaceEF6 = "System.Data.Entity.Core.Objects.ELinq";

        private const string Linq2SqlQueryProviderNamespace = "System.Data.Linq";
        private const string Linq2ObjectsQueryProviderNamespace = "System.Linq";

        public static bool IsDefined(HandleNullPropagationOption value)
        {
            return value == HandleNullPropagationOption.Default ||
                   value == HandleNullPropagationOption.True ||
                   value == HandleNullPropagationOption.False;
        }

        public static void Validate(HandleNullPropagationOption value, string parameterValue)
        {
            if (!IsDefined(value))
            {
                throw Error.InvalidEnumArgument(parameterValue, (int)value, typeof(HandleNullPropagationOption));
            }
        }

        public static HandleNullPropagationOption GetDefaultHandleNullPropagationOption(IQueryable query)
        {
            Contract.Assert(query != null);

            HandleNullPropagationOption options;

            string queryProviderNamespace = query.Provider.GetType().Namespace;
            options = ResolveHandleNullPropagationOption(queryProviderNamespace);

            return options;
        }

	    private static HandleNullPropagationOption ResolveHandleNullPropagationOption(string queryProviderNamespace)
	    {
		    HandleNullPropagationOption options;
		    switch (queryProviderNamespace)
		    {
				case MicrosoftEntityFrameworkCoreQueryInternalNamespace:
				case EntityFrameworkQueryProviderNamespace:
			    case Linq2SqlQueryProviderNamespace:
			    case ObjectContextQueryProviderNamespaceEF5:
			    case ObjectContextQueryProviderNamespaceEF6:
				    options = Query.HandleNullPropagationOption.False;
				    break;

			    case Linq2ObjectsQueryProviderNamespace:
			    default:
				    options = Query.HandleNullPropagationOption.True;
				    break;
		    }
		    return options;
	    }
    }
}