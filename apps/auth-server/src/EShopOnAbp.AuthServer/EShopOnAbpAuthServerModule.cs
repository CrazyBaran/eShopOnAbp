﻿using EShopOnAbp.AdministrationService.EntityFrameworkCore;
using EShopOnAbp.IdentityService.EntityFrameworkCore;
using EShopOnAbp.SaasService.EntityFrameworkCore;
using EShopOnAbp.Shared.Hosting.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;
using System;
using System.IO;
using System.Linq;
using Volo.Abp;
using Volo.Abp.Account;
using Volo.Abp.Account.Web;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.Auditing;
using Volo.Abp.BackgroundJobs.RabbitMQ;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.Emailing;
using Volo.Abp.EventBus.RabbitMq;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.UI.Navigation.Urls;
using Volo.Abp.VirtualFileSystem;

namespace EShopOnAbp.AuthServer
{
    [DependsOn(
        typeof(AbpCachingStackExchangeRedisModule),
        typeof(AbpEventBusRabbitMqModule),
        typeof(AbpBackgroundJobsRabbitMqModule),
        typeof(AbpAspNetCoreMvcUiBasicThemeModule),
        typeof(AbpAccountWebIdentityServerModule),
        typeof(AbpAccountApplicationModule),
        typeof(EShopOnAbpSharedHostingAspNetCoreModule),
        typeof(EShopOnAbpSharedLocalizationModule),
        typeof(AdministrationServiceEntityFrameworkCoreModule),
        typeof(IdentityServiceEntityFrameworkCoreModule),
        typeof(SaasServiceEntityFrameworkCoreModule)
    )]
    public class EShopOnAbpAuthServerModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();

            Configure<AbpMultiTenancyOptions>(options =>
            {
                options.IsEnabled = true;
            });

            Configure<AbpAuditingOptions>(options =>
            {
                options.ApplicationName = "AuthServer";
            });

            Configure<AppUrlOptions>(options =>
            {
                options.Applications["MVC"].RootUrl = configuration["App:SelfUrl"];
                options.RedirectAllowedUrls.AddRange(configuration["App:RedirectAllowedUrls"].Split(','));
            });

            Configure<AbpDistributedCacheOptions>(options =>
            {
                options.KeyPrefix = "EShopOnAbp:";
            });

            var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);
            context.Services
                .AddDataProtection()
                .PersistKeysToStackExchangeRedis(redis, "EShopOnAbp-Protection-Keys");

            context.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder
                        .WithOrigins(
                            configuration["App:CorsOrigins"]
                                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                .Select(o => o.Trim().RemovePostFix("/"))
                                .ToArray()
                        )
                        .WithAbpExposedHeaders()
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });

#if DEBUG
            context.Services.Replace(ServiceDescriptor.Singleton<IEmailSender, NullEmailSender>());
#endif

            if (hostingEnvironment.IsDevelopment())
            {
                Configure<AbpVirtualFileSystemOptions>(options =>
                {
                    options.FileSets.ReplaceEmbeddedByPhysical<EShopOnAbpSharedLocalizationModule>(Path.Combine(hostingEnvironment.ContentRootPath,
                        $"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}shared{Path.DirectorySeparatorChar}EShopOnAbp.Shared.Localization"));
                });
            }
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAbpRequestLocalization();

            if (!env.IsDevelopment())
            {
                app.UseErrorPage();
            }

            app.UseCorrelationId();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors();
            // app.UseHttpMetrics();
            app.UseAuthentication();
            app.UseMultiTenancy();
            app.UseAbpSerilogEnrichers();
            app.UseUnitOfWork();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseAuditing();
            app.UseConfiguredEndpoints(endpoints =>
            {
                // endpoints.MapMetrics();
            });
        }
    }
}