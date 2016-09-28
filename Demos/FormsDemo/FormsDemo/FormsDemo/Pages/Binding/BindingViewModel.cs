using System;
using System.ComponentModel;

namespace FormsDemo
{
	public class BindingViewModel : INotifyPropertyChanged
	{
		public BindingViewModel()
		{
			ImgUrl = "https://cdn.spacetelescope.org/archives/images/large/heic1107a.jpg";
		}

		private string _imgUrl;
		public string ImgUrl
		{
			get
			{
				return _imgUrl;
			}
			set
			{
				if (_imgUrl != value)
				{
					_imgUrl = value;
					OnPropertyChanged("ImgUrl");
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

	   	protected void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this,
					new PropertyChangedEventArgs(propertyName));
		}
	}
}
