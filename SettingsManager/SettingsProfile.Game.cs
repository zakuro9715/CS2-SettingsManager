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
				try
				{
					var data = JSON.Load(File.ReadAllText(Path.Combine(GetDataDirectory(), "GeneralSettings.json")));
					SharedSettings.instance.general.SetDefaults();
					JSON.WriteInto(data, SharedSettings.instance.general);
					SharedSettings.instance.general.ApplyAndSave();
				}
				catch(Exception e)
				{
					Mod.log.Error(e, "Failed to read GeneralSettings.json");
					throw;
				}
			}

			if (Audio)
			{
				try
				{
					var data = JSON.Load(File.ReadAllText(Path.Combine(GetDataDirectory(), "AudioSettings.json")));
					SharedSettings.instance.audio.SetDefaults();
					JSON.WriteInto(data, SharedSettings.instance.audio);
					SharedSettings.instance.audio.ApplyAndSave();
				}
				catch(Exception e)
				{
					Mod.log.Error(e, "Failed to read AudioSettings.json");
					throw;
				}
			}

			if (Gameplay)
			{
				try
				{
					var data = JSON.Load(File.ReadAllText(Path.Combine(GetDataDirectory(), "GameplaySettings.json")));
					SharedSettings.instance.gameplay.SetDefaults();
					JSON.WriteInto(data, SharedSettings.instance.gameplay);
					SharedSettings.instance.gameplay.ApplyAndSave();
				}
				catch(Exception e)
				{
					Mod.log.Error(e, "Failed to read GameplaySettings.json");
					throw;
				}
			}

			if (Graphics)
			{
				try
				{
					var data = JSON.Load(File.ReadAllText(Path.Combine(GetDataDirectory(), "GraphicsSettings.json")));
					SharedSettings.instance.graphics.SetDefaults();
					JSON.WriteInto(data, SharedSettings.instance.graphics);
					SharedSettings.instance.graphics.ApplyAndSave();
				}
				catch(Exception e)
				{
					Mod.log.Error(e, "Failed to read GraphicsSettings.json");
					throw;
				}
			}

			if (UserInterface)
			{
				try
				{
					var data = JSON.Load(File.ReadAllText(Path.Combine(GetDataDirectory(), "InterfaceSettings.json")));
					SharedSettings.instance.userInterface.SetDefaults();
					JSON.WriteInto(data, SharedSettings.instance.userInterface);
					SharedSettings.instance.userInterface.ApplyAndSave();
				}
				catch(Exception e)
				{
					Mod.log.Error(e, "Failed to read InterfaceSettings.json");
					throw;
				}
			}

			if (Input)
			{
				try
				{
					var data = JSON.Load(File.ReadAllText(Path.Combine(GetDataDirectory(), "InputSettings.json")));
					SharedSettings.instance.input.SetDefaults();
					JSON.WriteInto(data, SharedSettings.instance.input);
					SharedSettings.instance.input.ApplyAndSave();
				}
				catch(Exception e)
				{
					Mod.log.Error(e, "Failed to read InputSettings.json");
					throw;
				}
			}

			if (Keybinding)
			{
				try
				{
					var data = JSON.Load(File.ReadAllText(Path.Combine(GetDataDirectory(), "KeybindingSettings.json")));
					var inputBindngVersion = InputSettings.GetInputBindingVersion();
					InputManager.instance.ResetAllBindings();
					JSON.WriteInto(data, SharedSettings.instance.keybinding);
					InputManager.instance.EventActionsChanged();
					SharedSettings.instance.keybinding.ApplyAndSave();
				}
				catch(Exception e)
				{
					Mod.log.Error(e, "Failed to read KeybindingSettings.json");
					throw;
				}
			}

		}
	}
}