using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace Wpf_observation_1.Model
{
	public class Manager
	{
		private ObservableCollection<Observation> observations = new ObservableCollection<Observation>();
		public ObservableCollection<Observation> Observations => observations;

		public Observation currentObservation { get; private set; } = new Observation();

		private ObservableCollection<Classification> classifications = new ObservableCollection<Classification>();
		public ObservableCollection<Classification> Classifications => classifications;

		private ObservableCollection<ObjectOfObservation> objects = new ObservableCollection<ObjectOfObservation>();
		public ObservableCollection<ObjectOfObservation> Objects => objects;

		private ObservableCollection<Rating> ratings = new ObservableCollection<Rating>();
		public ObservableCollection<Rating> Ratings => ratings;


		private string objectsPath = "objects.xml";
		private string classificationsPath = "classifications.xml";
		private string natureObservationsPath = "nature.xml";

		// коллекция наблюдений
		public void LoadFromFile()
		{
			// Проверка на наличие файла
			if (!File.Exists(natureObservationsPath))
				observations = new ObservableCollection<Observation>();

			XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Observation>));
			using (FileStream fs = new FileStream(natureObservationsPath, FileMode.Open))
			{
				observations = (ObservableCollection<Observation>)serializer.Deserialize(fs);
			}
		}
		public void SaveToXml()
		{
			XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Observation>));
			using (FileStream fs = new FileStream(natureObservationsPath, FileMode.Create))
			{
				serializer.Serialize(fs, observations);
			}
		}
		// комбобокс объектов наблюдения
		public void SaveToXml_objects()
		{
			XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<ObjectOfObservation>));
			using (FileStream fs = new FileStream(objectsPath, FileMode.Create))
			{
				serializer.Serialize(fs, objects);
			}
		}
		public void LoadFromFile_Objects()
		{
			if (!File.Exists(objectsPath))
				objects = new ObservableCollection<ObjectOfObservation>();

			XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<ObjectOfObservation>));
			using (FileStream fs = new FileStream(objectsPath, FileMode.Open))
			{
				objects = (ObservableCollection<ObjectOfObservation>)serializer.Deserialize(fs);
			}
		}
		// комбобокс классификаций
		public void LoadFromFile_Classification()
		{
			if (!File.Exists(classificationsPath))
				classifications = new ObservableCollection<Classification>();

			XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Classification>));
			using (FileStream fs = new FileStream(classificationsPath, FileMode.Open))
			{
				classifications = (ObservableCollection<Classification>)serializer.Deserialize(fs);
			}
		}
		public void SaveToXml_classification()
		{
			XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Classification>));
			using (FileStream fs = new FileStream(classificationsPath, FileMode.Create))
			{
				serializer.Serialize(fs, classifications);
			}
		}




		//метод добавления нового элемента
		public void AddObservation(Observation new_observation)
		{
			observations.Add(new_observation);
		}

		public void Add_object(ObjectOfObservation new_object)
		{
			objects.Add(new_object);
		}
		public void Add_Classification(Classification new_classification)
		{
			classifications.Add(new_classification);
		}





		public void Init_rating()
		{

			for (int i = 0; i < 9; i++)
			{
				Rating r = new Rating();
				r.Id = i + 1;
				r.RatingValue = i + 1;
				ratings.Add(r);
			}

		}



		public Manager()
		{
			LoadFromFile_Objects();
			LoadFromFile_Classification();
			Init_rating();
			LoadFromFile();
		}

		public void RemoveObservation(Observation observation)
		{
			Observations.Remove(observation);
			SaveToXml();
		}

		public void EditObservaion(int index, Observation o)
		{
			observations[index] = o;
		}
	}
}
