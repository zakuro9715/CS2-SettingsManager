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

using Colossal;
using Colossal.Json;
using Colossal.Localization;
using Game.Settings;
using System.Collections.Generic;
namespace SettingsManager
{
	public partial class Setting
	{
        public const string GameSettingsGroup = "Game Settings";
		
        [SettingsUISection(MainTab, ProfileSelectSettingsGroup)]
		[Exclude]
        public bool AllGameSettings
        {
            get => GameSettingsGeneral && GameSettingsAudio && GameSettingsGameplay && GameSettingsGraphics && GameSettingsUserInterface && GameSettingsInput;
            set
            {
                GameSettingsGeneral = value;
                GameSettingsAudio = value;
                GameSettingsGameplay = value;
                GameSettingsGraphics = value;
                GameSettingsUserInterface = value;
                GameSettingsInput = value;
            }
        }
        [SettingsUISection(MainTab, ProfileSelectSettingsGroup)]
		[Exclude]
		public bool GameSettingsGeneral
        {
            get => Profile.General;
            set => Profile.General = value;
	    }

        [SettingsUISection(MainTab, ProfileSelectSettingsGroup)]
		[Exclude]
		public bool GameSettingsAudio
        {
            get => Profile.Audio;
            set => Profile.Audio = value;
	    }

        [SettingsUISection(MainTab, ProfileSelectSettingsGroup)]
		[Exclude]
		public bool GameSettingsGameplay
        {
            get => Profile.Gameplay;
            set => Profile.Gameplay = value;
	    }

        [SettingsUISection(MainTab, ProfileSelectSettingsGroup)]
		[Exclude]
		public bool GameSettingsGraphics
        {
            get => Profile.Graphics;
            set => Profile.Graphics = value;
	    }

        [SettingsUISection(MainTab, ProfileSelectSettingsGroup)]
		[Exclude]
		public bool GameSettingsUserInterface
        {
            get => Profile.UserInterface;
            set => Profile.UserInterface = value;
	    }

        [SettingsUISection(MainTab, ProfileSelectSettingsGroup)]
		[Exclude]
		public bool GameSettingsInput
        {
            get => Profile.Input;
            set => Profile.Keybinding = Profile.Input = value;
	    }

		private void SetGameSettingsDefaults() {
			GameSettingsGeneral = true;
			GameSettingsAudio = true;
			GameSettingsGameplay = true;
			GameSettingsGraphics = true;
			GameSettingsUserInterface = true;
			GameSettingsInput = true;
		}
	}

	
    public class GameSettingsLocaleSource: IDictionarySource
    {
        private readonly Setting _setting;
        private readonly LocalizationManager _localizationManager;
        public GameSettingsLocaleSource(Setting setting, LocalizationManager localizationManager)
        {
            _setting = setting;
            _localizationManager = localizationManager;
        }

        private string GetLabelValue(string name)
        {
            var id = name switch
            {
                "UserInterface" => "Interface",
                _ => name,
            };
            if(_localizationManager.activeDictionary.TryGetValue($"Options.SECTION[{id}]", out var value)) {
                return value;
            } else {
                return name;
            }
        }
        
        private string GetDescValue(string name)
        {
            var id = _setting.GetOptionDescLocaleID("Include{name}Settings");
            var nameValue = GetLabelValue(name);
            if(_localizationManager.activeDictionary.TryGetValue(id, out var value)) {
                return value.Replace("{name}", nameValue);
            } else {
                return nameValue;
            }
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts) =>
            new Dictionary<string, string>
            {
                { _setting.GetOptionLabelLocaleID(nameof(Setting.GameSettingsGeneral)), GetLabelValue("General") },
                { _setting.GetOptionDescLocaleID(nameof(Setting.GameSettingsGeneral)), GetDescValue("General") },
                { _setting.GetOptionLabelLocaleID(nameof(Setting.GameSettingsAudio)), GetLabelValue("Audio") },
                { _setting.GetOptionDescLocaleID(nameof(Setting.GameSettingsAudio)), GetDescValue("Audio") },
                { _setting.GetOptionLabelLocaleID(nameof(Setting.GameSettingsGameplay)), GetLabelValue("Gameplay") },
                { _setting.GetOptionDescLocaleID(nameof(Setting.GameSettingsGameplay)), GetDescValue("Gameplay") },
                { _setting.GetOptionLabelLocaleID(nameof(Setting.GameSettingsGraphics)), GetLabelValue("Graphics") },
                { _setting.GetOptionDescLocaleID(nameof(Setting.GameSettingsGraphics)), GetDescValue("Graphics") },
                { _setting.GetOptionLabelLocaleID(nameof(Setting.GameSettingsUserInterface)), GetLabelValue("UserInterface") },
                { _setting.GetOptionDescLocaleID(nameof(Setting.GameSettingsUserInterface)), GetDescValue("UserInterface") },
                { _setting.GetOptionLabelLocaleID(nameof(Setting.GameSettingsInput)), GetLabelValue("Input") },
                { _setting.GetOptionDescLocaleID(nameof(Setting.GameSettingsInput)), GetDescValue("Input") },
            };

        public void Unload()
        {

        }
    }
}