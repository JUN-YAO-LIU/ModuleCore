using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ModuleCore.Controllers
{
    public class TestFunctionController : Controller
    {
        public IActionResult TestFunction_Index() 
        {

            return View();
        }

        public IActionResult btneMail()
        {
            //reference:https://blog.no2don.com/2021/01/c-gmail-smtp-server-requires-secure.html
            try
            {
                //建立 SmtpClient 物件 並設定 Gmail的smtp主機及Port  
                System.Net.Mail.SmtpClient MySmtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);

                //設定你的帳號密碼
                MySmtp.Credentials = new System.Net.NetworkCredential("momomomomo7577@gmail.com", "tfjztyomcvzfvuzf");

                //Gmial 的 smtp 必需要使用 SSL
                MySmtp.EnableSsl = true;

                //發送Email
                MySmtp.Send("momomomomo7577@gmail.com", "momomomomo7677@gmail.com", "C# Gmail發信測試", "文件內容");

                MySmtp.Dispose();
            }
            catch (Exception ex)
            {

            }
            return View("TestFunction_Index");
        }

        [HttpPost]
        public void btnMailAttachment()
        {
            try
            {
                System.Net.Mail.SmtpClient MailClient = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);

                MailAddress receiverAddress = new MailAddress("momomomomo7677@gmail.com", "肥子776");//<-這物件只是用來設定郵件帳號而已~
                MailAddress senderAddress = new MailAddress("chickensoupengineer@gmail.com", "雞湯工程師");
                MailMessage mail = new MailMessage(senderAddress, receiverAddress);//<-這物件是郵件訊息的部分~需設定寄件人跟收件人~可直接打郵件帳號也可以使用MailAddress物件~
                mail.Subject = "test";
                mail.Body = "一堆肥肥";
                mail.IsBodyHtml = true;//<-如果要這封郵件吃html的話~這屬性就把他設為true~~

                Attachment attachment = new Attachment(@"C:\Users\momom\OneDrive\桌面\數位經營\數位行銷概論-1.pdf");//<-這是附件部分~先用附件的物件把路徑指定進去~

                mail.Attachments.Add(attachment);

                MailClient.Credentials = new System.Net.NetworkCredential("momomomomo7577@gmail.com", "tfjztyomcvzfvuzf");

                //Gmial 的 smtp 必需要使用 SSL
                MailClient.EnableSsl = true;

                MailClient.Send(mail);

                MailClient.Dispose();
            }
            catch (Exception ex)
            {

            }
        }

        public IActionResult GameHub()
        {
            return View();
        }

        #region MemoryStream ToBase64String
        //引用:using Microsoft.AspNetCore.Http;
        //MemoryStream -> using System.IO;
        [HttpPost]
        [ValidateAntiForgeryToken]
        public void Base64Img(IFormFile fileBase64Img)
        {
            //System.IO.Stream getstream = fileBase64Img.OpenReadStream();

            #region 1.讀local的圖片並轉呈byte[]
            //FileStream fs = new FileStream(infAtt.FilePath, FileMode.Open);
            //2.讀入圖片Byte
            //byte[] byData = new byte[fs.Length];
            //fs.Read(byData, 0, byData.Length);
            //fs.Close();
            #endregion

            using (var ms = new MemoryStream())
            {
                fileBase64Img.CopyTo(ms);
                var fileBytes = ms.ToArray();
                string s = Convert.ToBase64String(fileBytes);
                // act on the Base64 data
            }
            //NEXT: memorystream 我要怎麼利用怎麼用
            //NEXT: 一定要用他嗎
            //NEXT: 哪時用


            //不知道能不能做成結果回傳上一頁
            //return re
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task txtString(string txtString)
        {

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> show64Img(IFormFile txtshowBase64Img)
        {
            string s = "";
            using (var ms = new MemoryStream())
            {
                txtshowBase64Img.CopyTo(ms);
                var fileBytes = ms.ToArray();
                s = Convert.ToBase64String(fileBytes);
                // act on the Base64 data
            }
            TempData["ImgBase64"] = s;
            return Redirect("/Home/Chapter1");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FileStream_GenTxt()
        {
            //1.讀取檔名 路徑
            string @path = @"C:\\Users\\momom\\Desktop\\CHUBB\\2.2測試紀錄\\ToSenao\\";
            string @fileName = @"Jim.txt";
            string TestfilePath = $"{@path}{fileName}";//研究一下怎麼用

            //2.建立txt檔案
            FileStream fileStream = new FileStream(@path + @fileName, FileMode.Create);

            //3.關掉檔案
            fileStream.Close();

            //4.寫入檔案 並設定能不能覆蓋檔案、編碼類型
            using (StreamWriter sw = new StreamWriter(@path + @fileName, false, Encoding.GetEncoding("BIG5")))
            {
                string str = "test我超棒"; //公司別--1

                //5.判斷是不是有中文字，中文字佔2Byte
                byte[] byteStr = Encoding.GetEncoding("big5").GetBytes(str);
                int lengthstr = byteStr.Length;

                //note: 寫檔 讀檔 會可以用到await
                //sw.WriteLine(str);
                await sw.WriteLineAsync(str);
            }
            
            return View("TestFunction_Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FileDownload()
        {
            //1.讀取檔名 路徑
            string @path = @"C:\\Users\\momom\\Desktop\\CHUBB\\2.2測試紀錄\\ToSenao\\";
            string @fileName = @"Jim.txt";
            string TestfilePath = $"{@path}{fileName}";//研究一下怎麼用
            byte[] result;
            try
            {
                //method 1
                FileStream stream = new FileStream(TestfilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                return File(stream, "application/octet-stream", @fileName); //MME 格式 可上網查 此為通用設定

                // method 2 不會用
                //using (FileStream SourceStream = File.Open(TestfilePath, FileMode.Open))
                //{
                //    result = new byte[SourceStream.Length];
                //    await SourceStream.ReadAsync(result, 0, (int)SourceStream.Length);
                //}

                //UserInput.Text = System.Text.Encoding.ASCII.GetString(result);
            }
            catch (Exception ex)
            {
                return Content("<script>alert('查無此檔案');window.close()</script>"); //利用Content 讀出JS檔案
            }

            return View("TestFunction_Index");
        }
        #endregion
    }
}
