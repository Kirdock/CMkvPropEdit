using CMkvPropEdit.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMkvPropEdit.Helper
{
    static class SaveService
    {
        private static readonly string Extension = ".bin";
        internal static bool SavePreset(Preset preset, string fileName)
        {
            bool saved = false;
            try
            {
                string path = Path.Combine(Properties.Settings.Default.PresetPath, fileName + Extension);
                using (Stream stream = File.Open(path, FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, preset);
                    saved = true;
                }
            }
            catch (Exception ex)
            {
                MessageService.ShowError($"Error while saving preset \"{fileName}\"\n" + ex.Message);
            }
            return saved;
        }

        internal static bool RenamePreset(string oldFileName, string newFileName)
        {
            string oldPath = GetPresetPath(oldFileName);
            string newPath = GetPresetPath(newFileName);
            bool renamed = false;
            if (File.Exists(oldPath))
            {
                bool overrideFile = true;
                if (File.Exists(newPath))
                {
                    DialogResult result = MessageService.ShowQuestion("A preset with this file name already exists. Do you want to overwride it?");
                    overrideFile = result == DialogResult.Yes;
                }
                if (overrideFile)
                {
                    try
                    {
                        File.Move(oldPath, newPath);
                        renamed = true;
                    }
                    catch(Exception ex)
                    {
                        MessageService.ShowError($"Error while renaming preset \"{oldFileName}\"\n" + ex.Message);
                    }
                }
            }
            else
            {
                MessageService.ShowWarning("Preset does not exist anymore");
            }
            return renamed;
        }

        internal static bool DeletePreset(string fileName)
        {
            string path = GetPresetPath(fileName);
            bool deleted = false;
            if (File.Exists(path))
            {
                try
                {
                    File.Delete(path);
                    deleted = true;
                }
                catch(Exception ex)
                {
                    MessageService.ShowError($"Error while deleting preset \"{fileName}\"\n" + ex.Message);
                }
            }
            else
            {
                MessageService.ShowWarning("Preset does not exist anymore");
            }
            return deleted;
        }

        internal static Preset LoadPreset(string fileName)
        {
            string path = GetPresetPath(fileName);
            Preset result = null;
            try
            {
                using (Stream stream = File.Open(path, FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    if (bin.Deserialize(stream) is Preset preset)
                    {
                        result = preset;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageService.ShowError($"Error while loading preset \"{fileName}\"\n" + ex.Message);
            }
            return result;
        }

        private static string GetPresetPath(string fileName)
        {
            return Path.Combine(Properties.Settings.Default.PresetPath, fileName + Extension);
        }

        internal static IEnumerable<string> GetPresetNames()
        {
            return Directory.GetFiles(Properties.Settings.Default.PresetPath).Select(fullPath => Path.GetFileNameWithoutExtension(fullPath));
        }
    }
}
