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
using Colossal.Logging;
using Game;
using Game.Modding;
using Game.SceneFlow;
using LibShared.Localization;
using Unity.Mathematics;

namespace SettingsManager
{
    public class Mod : IMod
    {
        public static ILog log = LogManager.GetLogger($"{nameof(SettingsManager)}.{nameof(Mod)}").SetShowsErrorsInUI(false);
        public static Setting Setting;
        internal static Random Random = new();

        public void OnLoad(UpdateSystem updateSystem)
        {
            log.Info(nameof(OnLoad));

            if (GameManager.instance.modManager.TryGetExecutableAsset(this, out var asset))
                log.Info($"Current mod asset at {asset.path}");

            Setting = new Setting(this);
            Setting.RegisterInOptionsUI();
            var localizationManager = GameManager.instance.localizationManager;
            foreach ( var locale in localizationManager.GetSupportedLocales())
            {
                localizationManager.AddSource(locale, new GameSettingsLocaleSource(Setting, localizationManager, locale));
            }
            LocaleLoader.Load(log, localizationManager);

            AssetDatabase.global.LoadSettings(nameof(SettingsManager), Setting, new Setting(this));
        }

        public void OnDispose()
        {
            log.Info(nameof(OnDispose));
            if (Setting != null)
            {
                Setting.UnregisterInOptionsUI();
                Setting = null;
            }
        }
    }
}
