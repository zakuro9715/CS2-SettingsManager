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
}