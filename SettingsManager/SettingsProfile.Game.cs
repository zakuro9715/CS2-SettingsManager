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
using Colossal.Json;
using Game.Input;
using Game.Settings;
using System;
using System.IO;

namespace SettingsManager
{
	public partial class SettingsProfile
	{
		public bool General { get; set; } = true;

		public bool Audio { get; set; } = true;

		public bool Gameplay { get; set; } = true;

		public bool Graphics { get; set; } = true;

		public bool UserInterface { get; set; } = true;

		public bool Input { get; set; } = true;

		public bool Keybinding { get; set; } = true;


		private void SaveGameSettings()
		{
			if (General)
			{
				SaveText("GeneralSettings.json", JSON.Dump(SharedSettings.instance.general));
			}
			if (Audio)
			{
				SaveText("AudioSettings.json", JSON.Dump(SharedSettings.instance.audio));
			}
			if (Gameplay)
			{
				SaveText("GameplaySettings.json", JSON.Dump(SharedSettings.instance.gameplay));
			}
			if (Graphics)
			{
				SaveText("GraphicsSettings.json", JSON.Dump(SharedSettings.instance.graphics));
			}
			if (UserInterface)
			{
				SaveText("InterfaceSettings.json", JSON.Dump(SharedSettings.instance.userInterface));
			}
			if (Input)
			{
				SaveText("InputSettings.json", JSON.Dump(SharedSettings.instance.input));
			}
			if (Keybinding)
			{
				SaveText("KeybindingSettings.json", JSON.Dump(SharedSettings.instance.keybinding));
			}
		}

		private void LoadGameSettings()
		{

			if (General)
			{
				if (TryReadText("GeneralSettings.json", out var text))
				{
					var data = JSON.Load(text);
					SharedSettings.instance.general.SetDefaults();
					JSON.WriteInto(data, SharedSettings.instance.general);
					SharedSettings.instance.general.ApplyAndSave();
				}
			}

			if (Audio)
			{
				if (TryReadText("AudioSettings.json", out var text))
				{
					var data = JSON.Load(text);
					SharedSettings.instance.audio.SetDefaults();
					JSON.WriteInto(data, SharedSettings.instance.audio);
					SharedSettings.instance.audio.ApplyAndSave();
				}
			}

			if (Gameplay)
			{
				if (TryReadText("GameplaySettings.json", out var text))
				{
					var data = JSON.Load(text);
					SharedSettings.instance.gameplay.SetDefaults();
					JSON.WriteInto(data, SharedSettings.instance.gameplay);
					SharedSettings.instance.gameplay.ApplyAndSave();
				}
			}

			if (Graphics)
			{
				if (TryReadText("GraphicsSettings.json", out var text))
				{
					var data = JSON.Load(text);
					SharedSettings.instance.graphics.SetDefaults();
					JSON.WriteInto(data, SharedSettings.instance.graphics);
					SharedSettings.instance.graphics.ApplyAndSave();
				}
			}

			if (UserInterface)
			{
				if (TryReadText("InterfaceSettings.json", out var text))
				{
					var data = JSON.Load(text);
					SharedSettings.instance.userInterface.SetDefaults();
					JSON.WriteInto(data, SharedSettings.instance.userInterface);
					SharedSettings.instance.userInterface.ApplyAndSave();
				}
			}

			if (Input)
			{
				if (TryReadText("InputSettings.json", out var text))
				{
					var data = JSON.Load(text);
					SharedSettings.instance.input.SetDefaults();
					JSON.WriteInto(data, SharedSettings.instance.input);
					SharedSettings.instance.input.ApplyAndSave();
				}
			}

			if (Keybinding)
			{
				if (TryReadText("KeybindingSettings.json", out var text))
				{
					var data = JSON.Load(text);
					var inputBindngVersion = InputSettings.GetInputBindingVersion();
					InputManager.instance.ResetAllBindings();
					JSON.WriteInto(data, SharedSettings.instance.keybinding);
					InputManager.instance.EventActionsChanged();
					SharedSettings.instance.keybinding.ApplyAndSave();
				}
			}

		}
	}
}