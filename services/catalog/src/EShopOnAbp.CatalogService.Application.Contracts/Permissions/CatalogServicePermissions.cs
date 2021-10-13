namespace EShopOnAbp.CatalogService.Permissions
{
    public static class CatalogServicePermissions
    {
        public const string GroupName = "CatalogService";

        public static class Catalogs
        {
            public const string Default = GroupName + ".Catalogs";
        }
        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";
    }
}