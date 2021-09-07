using ClashBusiness.Exceptions;
using ClashData;
using ClashData.FileSystem;
using ClashData.SQLite;
using ClashEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.IO.Packaging;
using System.Linq;
using System.Net.Mime;

namespace ClashBusiness
{
    public class ApplicationManagement : IApplicationManagement
    {
        private readonly ISQLiteManagement _sQLiteManagement;
        private readonly IApplicationSettingDal _applicationSettingDal;
        private readonly IFileSystemDal _fileSystemDal;
        private const string ClashTemporaryFolder = "ClashTemporaryFolder";

        public ApplicationManagement(IFileSystemDal fileSystemDal, ISQLiteManagement sQLiteManagement, IApplicationSettingDal applicationSettingDal)
        {
            _sQLiteManagement = sQLiteManagement;
            _applicationSettingDal = applicationSettingDal;
            _fileSystemDal = fileSystemDal;
        }

        public bool ExecuteScript(string filename)
        {
            var script = _fileSystemDal.ReadTextFile(filename);
            return _sQLiteManagement.ExecuteNonQueryScript(script) > 1;
        }

        public List<ApplicationSetting> GetApplicationSettings()
        {
            return _applicationSettingDal.GetAll().ToList();
        }

        public string GetApplicationSetting(string key)
        {
            var setting = _applicationSettingDal.Get(key);
            if(setting == null)
            {
                throw new UnkownapplicationSettingException();
            }
            return setting.SettingValue;
        }

        public bool ExportData<T>(List<T> entities, string exportPath) where T : IDatabaseEntity
        {
            try
            {
                string temporaryExportFolder = CreateExportFolder(exportPath);
                
                SerializeObjects(entities, temporaryExportFolder);

                var zipName = $"ClashExport_{typeof(T).Name}_{DateTime.Now.ToString("yyyyMMddhhmmss")}.zip";
                _fileSystemDal.CreateFromDirectory(temporaryExportFolder, Path.Combine(exportPath, zipName));
                
                DeleteTemporaryFolder(temporaryExportFolder);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<T> ImportData<T>(string zipFile)
        {
            var filename = Path.GetFileNameWithoutExtension(zipFile);

            var assemblyName = "ClashEntities";
            var exportTypeClassName = $"{assemblyName}.{filename.Split('_')[1]}, {assemblyName}";
            var exportType = Type.GetType(exportTypeClassName);

            if(exportType != typeof(T))
            {
                throw new DifferentTypeImportException();
            }

            var importFolder = CreateImportFolder(zipFile);
            _fileSystemDal.ExtractToDirectory(zipFile, importFolder);

            var files = _fileSystemDal.GetFiles(importFolder);

            var extractedItems = new List<T>();
            foreach(var file in files)
            {
                var json = _fileSystemDal.ReadTextFile(file);
                var entity = JsonConvert.DeserializeObject<T>(json);
                extractedItems.Add(entity);
            }

            DeleteTemporaryFolder(importFolder);

            return extractedItems;
        }

        private void SerializeObjects<T>(List<T> entities, string exportFolder) where T : IDatabaseEntity
        {
            foreach (var entity in entities)
            {
                var json = JsonConvert.SerializeObject(entity);

                var filename = Path.Combine(exportFolder, $"{typeof(T).Name}_{entity.Id}.json");
                _fileSystemDal.WriteTextFile(filename, json);
            }
        }

        private string CreateImportFolder(string zipFile)
        {
            var importFolder = Path.GetDirectoryName(zipFile);
            importFolder = Path.Combine(importFolder, ClashTemporaryFolder);

            CreateOrCleanFolder(importFolder);

            return importFolder;
        }

        private string CreateExportFolder(string initialExportPath)
        {
            var exportFolder = Path.Combine(initialExportPath, ClashTemporaryFolder);

            CreateOrCleanFolder(exportFolder);

            return exportFolder;
        }

        private void CreateOrCleanFolder(string folderPath)
        {
            _fileSystemDal.CreateFolder(folderPath);
            _fileSystemDal.CleanFolder(folderPath);
        }

        private string DeleteTemporaryFolder(string temporaryFolder)
        {
            _fileSystemDal.CleanFolder(temporaryFolder);
            _fileSystemDal.DeleteFolder(temporaryFolder);

            return temporaryFolder;
        }
    }
}
