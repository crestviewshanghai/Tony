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

        //�ϴ�����
        public void DoFileUpload(FileUpload fileUpload)
        {
            try
            {
                if (fileUpload.PostedFile.ContentLength != 0)
                {
                    //�ļ��ϴ���·��
                    if (_FilePath == null)
                    {
                        _FilePath = System.Web.HttpContext.Current.Server.MapPath("~/") + "Files/";
                    }
                    else
                    {
                        _OldFilePath = _FilePath + "/";
                        _FilePath = System.Web.HttpContext.Current.Server.MapPath("~/") + "Files/" + _FilePath + "/";
                    }

                    //�ļ���
                    string fileName = fileUpload.PostedFile.FileName.Substring(fileUpload.PostedFile.FileName.LastIndexOf('\\') + 1);
                    _OldFileName = fileName.Split('.')[0];
                    //�ļ�����
                    _FileType = fileName.Substring(fileName.LastIndexOf('.') + 1);
                    //�ļ���С
                    _FileSize = fileUpload.PostedFile.ContentLength;

                    //�ж�·���Ƿ���ڣ����򴴽�·��
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
                    _Message = "�ϴ��ɹ�";
                }
                else
                {
                    _IsUpload = false;
                }
            }
            catch
            {
                _IsUpload = false;
                _Message = "�ϴ�ʧ��";
            }
        }

        //ɾ���ļ�
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

        //�ж��Ƿ�ΪͼƬ�ļ�
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
