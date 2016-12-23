using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Common;
using Microsoft.ProjectOxford.Face.Contract;

namespace Faciem.Idems
{
	public class FaciemIdem : INotifyPropertyChanged
	{
		#region Fields

		/// <summary>
		/// Face gender text string
		/// </summary>
		string _gender;

		/// <summary>
		/// Face age text string
		/// </summary>
		string _age;

		/// <summary>
		/// confidence value of this face to a target face
		/// </summary>
		double _confidence;

		/// <summary>
		/// Person name
		/// </summary>
		string _personName;

		/// <summary>
		/// Face height in pixel
		/// </summary>
		int _height;

		/// <summary>
		/// Face position X relative to image left-top in pixel
		/// </summary>
		int _left;

		/// <summary>
		/// Face position Y relative to image left-top in pixel
		/// </summary>
		int _top;

		/// <summary>
		/// Face width in pixel
		/// </summary>
		int _width;

		/// <summary>
		/// Facial hair display string
		/// </summary>
		string _facialHair;

		/// <summary>
		/// Indicates whether the face is smile or not
		/// </summary>
		string _isSmiling;

		/// <summary>
		/// Indicates the glasses type
		/// </summary>
		string _glasses;

		/// <summary>
		/// Indicates the headPose
		/// </summary>
		string _headPose;

		#endregion Fields

		#region Events

		/// <summary>
		/// Implement INotifyPropertyChanged interface
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		#endregion Events

		#region Properties

		/// <summary>
		/// Gets or sets gender text string 
		/// </summary>
		public string Gender
		{
			get
			{
				return _gender;
			}

			set
			{
				_gender = value;
				OnPropertyChanged<string>();
			}
		}

		/// <summary>
		/// Gets or sets age text string
		/// </summary>
		public string Age
		{
			get
			{
				return _age;
			}

			set
			{
				_age = value;
				OnPropertyChanged<string>();
			}
		}

		/// <summary>
		/// Gets or sets confidence value
		/// </summary>
		public double Confidence
		{
			get
			{
				return _confidence;
			}

			set
			{
				_confidence = value;
				OnPropertyChanged<double>();
			}
		}


		/// <summary>
		/// Gets or sets image path
		/// </summary>
		public string ImagePath
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets face id
		/// </summary>
		public string FaceId
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets person's name
		/// </summary>
		public string PersonName
		{
			get
			{
				return _personName;
			}

			set
			{
				_personName = value;
				OnPropertyChanged<string>();
			}
		}

		/// <summary>
		/// Gets or sets face height
		/// </summary>
		public int Height
		{
			get
			{
				return _height;
			}

			set
			{
				_height = value;
				OnPropertyChanged<int>();
			}
		}

		/// <summary>
		/// Gets or sets face position X
		/// </summary>
		public int Left
		{
			get
			{
				return _left;
			}

			set
			{
				_left = value;
				OnPropertyChanged<int>();
			}
		}

		/// <summary>
		/// Gets or sets face position Y
		/// </summary>
		public int Top
		{
			get
			{
				return _top;
			}

			set
			{
				_top = value;
				OnPropertyChanged<int>();
			}
		}

		/// <summary>
		/// Gets or sets face width
		/// </summary>
		public int Width
		{
			get
			{
				return _width;
			}

			set
			{
				_width = value;
				OnPropertyChanged<int>();
			}
		}

		/// <summary>
		/// Gets or sets facial hair display string
		/// </summary>
		public string FacialHair
		{
			get
			{
				return _facialHair;
			}

			set
			{
				_facialHair = value;
				OnPropertyChanged<string>();
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether the face is smile or not
		/// </summary>
		public string IsSmiling
		{
			get
			{
				return _isSmiling;
			}

			set
			{
				_isSmiling = value;
				OnPropertyChanged<bool>();
			}
		}

		/// <summary>
		/// Gets or sets a value indicating the glasses type 
		/// </summary>
		public string Glasses
		{
			get
			{
				return _glasses;
			}

			set
			{
				_glasses = value;
				OnPropertyChanged<string>();
			}
		}

		/// <summary>
		/// Gets or sets a value indicating the head pose value.
		/// </summary>
		public string HeadPose
		{
			get { return _headPose; }
			set
			{
				_headPose = value;
				OnPropertyChanged<string>();
			}
		}

		#endregion Properties

		#region Methods

		/// <summary>
		/// NotifyProperty Helper functions
		/// </summary>
		/// <typeparam name="T">property type</typeparam>
		/// <param name="caller">property change caller</param>
		void OnPropertyChanged<T>([CallerMemberName]string caller = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
		}

		#endregion Methods
	}
}