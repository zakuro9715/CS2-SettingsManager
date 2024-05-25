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
using Colossal.Localization;

namespace SettingsManager
{
    public partial class GameSettingsLocaleSource : IDictionarySource
    {
        private readonly Setting _setting;
        private readonly LocalizationManager _localizationManager;
        private readonly string _locale;
        public GameSettingsLocaleSource(Setting setting, LocalizationManager localizationManager, string locale)
        {
            _setting = setting;
            _localizationManager = localizationManager;
            _locale = locale;
        }

        private string GetLabelValue(string name)
        {
            var id = name switch
            {
                "UserInterface" => "Interface",
                _ => name,
            };
            if (_localizationManager.activeDictionary.TryGetValue($"Options.SECTION[{id}]", out var value))
            {
                return value;
            }
            else
            {
                return name;
            }
        }

        private string GetDescValue(string name)
        {
            var id = _setting.GetOptionDescLocaleID("Include{name}Settings");
            var nameValue = GetLabelValue(name);
            if (_localizationManager.activeDictionary.TryGetValue(id, out var value))
            {
                return value.Replace("{name}", nameValue);
            }
            else
            {
                return nameValue;
            }
        }

        public void Unload()
        {

        }
    }
}
