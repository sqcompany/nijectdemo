using System;
using System.IO;

namespace FileUpload
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new UpFileSingleTest();
            var info = new FileInfo(@"E:\学习资料\ASP.NET.MVC.4.Web编程.徐雷等.扫描版.pdf");
            //取得文件总长度
            var fileLegth = info.Length;
            //假设将文件切成5段
            const double perFileLengh = 4194304; //4M
            int divide;
            if (fileLegth <= perFileLengh)
            {
                divide = 1;
            }
            else
            {
                var d = (decimal)(fileLegth / perFileLengh);
                divide = (int)Math.Ceiling(d);
            }

            //取到每个文件段的长度
            //var perFileLengh = (int)fileLegth / divide;
            //var fileStream = new FileStream(@"E:\学习资料\ASP.NET.MVC.4.Web编程.徐雷等.扫描版.pdf", FileMode.Open);
            //表示最后剩下的文件段长度比perFileLengh小
            //循环上传数据
            for (int i = 0; i < divide; i++)
            {
                //每次定义不同的数据段,假设数据长度是500，那么每段的开始位置都是i*perFileLength
                var startPosition = (int)(i * perFileLengh);
                //取得每次数据段的数据量
                var totalCount = (int)(fileLegth - perFileLengh * i > perFileLengh ? perFileLengh : (int)(fileLegth - perFileLengh * i));
                //上传该段数据
                var fileStream = new FileStream(@"E:\学习资料\ASP.NET.MVC.4.Web编程.徐雷等.扫描版.pdf", FileMode.Open);
                using (fileStream)
                {
                    fileStream.Position = startPosition;
                    var buffer = new byte[totalCount];
                    fileStream.Read(buffer, 0, totalCount);
                    test.WriteToServer(@"F:\\ASP.NET.MVC.4.Web编程.徐雷等.扫描版1.pdf", startPosition, buffer);
                }
                //test.UpLoadFileFromLocal(fileStream, @"F:\\ASP.NET.MVC.4.Web编程.徐雷等.扫描版1.pdf", startPosition, totalCount);
                //test.UpLoadFileFromLocal(@"E:\\学习资料\ASP.NET.MVC.4.Web编程.徐雷等.扫描版.pdf", @"F:\\ASP.NET.MVC.4.Web编程.徐雷等.扫描版1.pdf", startPosition, i == divide ? divide : totalCount);
            }

        }
    }
}
