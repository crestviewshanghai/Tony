using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace MojoCube.Api.File
{
    public class Upload
    {
        #region
        string _OldFilePath;
        public string OldFilePath
        {
            get { return _OldFilePath; }
            set { _OldFilePath = value; }
        }
        string _FilePath;
        public string FilePath
        {
            get { return _FilePath; }
            set { _FilePath = value; }
        }
        string _OldFileName;
        public string OldFileName
        {
            get { return _OldFileName; }
            set { _OldFileName = value; }
        }
        string _FileName;
        public string FileName
        {
            get { return _FileName; }
            set { _FileName = value; }
        }
        string _FileType;
        public string FileType
        {
            get { return _FileType; }
            set { _FileType = value; }
        }
        int _FileSize;
        public int FileSize
        {
            get { return _FileSize; }
            set { _FileSize = value; }
        }
        string _Message;
        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }
        bool _IsUpload;
        public bool IsUpload
        {
            get { return _IsUpload; }
            set { _IsUpload = value; }
        }
        #endregion

        //上传方法
        public void DoFileUpload(FileUpload fileUpload)
        {
            try
            {
                if (fileUpload.PostedFile.ContentLength != 0)
                {
                    //文件上传的路径
                    if (_FilePath == null)
                    {
                        _FilePath = System.Web.HttpContext.Current.Server.MapPath("~/") + "Files/";
                    }
                    else
                    {
                        _OldFilePath = _FilePath + "/";
                        _FilePath = System.Web.HttpContext.Current.Server.MapPath("~/") + "Files/" + _FilePath + "/";
                    }

                    //文件名
                    string fileName = fileUpload.PostedFile.FileName.Substring(fileUpload.PostedFile.FileName.LastIndexOf('\\') + 1);
                    _OldFileName = fileName.Split('.')[0];
                    //文件类型
                    _FileType = fileName.Substring(fileName.LastIndexOf('.') + 1);
                    //文件大小
                    _FileSize = fileUpload.PostedFile.ContentLength;

                    //判断路径是否存在，否则创建路径
                    if (!System.IO.Directory.Exists(_FilePath))
                    {
                        System.IO.Directory.CreateDirectory(_FilePath);
                    }

                    if (_FileName == null)
                    {
                        _OldFilePath = _FileName = fileName;
                        _FilePath += _FileName;
                    }
                    else
                    {
                        _OldFilePath += _FileName + "." + _FileType;
                        _FilePath += _FileName + "." + _FileType;
                    }

                    fileUpload.PostedFile.SaveAs(_FilePath);
                    _IsUpload = true;
                    _Message = "上传成功";
                }
                else
                {
                    _IsUpload = false;
                }
            }
            catch
            {
                _IsUpload = false;
                _Message = "上传失败";
            }
        }

        //删除文件
        public static bool DeleteFile(string sPath)
        {
            try
            {
                System.IO.File.Delete(System.Web.HttpContext.Current.Server.MapPath("~/") + "Files/" + sPath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //判断是否为图片文件
        public bool IsImage()
        {
            if (_FileType == null)
            {
                return false;
            }
            else if (_FileType.ToLower() == "gif" || _FileType.ToLower() == "jpg" || _FileType.ToLower() == "jpeg" || _FileType.ToLower() == "png" || _FileType.ToLower() == "bmp")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
