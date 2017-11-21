using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Model
{
	public class book
	{
		public book()
		{

        }
		private int _bookid;
		private string _bookname;
		private string _writer;
		private string _price;
		private string _press;
		private string _stock;
		private string _type;
		private string _picture;
		private string _synopsis;
		/// <summary>
		/// 
		/// </summary>
		public int bookID
		{
			set{ _bookid=value;}
			get{return _bookid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string bookName
		{
			set{ _bookname=value;}
			get{return _bookname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string writer
		{
			set{ _writer=value;}
			get{return _writer;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string press
		{
			set{ _press=value;}
			get{return _press;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string stock
		{
			set{ _stock=value;}
			get{return _stock;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string picture
		{
			set{ _picture=value;}
			get{return _picture;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string synopsis
		{
			set{ _synopsis=value;}
			get{return _synopsis;}
		}

	}
}

