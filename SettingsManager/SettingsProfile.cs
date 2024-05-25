/* Copyright 2024 zakuro <z@kuro.red> (https://x.com/zakuro9715)
 * 
 * This file is part of SettingsManager.
 * 
 * SettingsManager is free software: you can redistribute it and/or modify it under the
 * terms of the GNU General Public License as published by the Free Software Foundation, either
 * version 3 of the License, or (at your option) any later version.
 * 
 * SettingsManager is distributed in the hope that it will be useful, but WITHOUT ANY
 * WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR
 * PURPOSE. See the GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License along with
 * SettingsManager. If not, see <https://www.gnu.org/licenses/>.
 */
using System;
using System.IO;
using Colossal.IO;
using Colossal.PSI.Environment;
using Colossal.Json;

namespace SettingsManager
{
    public partial class SettingsProfile
    {
        public const string DefaultID = "04514e78-da6b-44d9-98a8-085a24add044";
        public Guid ID { get; }
        public string Name { get; set; }
        public int Index { get; set; }


        public static string ProfilesDirecotry = Path.Combine(EnvPath.kUserDataPath, "SettingsManager", "Profiles");

        public string GetDataDirectory() => Path.Combine(ProfilesDirecotry, ID.ToString());
        public string GetFilePath(string filename) => Path.Combine(GetDataDirectory(), filename);

        public static SettingsProfile Create(string name, int index) => new(Guid.NewGuid(), index, name);
        public static SettingsProfile CreateDefault() => new();
        public SettingsProfile() : this(DefaultID, 0, "Profile1") { }

        public SettingsProfile(Guid id, int index, string name)
        {
            ID = id;
            Index = index;
            Name = name;
        }

        public SettingsProfile(string id, int index, string name) : this(Guid.Parse(id), index, name) { }

        private bool EnsureDataDirectory() => IOUtils.EnsureDirectory(GetDataDirectory());

        public void Clean()
        {
            var dir = new DirectoryInfo(GetDataDirectory());
            if (dir.Exists)
            {
                dir.Delete(true);
            }
        }

        private void SaveText(string filename, string text)
        {
            try
            {
                File.WriteAllText(GetFilePath(filename), text);
            }
            catch (Exception e)
            {
                Mod.log.Error(e, $"Failed to write {filename}");
                throw;
            }
        }

        private bool TryReadText(string filename, out string text) {
            var path = GetFilePath(filename);
            if (File.Exists(path)) {
                text = File.ReadAllText(path);
                return true;
            }
            Mod.log.Warn($"Tried to read {filename}, but it does not exist.");
            text = "";
            return false;
        }

        private void SaveProfileData()
        {
            SaveText("Profile.json", JSON.Dump(this));
        }

        public void Save()
        {
            Clean();
            EnsureDataDirectory();
            SaveProfileData();
            SaveGameSettings();
        }

        public void Load()
        {
            LoadGameSettings();
        }
    }
}
