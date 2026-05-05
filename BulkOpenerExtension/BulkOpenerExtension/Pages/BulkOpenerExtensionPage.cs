// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using BulkOpenerExtension.Pages;
using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace BulkOpenerExtension;

internal sealed partial class BulkOpenerExtensionPage : ListPage
{
    public BulkOpenerExtensionPage()
    {
        Icon = IconHelpers.FromRelativePath("Assets\\opener-icon.png");
        Title = "Opener";
        Name = "Open";
    }

    public override IListItem[] GetItems()
    {
        return [
            new ListItem(new OpenerCommand()) { Title = "Bulk Open" },
        ];
    }
}