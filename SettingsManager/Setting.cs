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
using Colossal.IO.AssetDatabase;
using Colossal.Json;
using Game.Modding;
using Game.Settings;
using Game.UI.Widgets;
using System.Collections.Generic;
using System.Linq;

namespace SettingsManager
{
    [FileLocation(nameof(SettingsManager))]
    [SettingsUIGroupOrder(ProfileGroup, GameSettingsGroup)]
    [SettingsUIShowGroupName(GameSettingsGroup)]
    public partial class Setting : ModSetting
    {
        public const string MainTab = "Main";
        public const string ProfileGroup = "Profile";
        public const string ProfileCreateDeleteButtons = "ProfileCreateDeleteButtons";
        public const string ProfileSaveLoadButtons = "ProfileSaveLoadButtons";
        public const string ProfileSelectSettingsGroup = "Settings";


        public Setting(IMod mod) : base(mod)
        {
            SetDefaults();
        }

        public override void SetDefaults()
        {
        }

        [SettingsUISection(MainTab, ProfileGroup)]
        [SettingsUIDropdown(typeof(Setting), nameof(GetProfileDropdownItems))]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetProfileDropdownItemsVersion))]
        public string ProfileSelect { get; set; } = SettingsProfile.DefaultID;

        public SettingsProfile Profile => Profiles.Find((p) => p.ID == ProfileSelect);

        int profileDropdownItemsVersion;
        public int GetProfileDropdownItemsVersion => profileDropdownItemsVersion;
        private void OnProfilesChanged()
        {
            profileDropdownItemsVersion++;
            ApplyAndSave();
        }
        private DropdownItem<string>[] GetProfileDropdownItems() => (
            from p in Profiles
            orderby p.Index
            select new DropdownItem<string>() { value = p.ID, displayName = p.Name }
        ).ToArray();

        [Include]
        public List<SettingsProfile> Profiles { get; private set; } = new List<SettingsProfile>() { SettingsProfile.CreateDefault() };

        [SettingsUISection(MainTab, ProfileGroup)]
        [SettingsUITextInput]
        public string ProfileName
        {
            get => Profile.Name;
            set
            {
                Profile.Name = value;
                OnProfilesChanged();
            }
        }

        [SettingsUISection(MainTab, ProfileGroup)]
        [SettingsUIButtonGroup(ProfileCreateDeleteButtons)]
        public bool Create
        {
            set
            {
                var p = SettingsProfile.Create($"Profile{Profiles.Count + 1}", Profiles.Count);
                Profiles.Add(p);
                ProfileSelect = p.ID;
                OnProfilesChanged();
            }
        }

        private bool DisableDeleteProfile() => !(Profiles.Count > 1);
        [SettingsUISection(MainTab, ProfileGroup)]
        [SettingsUIButtonGroup(ProfileCreateDeleteButtons)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(DisableDeleteProfile))]
        [SettingsUIConfirmation]
        public bool Delete
        {
            set
            {
                var p = Profile;
                Profiles.Remove(p);
                ProfileSelect = Profiles.Last().ID;
                OnProfilesChanged();
            }
        }

        [SettingsUISection(MainTab, ProfileGroup)]
        [SettingsUIButtonGroup(ProfileSaveLoadButtons)]
        public bool Save { set { Profile.Save(); this.ApplyAndSave(); } }

        [SettingsUISection(MainTab, ProfileGroup)]
        [SettingsUIButtonGroup(ProfileSaveLoadButtons)]
        public bool Load { set { Profile.Load(); } }
    }

}
