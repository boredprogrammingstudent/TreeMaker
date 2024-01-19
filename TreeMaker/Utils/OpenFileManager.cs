using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreeMaker.Scenes;
using TreeMaker.UI;
using TreeMaker.UI.Popups;
using static TreeMaker.Settings.UserSettings;
namespace TreeMaker.Utils
{
    static class OpenFileManager
    {
        
        public static string Open(string path, FileType fileType)
        {

            if (Directory.Exists(path))
            {
                try
                {
                    OpenFileDialog dialog = fileType switch
                    {
                        FileType.Tree => new()
                        {
                            RestoreDirectory = true,
                            InitialDirectory = path,
                            Title = "Choose a file",
                            Filter = "Tree files (*.tree)|*.tree"
                        },
                        FileType.Image => new()
                        {
                            RestoreDirectory = true,
                            InitialDirectory = path,
                            Title = "Choose an image",
                            Filter = "png files (*.png)|*.png"
                        },
                        _ => throw new Exception()
                    };
                        

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        string selectedFileName = dialog.FileName;
                        return selectedFileName;
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    return string.Empty;
                }
            }
            else
            {
                return string.Empty;
            }
        }
    }
    enum FileType
    {
        Tree,
        Image
    }
}
