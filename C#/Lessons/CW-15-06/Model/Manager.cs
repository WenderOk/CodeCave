using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CW_15_06.Model
{
    public class Manager
    {
        public Observation CurrentObservation { get; private set; }
        private ObservableCollection<Classification> classifications = new ObservableCollection<Classification>();
        public ObservableCollection<Classification> Classifications => classifications;

        private ObservableCollection<Observation> observations = new ObservableCollection<Observation>();
        public ObservableCollection<Observation> Observations => observations;

        private ObservableCollection<ObservationObject> objects = new ObservableCollection<ObservationObject>();
        public ObservableCollection<ObservationObject> Objects => objects;
        public Manager()
        { }

        public void SaveToXml_objects(string path, ObservableCollection<ObservationObject> collection)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<ObservationObject>));
            using (FileStream fs = new FileStream(path, FileMode.Create))
            { serializer.Serialize(fs, collection); }
        }

        public ObservableCollection<ObservationObject> LoadFromFile_objects(string path)
        {
            if (!File.Exists(path))
                return new ObservableCollection<ObservationObject>();
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<ObservationObject>));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            { return (ObservableCollection<ObservationObject>)serializer.Deserialize(fs); }
        }


        public void SaveToXml_classification(string path, ObservableCollection<Classification> collection)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Classification>));
            using (FileStream fs = new FileStream(path, FileMode.Create))
            { serializer.Serialize(fs, collection); }
        }

        public ObservableCollection<Classification> LoadFromFile_classification(string path)
        {
            if (!File.Exists(path))
                return new ObservableCollection<Classification>();
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Classification>));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            { return (ObservableCollection<Classification>)serializer.Deserialize(fs); }
        }


        public void SaveToXml_observations(string path, ObservableCollection<Observation> collection)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Observation>));
            using (FileStream fs = new FileStream(path, FileMode.Create))
            { serializer.Serialize(fs, collection); }
        }

        public ObservableCollection<Observation> LoadFromFile_observations(string path)
        {
            if (!File.Exists(path))
                return new ObservableCollection<Observation>();
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Observation>));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            { return (ObservableCollection<Observation>)serializer.Deserialize(fs); }
        }

        public void AddObject(ObservationObject newObject)
        {
            objects.Add(newObject);
        }

        public void AddClassification(Classification newClassification)
        {
            classifications.Add(newClassification);
        }

        public void AddObservation(Observation observation)
        {
            observations.Add(observation);
        }
    }
}
