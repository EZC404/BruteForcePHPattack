using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WebPasswordGether
{
	class HttpMethods
	{
		public static bool Post(string url, string postData,string referer, CookieContainer cookies,string ctype = "application/x-www-form-urlencoded", string acc = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3",string Key = "")
		{
			string key = Key;
			HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
			req.Method = "POST";
			req.CookieContainer = cookies;
			req.UserAgent = "";
			req.Referer = referer;
			req.ContentType = ctype;
			req.Accept = acc;

			Stream postStream = req.GetRequestStream();
			byte[] postBytes = Encoding.ASCII.GetBytes(postData);
			postStream.Write(postBytes, 0, postBytes.Length);
			postStream.Dispose();

			HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
			cookies.Add(resp.Cookies);

			StreamReader sr = new StreamReader(resp.GetResponseStream());
			string pageSrc = sr.ReadToEnd();
			sr.Dispose();

			return (!pageSrc.Contains(key));

		}
	}
}
