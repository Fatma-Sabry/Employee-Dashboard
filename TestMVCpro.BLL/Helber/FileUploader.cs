using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMVCpro.BLL.Helber
{
  public  class FileUploader
    {
        public static string FileUploade(string LocalPath ,IFormFile  file) 
        {
            try
            {
                string CVFolderPath = Directory.GetCurrentDirectory() + LocalPath;

                string FileName = Guid.NewGuid() + Path.GetFileName(file.FileName);

                string FinalPath = CVFolderPath + FileName;

                using (var stream = new FileStream(FinalPath, FileMode.Create))
                {
                    file.CopyTo(stream);

                }
                return FileName;
            }
            catch (Exception ex) 
            {

                return ex.Message;
                        
            }
            

        }

        public static string RemoveFile( string LocalPath,string file) 
        {
            try 
            {
                string FileName = Directory.GetCurrentDirectory() +LocalPath+ file;
                if (File.Exists(FileName)) 
                {
                    File.Delete(FileName);   
                  
                }
                
                var R = "FileDeleted";
               return R ;
            }
            
            catch (Exception ex) 
            {
                return ex.Message;
            }
        
        }

    }
}
