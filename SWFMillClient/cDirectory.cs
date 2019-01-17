using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SWFMillUtility
{
    class cDirectory
    {
        //private static List<string> lstSWFFiles=new List<string>();
        private static List<ConversionFileHelper> lstSWFFiles = new List<ConversionFileHelper>();
        

        public static bool isDirectoryPathValid(string dirPath, string searchFileEXT)
        {
            try{
                string ConvertedEXT="";
                switch(searchFileEXT)
                {
                    case ".SWF":
                        ConvertedEXT = ".XML";
                        break;
                    case ".XML":
                        ConvertedEXT = ".SWF";
                        break;
                }
                DirectoryInfo di = new DirectoryInfo(dirPath);
                if(di.Exists)
                {
                    FileInfo[] fia=di.GetFiles("*" + searchFileEXT,SearchOption.AllDirectories);
                    lstSWFFiles.Clear();
                    foreach (FileInfo info in fia)
                    {
                        string DestFileName = info.FullName.Replace(info.Extension, ConvertedEXT);

                        lstSWFFiles.Add(new ConversionFileHelper(info.FullName, DestFileName));
                    }

                    return true;
                }
                else
                {
                    lstSWFFiles.Clear();
                    return false;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public static List<ConversionFileHelper> getAllValidFilesInsideDirectory()
        {
            return lstSWFFiles;
        }
    }

    class ConversionFileHelper
    {
        public string srcFile;
        public string destFile;
        public ConversionFileHelper(string _srcFile, string _destFile)
        {
            srcFile = _srcFile;
            destFile = _destFile;
        }
    }
}
