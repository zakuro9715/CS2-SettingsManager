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
using System.Collections.Generic;

namespace SettingsManager
{
    public partial class GameSettingsLocaleSource: IDictionarySource
    {

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
    }    
}