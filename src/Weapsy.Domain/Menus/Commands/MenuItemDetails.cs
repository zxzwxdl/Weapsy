﻿using System;
using System.Collections.Generic;

namespace Weapsy.Domain.Menus.Commands
{
    public class MenuItemDetails : BaseSiteCommand
    {
        public Guid MenuId { get; set; }
        public Guid MenuItemId { get; set; }
        public MenuItemType MenuItemType { get; set; }
        public Guid PageId { get; set; }
        public string Link { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
        public IList<MenuItemLocalisation> MenuItemLocalisations { get; set; } = new List<MenuItemLocalisation>();
        public List<MenuItemPermission> MenuItemPermissions { get; set; } = new List<MenuItemPermission>();
    }
}