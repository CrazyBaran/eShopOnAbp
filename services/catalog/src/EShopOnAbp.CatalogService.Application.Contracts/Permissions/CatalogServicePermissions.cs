namespace EShopOnAbp.CatalogService.Permissions
{
    public static class CatalogServicePermissions
    {
        public const string GroupName = "CatalogService";

        public static class CatalogItems
        {
            public const string Default = GroupName + ".CatalogItems";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }
        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";
    }
}