using System;
using System.IO;

namespace SharedProjectLab03
{
    public class MySharedCode
    {
        public string GetFilePath(string fileName)
        {
            string FilePath = "";
#if WINDOWS_UWP
            FilePath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path,filename);
#else
#if __ANDROID__
            string LibraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            FilePath = Path.Combine(LibraryPath, fileName);
#endif
#endif

            return FilePath;
        }
    }
}