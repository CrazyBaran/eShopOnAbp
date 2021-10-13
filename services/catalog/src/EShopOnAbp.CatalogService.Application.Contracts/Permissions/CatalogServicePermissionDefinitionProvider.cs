﻿using EShopOnAbp.CatalogService.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace EShopOnAbp.CatalogService.Permissions
{
    public class CatalogServicePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(CatalogServicePermissions.GroupName);

            var catalogsPermission =
                myGroup.AddPermission(CatalogServicePermissions.CatalogItems.Default, L("Permission:CatalogItems"));
            catalogsPermission.AddChild(CatalogServicePermissions.CatalogItems.Create,
                L("Permission:CatalogItems.Create"));
            catalogsPermission.AddChild(CatalogServicePermissions.CatalogItems.Edit,
                L("Permission:CatalogItems.Edit"));
            catalogsPermission.AddChild(CatalogServicePermissions.CatalogItems.Delete,
                L("Permission:CatalogItems.Delete"));
            //Define your own permissions here. Example:
            //myGroup.AddPermission(CatalogServicePermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CatalogServiceResource>(name);
        }
    }
}
