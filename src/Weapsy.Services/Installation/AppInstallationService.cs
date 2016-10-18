﻿using FluentValidation;
using System;
using Weapsy.Domain.Apps;
using Weapsy.Domain.ModuleTypes;
using Weapsy.Domain.ModuleTypes.Commands;
using Weapsy.Domain.Apps.Commands;

namespace Weapsy.Services.Installation
{
    public class AppInstallationService : IAppInstallationService
    {
        private readonly IAppRepository _appRepository;
        private readonly IValidator<CreateApp> _createAppValidator;
        private readonly IModuleTypeRepository _moduleTypeRepository;
        private readonly IValidator<CreateModuleType> _createModuleTypeValidator;

        public AppInstallationService(IAppRepository appRepository,
            IValidator<CreateApp> createAppValidator,
            IModuleTypeRepository moduleTypeRepository,
            IValidator<CreateModuleType> createModuleTypeValidator)
        {
            _appRepository = appRepository;
            _createAppValidator = createAppValidator;
            _moduleTypeRepository = moduleTypeRepository;
            _createModuleTypeValidator = createModuleTypeValidator;
        }

        public void InstallDefaultApps()
        {
            // temporary implementation, it will be based on configuration files
            // and possibly moved to an infrastructure service

            if (_appRepository.GetByName("Text") != null)
                return;

            // ===== Text ===== //

            var textAppId = Guid.NewGuid();

            // App

            var textApp = App.CreateNew(new CreateApp
            {
                Id = textAppId,
                Name = "Text",
                Description = "Text",
                Folder = "Text"
            }, _createAppValidator);

            _appRepository.Create(textApp);

            // Module Type

            var textModuleType = ModuleType.CreateNew(new CreateModuleType
            {
                AppId = textAppId,
                Id = Guid.NewGuid(),
                Name = "Text",
                Title = "Text Module",
                Description = "Text Module",
                ViewType = ViewType.ViewComponent,
                ViewName = "TextModule",
                EditType = EditType.Modal,
                EditUrl = "Text/Home/Index"
            }, _createModuleTypeValidator);

            _moduleTypeRepository.Create(textModuleType);
        }
    }
}
