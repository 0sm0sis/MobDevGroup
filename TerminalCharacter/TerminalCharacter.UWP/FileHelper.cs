﻿using System.IO;
using Xamarin.Forms;
using TerminalCharacter.UWP;
using Windows.Storage;

[assembly: Dependency(typeof(FileHelper))]
namespace TerminalCharacter.UWP
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }
    }
}
